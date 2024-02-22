using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.Rendering;

public class RopeTest : MonoBehaviour
{
    // Start is called before the first frame update

    public LineRenderer lineRenderer;
    public Transform[] hingePoints; // 保存 Hinge Joint 的連接點

    public GameObject StartObject, EndObject;

    public string current;


    public float max;
    [SerializeField] float distance;




    void Start()
    {
        if (lineRenderer == null || hingePoints == null || hingePoints.Length == 0)
        {
            Debug.LogError("Line Renderer 或 Hinge Points 未設置！");
            return;
        }
        // 設置 Line Renderer 的點數
        lineRenderer.positionCount = hingePoints.Length;





    }
    // Update is called once per frame
    void Update()
    {
        // 添加 Hinge Joint 連接點到 Line Renderer 的頂點位置列表
        for (int i = 0; i < hingePoints.Length; i++)
        {
            lineRenderer.SetPosition(i, hingePoints[i].position);
        }


    }

    private void FixedUpdate()
    {
        distance = Vector3.Distance(StartObject.transform.position, EndObject.transform.position);
        if (distance > max)
        {

            if (current == "Start")
            {
                Vector3 direction =StartObject.transform.position - EndObject.transform.position;
                Vector3 newPos = EndObject.transform.position - direction;
                StartObject.transform.position = newPos;

            }
            else if (current == "End")
            {
                Vector3 direction = EndObject.transform.position - StartObject.transform.position;
                Vector3 newPos = StartObject.transform.position - direction;
                EndObject.transform.position = newPos;
            }

        }
    }





}
