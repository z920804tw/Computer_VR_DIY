using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class Wire : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform startTransform, endTransform;
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] int segmentCount = 10;
    [SerializeField] float totalLength = 10;

    [SerializeField] float totalWeight = 10;

    [SerializeField] float radius = 0.5f;
    [SerializeField] float drag = 1;
    [SerializeField] float angularDrag = 1;

    [SerializeField] bool usePhysics = false;

    Transform[] segments;
    [SerializeField] Transform segmentParent;

    int prevSegmentCount;
    float prevTotalLength;
    float prevDrag;
    float prevTotalWeight;
    float prevAngularDrag;

    public float prevRadius;

    void Start()
    {
        
    }

    private void Update()
    {
        if (prevSegmentCount != segmentCount)
        {
            segments = new Transform[segmentCount];
            lineRenderer.positionCount=segments.Length;
            RemoveSegments();
            GenerateSegments();

        }
        prevSegmentCount = segmentCount;

        if (totalLength != prevTotalLength || prevDrag != drag || prevTotalWeight != totalWeight || prevAngularDrag != angularDrag)
        {

            UpdateWire();
        }
        prevTotalLength = totalLength;
        prevDrag = drag;
        prevTotalWeight = totalLength;
        prevAngularDrag = angularDrag;

        if (prevRadius != radius && usePhysics)
        {

            UpdateRadius();
        }
        prevRadius = radius;

        for(int i=0;i<segments.Length;i++){
            lineRenderer.SetPosition(i,segments[i].position);
        }
    }
    void UpdateRadius()
    {

        for (int i = 0; i < segments.Length; i++)
        {
            SetRadiusOnsegments(segments[i], radius);
        }
    }

    private void SetRadiusOnsegments(Transform transform, float radius)
    {
        SphereCollider sphereCollider = transform.GetComponent<SphereCollider>();
        sphereCollider.radius = radius;
    }

    void UpdateWire()
    {
        for (int i = 0; i < segments.Length; i++)
        {
            if (i != 0)
            {

                UpdateLengthOnSegment(segments[i], totalLength / segmentCount);
            }
            UpdateWeightOnSegment(segments[i], totalLength, drag, angularDrag);
        }
    }

    private void UpdateWeightOnSegment(Transform transform, float totalLength, float drag, float angularDrag)
    {
        Rigidbody rigidbody = transform.GetComponent<Rigidbody>();
        rigidbody.mass = totalWeight / segmentCount;
        rigidbody.drag = drag;
        rigidbody.angularDrag = angularDrag;
    }

    private void UpdateLengthOnSegment(Transform transform, float v)
    {
        ConfigurableJoint joint = transform.GetComponent<ConfigurableJoint>();
        if (joint != null)
        {
            joint.connectedAnchor = Vector3.forward * totalLength / segmentCount;
        }
    }

    private void RemoveSegments()
    {
        for (int i = 0; i < segments.Length; i++)
        {
            if (segments[i] != null)
            {
                Destroy(segments[i].gameObject);
            }
        }
    }

    /*private void OnDrawGizmos()
    {
        if (segments != null)
        {
            for (int i = 0; i < segments.Length; i++)
            {
                Gizmos.DrawWireSphere(segments[i].position, radius);

            }

        }

    }*/

    void GenerateSegments()
    {
        JoinSegment(startTransform, null, true, false, true);
        Transform prevTransform = startTransform;                                       //紀錄第一個 記錄點
        Vector3 direction = (endTransform.position - startTransform.position);              //方向

        for (int i = 0; i < segmentCount; i++)
        {
            GameObject segment = new GameObject($"segment{i}");                           //生成新的物件
            segment.transform.SetParent(segmentParent);                                 //指定新生成的物件為segmentParent的子物件
            segments[i] = segment.transform;                                              //紀錄位置
            segment.layer=7;

            Vector3 segmentPos = prevTransform.position + (direction / segmentCount);         //更改位置在記錄點的右邊
            segment.transform.position = segmentPos;                                      //設定位置

            JoinSegment(segment.transform, prevTransform);

            
            prevTransform = segment.transform;                                            //把記錄點換到新的物件位置上

        }
        JoinSegment(endTransform, prevTransform, true, true, true);
    }

    void JoinSegment(Transform current, Transform connectedTransform, bool isKinetic = false, bool isCloseConnected = false, bool hasCollider = false)
    {
        if (current.GetComponent<Rigidbody>() == null)
        {
            Rigidbody rigidbody = current.AddComponent<Rigidbody>();
            rigidbody.isKinematic = isKinetic;
            rigidbody.mass = totalWeight / segmentCount;
            rigidbody.drag = drag;
            rigidbody.angularDrag = angularDrag;
        }

        if (usePhysics == true && hasCollider == false)
        {
            SphereCollider sphereCollider = current.AddComponent<SphereCollider>();
            sphereCollider.radius = radius;

        }

        if (connectedTransform != null)
        {
            ConfigurableJoint joint = current.GetComponent<ConfigurableJoint>();

            if (joint == null)
            {

                joint = current.AddComponent<ConfigurableJoint>();
            }
            joint.connectedBody = connectedTransform.GetComponent<Rigidbody>();

            joint.autoConfigureConnectedAnchor = false;
            if (isCloseConnected == true)
            {
                joint.connectedAnchor = Vector3.forward * 0.1f;
            }
            else
            {
                joint.connectedAnchor = Vector3.forward * (totalLength / segmentCount);
            }

            joint.xMotion = ConfigurableJointMotion.Locked;
            joint.yMotion = ConfigurableJointMotion.Locked;
            joint.zMotion = ConfigurableJointMotion.Locked;

            joint.angularXMotion = ConfigurableJointMotion.Free;
            joint.angularYMotion = ConfigurableJointMotion.Free;
            joint.angularZMotion = ConfigurableJointMotion.Limited;

            SoftJointLimit softJointLimit = new SoftJointLimit();
            softJointLimit.limit = 0;
            joint.angularZLimit = softJointLimit;

            JointDrive jointDrive = new JointDrive();
            jointDrive.positionDamper = 0;
            jointDrive.positionDamper = 0;
            joint.angularXDrive = jointDrive;
            joint.angularYZDrive = jointDrive;

            joint.enableCollision=false;
            joint.enablePreprocessing=false;
        }
    }



}
