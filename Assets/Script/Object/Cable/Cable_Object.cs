using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Cable_Object : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject firstColliderObject;
    public GameObject cableParent;
    public GameObject[] ObjectsTransform;
    public Animator anim;
    Rigidbody rb;

    [Header("電線設定")]
    //public string CableType;
    //public string CableDirection;

    public CableType cableType;
    public CableDirection cableDirection;






    [Header("Debug")]
    public bool isHolding;
    [SerializeField] bool isFirstCollider;


    void Start()
    {

        isFirstCollider = false;
        isHolding = false;
        rb = this.gameObject.GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (firstColliderObject != null  && isHolding==false)
        {
            Physics.IgnoreCollision(firstColliderObject.GetComponent<Object_Transform>().colliderObj, GetComponent<Collider>(), true);

        }
    }

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
        rb.isKinematic = false;
        anim.enabled = true;
        anim.SetBool("place", false);


        this.gameObject.transform.SetParent(cableParent.transform);
        if (firstColliderObject != null)
        {
            Physics.IgnoreCollision(firstColliderObject.GetComponent<Object_Transform>().colliderObj, GetComponent<Collider>(), false);
            firstColliderObject.GetComponent<Object_Transform>().hasPlace = false;
            firstColliderObject = null;
            isFirstCollider = false;
        }

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
    }

    public void showCableOutline()
    {

        ObjectsTransform = GameObject.FindGameObjectsWithTag(this.gameObject.tag);
        if (ObjectsTransform != null)
        {
            foreach (GameObject obj in ObjectsTransform)
            {
                Object_Transform object_Transform = obj.GetComponent<Object_Transform>();
                Outline outline = obj.GetComponent<Outline>();

                if (outline != null && object_Transform != null)
                {
                    if (object_Transform.T_cableType == cableType && object_Transform.T_cableDirection == cableDirection)
                    {
                        obj.GetComponent<Outline>().enabled = true;
                    }
                }

            }
            this.gameObject.GetComponent<Outline>().enabled = true;
        }
        isHolding = true;

    }
}

