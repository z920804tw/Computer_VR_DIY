using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeTest : MonoBehaviour
{
    // Start is called before the first frame update

    public LineRenderer lineRenderer;
    public Transform[] hingePoints; // 保存 Hinge Joint 的連接點

    public GameObject StartObject, EndObject;
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


}
