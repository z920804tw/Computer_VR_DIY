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
    public GameObject cableParent;
    public Animator anim;
    public GameObject[] ObjectsTransform;


    [Header("Debug")]
    public bool isHolding;
    public bool cpuHasPlace;
    [SerializeField] bool isFirstCollider;                                  //判斷是否第一次碰撞
    Rigidbody rb;



    void Start()
    {
        cpuHasPlace = false;
        isFirstCollider = false;
        isHolding = false;
        rb = this.gameObject.GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (firstColliderObject != null && isHolding == false)
        {
            Physics.IgnoreCollision(firstColliderObject.GetComponent<Object_Transform>().colliderObj, GetComponent<BoxCollider>(), true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //判斷碰撞到的物體tag是否與自己的tag一致，如果一致就進到裡面
        if (other.gameObject.tag == this.gameObject.tag)
        {
            if (other.gameObject.GetComponent<Object_Transform>().hasPlace == false) //要先判斷該放置座標的hasPlace必須為false(上面沒東西)才能放置
            {
                if (isFirstCollider == false)                                  //判斷是否第一次碰撞
                {
                    isFirstCollider = true;                                   //設定true，這樣就不會修改到第一次紀錄的值
                    firstColliderObject = other.gameObject;                   //設定第一次碰撞物為碰撞到的物件
                }
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
        rb.isKinematic = false;
        cpuHasPlace = false;

        if (cableParent != null)
        {
            this.gameObject.transform.SetParent(cableParent.transform);
        }
        else
        {
            this.gameObject.transform.SetParent(null);
        }

        anim.SetBool("place", false);
        if (firstColliderObject != null)
        {
            firstColliderObject.GetComponent<Object_Transform>().hasPlace = false;
            Physics.IgnoreCollision(firstColliderObject.GetComponent<Object_Transform>().colliderObj, GetComponent<BoxCollider>(), false);
            firstColliderObject = null;
            isFirstCollider = false;
        }


        foreach (GameObject obj in ObjectsTransform)             //用foreach來把該陣列裡面的所有物件的Outline都關閉
        {

            if (obj.GetComponent<Outline>() != null)               //會先檢查這個物件有沒有Outline這個Component，如果有才會把他關閉，否則就什麼都不做
            {
                obj.GetComponent<Outline>().enabled = false;
            }
        }


    }
    public void showCpuFansOutline()
    {

        ObjectsTransform = GameObject.FindGameObjectsWithTag(this.gameObject.tag);
        
        foreach (GameObject obj in ObjectsTransform)
        {
            if (obj.GetComponent<Object_Transform>() != null && obj.GetComponent<Outline>() != null)
            {
                obj.GetComponent<Outline>().enabled = true;
            }
        }
        this.gameObject.GetComponent<Outline>().enabled = true;
        isHolding = true;

    }


}
