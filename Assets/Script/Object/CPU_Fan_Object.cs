using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using Unity.VisualScripting.FullSerializer;

using UnityEngine;

public class CPU_Fan_Object : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("一般風扇物件設定")]
    public GameObject firstColliderObject;                                  //紀錄第一個碰撞的物件
    public Animator anim;
    public GameObject[] ObjectsTransform;


    [Header("Debug")]
    public bool isHolding;
    public bool cpuHasPlace;
    [SerializeField] bool isFirstCollider;                                  //判斷是否第一次碰撞
    Rigidbody rb;
    bool check;


    void Start()
    {
        check = false;
        cpuHasPlace = false;
        isFirstCollider = false;
        isHolding = false;
        rb = this.gameObject.GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame

    private void OnTriggerStay(Collider other)
    {
        //判斷碰撞到的物體tag是否與自己的tag一致，如果一致就進到裡面
        if (other.gameObject.tag == this.gameObject.tag)
        {

            if (isFirstCollider == false)                                  //判斷是否第一次碰撞
            {
                isFirstCollider = true;                                   //設定true，這樣就不會修改到第一次紀錄的值
                firstColliderObject = other.gameObject;                   //設定第一次碰撞物為碰撞到的物件
            }
        }
        if (other.gameObject.tag == "Cpu")
        {
            Object_Transform cpu = other.gameObject.GetComponent<Object_Transform>();
            if (cpu != null && cpu.hasPlace == true)
            {
                cpuHasPlace = true;
            }

        }

    }

    public void Remove_Fans_Setting()
    {

        Debug.Log("重製風扇設定");
        isHolding = false;
        this.gameObject.transform.SetParent(null);
        rb.isKinematic = false;
        cpuHasPlace = false;

        anim.SetBool("place", false);
        if (firstColliderObject != null)
        {

            firstColliderObject.GetComponent<Object_Transform>().hasPlace = false;
            firstColliderObject = null;
            isFirstCollider = false;
        }
        if (check == true)
        {
            if (ObjectsTransform != null)                                      //看放置座標陣列裡有沒有值，如果有才會執行
            {
                foreach (GameObject obj in ObjectsTransform)             //用foreach來把該陣列裡面的所有物件的Outline都關閉
                {

                    if (obj.GetComponent<Outline>() != null)               //會先檢查這個物件有沒有Outline這個Component，如果有才會把他關閉，否則就什麼都不做
                    {
                        obj.GetComponent<Outline>().enabled = false;
                    }
                }
            }
            check = false;
        }
    }
    public void showCpuFansOutline()
    {
        if (check == false)
        {
            ObjectsTransform = GameObject.FindGameObjectsWithTag(this.gameObject.tag);

            if (ObjectsTransform != null)
            {
                foreach (GameObject obj in ObjectsTransform)
                {
                    Outline outline = obj.GetComponent<Outline>();
                    Object_Transform objTransform = obj.GetComponent<Object_Transform>();

                    outline.enabled = true;
                }
            }
            isHolding = true;
            check = true;
        }
    }


}
