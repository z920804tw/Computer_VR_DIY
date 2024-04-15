using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Cable_Object : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject firstColliderObject;
    public GameObject cableParent;
    public GameObject[] ObjectsTransform;
    Rigidbody rb;

    [Header("電線設定")]
    //public string CableType;
    //public string CableDirection;

    public CableType cableType;
    public CableDirection cableDirection;


    [Header("Debug")]
    public bool isHolding;
    [SerializeField] bool isFirstCollider;
    [SerializeField] bool check;


    void Start()
    {
        check = false;
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

    public void Remove_Cable_setting()
    {
        Debug.Log("重製Cable設定");
        isHolding = false;
        this.gameObject.transform.SetParent(cableParent.transform);
        rb.isKinematic = false;
        if (firstColliderObject != null)
        {
            firstColliderObject.GetComponent<Object_Transform>().hasPlace = false;
            firstColliderObject = null;
            isFirstCollider = false;
        }
        if (check == true)
        {
            if (ObjectsTransform != null)
            {
                foreach (GameObject obj in ObjectsTransform)
                {

                    if (obj.GetComponent<Outline>() != null)
                    {
                        obj.GetComponent<Outline>().enabled = false;
                    }
                }
            }
            check = false;
        }

    }

    public void showCableOutline()
    {
        if (check == false)
        {
            ObjectsTransform = GameObject.FindGameObjectsWithTag(this.gameObject.tag);
            if (ObjectsTransform != null)
            {
                foreach (GameObject obj in ObjectsTransform)
                {
                    Object_Transform object_Transform = obj.GetComponent<Object_Transform>();
                    Outline outline=obj.GetComponent<Outline>();

                    if (outline!= null&&object_Transform != null)
                    { 
                        if (object_Transform.T_cableType==cableType&&object_Transform.T_cableDirection==cableDirection)
                        {
                            obj.GetComponent<Outline>().enabled = true;
                        }
                    }

                }
                this.gameObject.GetComponent<Outline>().enabled=true;
            }
            isHolding = true;
            
            check = true;
        }
    }
}

