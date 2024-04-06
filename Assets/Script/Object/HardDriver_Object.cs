using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum HardDriverType
{
    None = 0,
    HHD,
    SSD,
    M2
}


public class HardDriver_Object : MonoBehaviour
{
    public GameObject firstColliderObject;                                  //紀錄第一個碰撞的物件
    public GameObject[] ObjectsTransform;

    public HardDriverType hardDriverType;

    public bool isHolding;


    [SerializeField] bool isFirstCollider;                                  //判斷是否第一次碰撞
    Rigidbody rb;
    bool check;
    void Start()
    {
        check = false;
        isFirstCollider = false;
        isHolding = false;
        rb = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay(Collider other)
    {
        //判斷碰撞到的物體tag是否與自己的tag一致，如果一致就進到裡面
        if (other.gameObject.tag == this.gameObject.tag && other.gameObject.GetComponent<Object_Transform>() != null)
        {
            if (isFirstCollider == false)
            {
                Object_Transform obj = other.gameObject.GetComponent<Object_Transform>();
                if (obj.hardDriverType == this.hardDriverType)
                {

                    isFirstCollider = true;                                   //設定true，這樣就不會修改到第一次紀錄的值
                    firstColliderObject = other.gameObject;                   //設定第一次碰撞物為碰撞到的物件

                }
            }
        }
    }

    public void Remove_SSD_Setting()
    {

        Debug.Log("重製固態硬碟設定");
        isHolding = false;
        this.gameObject.transform.SetParent(null);
        rb.isKinematic = false;
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
    public void showSSDOutline()
    {
        if (check == false)
        {
            ObjectsTransform = GameObject.FindGameObjectsWithTag(this.gameObject.tag);                //每次抓取特定物件就會去抓跟這個物件tag一致的物件
            if (ObjectsTransform != null)
            {
                foreach (GameObject obj in ObjectsTransform)
                {
                    if (obj.GetComponent<Object_Transform>() != null && obj.GetComponent<Outline>() != null)
                    {
                        if (obj.GetComponent<Object_Transform>().hardDriverType == hardDriverType)
                        {
                            obj.GetComponent<Outline>().enabled = true;
                        }
                    }
                }
                this.GetComponent<Outline>().enabled = true;
            }
            isHolding = true;
            check = true;
        }
    }
}