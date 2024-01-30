using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class CPU_Fan_Object : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject firstColliderObject;                                  //紀錄第一個碰撞的物件
    public GameObject[] ObjectsTransform;


    [SerializeField] bool isFirstCollider;                                  //判斷是否第一次碰撞
    Rigidbody rb;
    bool check;
    public bool isHolding;
    public bool cpuHasPlace;
    void Start()
    {
        check = false;
        cpuHasPlace = false;
        isFirstCollider = false;
        isHolding = false;
        rb = this.gameObject.GetComponent<Rigidbody>();
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
    }

    public void Remove_Fans_Setting()
    {

        Debug.Log("重製風扇設定");
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
    public void showCpuFansOutline()
    {
        if (check == false)
        {
            ObjectsTransform = GameObject.FindGameObjectsWithTag(this.gameObject.tag);
            GameObject cpuTransform = GameObject.Find("Cpu Transform");

            if (ObjectsTransform != null)
            {
                foreach (GameObject obj in ObjectsTransform)
                {
                    if (obj.GetComponent<Outline>()!=null&&obj.GetComponent<Object_Transform>()!=null&&cpuTransform!=null)
                    {
                        if (cpuTransform.GetComponent<Object_Transform>().hasPlace == false)
                        {
                            obj.GetComponent<Outline>().OutlineColor = Color.red;
                            cpuHasPlace=false;

                        }
                        else{
                            obj.GetComponent<Outline>().OutlineColor = new Color(255f / 255, 208f / 255, 0f, 255f / 255);
                            cpuHasPlace=true;
                        }
                    }
                    obj.GetComponent<Outline>().enabled=true;

                }


            }
            isHolding = true;
            check = true;
        }
    }
}
