using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ScrewEnum
{
    None = 0,
    hold,
    place
}
public enum ScrewType
{
    None = 0,
    Large,
    Medium,
    Small
}

public class Screw_Object : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject firstColliderObject;                                  //紀錄第一個碰撞的物件
    public GameObject[] ObjectsTransform;

    public Animator anim;

    [Header("螺絲設定")]
    public ScrewEnum screwEnum = ScrewEnum.None;
    public ScrewType screwType = ScrewType.None;


    [Header("Debug")]

    public bool isFirstCollider;                                  //判斷是否第一次碰撞
    Rigidbody rb;


    void Start()
    {

        isFirstCollider = false;
        rb = this.gameObject.GetComponent<Rigidbody>();
        anim=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay(Collider other)
    {
        //判斷碰撞到的物體tag是否與自己的tag一致，如果一致就進到裡面
        if (other.gameObject.tag == this.gameObject.tag)
        {
            Object_Transform object_Transform = other.GetComponent<Object_Transform>();
            if (isFirstCollider == false)
            {
                if (object_Transform.screwEnum == screwEnum && object_Transform.screwType == screwType) //雙方的螺絲設定也要一樣才會記錄
                {
                    firstColliderObject = other.gameObject;                   //設定第一次碰撞物為碰撞到的物件
                    //showScrewOutline();
                    //firstColliderObject.GetComponent<Object_Transform>().prev_Transform=this.gameObject;
                    isFirstCollider = true;
                    Debug.Log("1");
                }
            }
        }
    }


    public void Remove_Screw_setting()
    {
        Debug.Log("重製螺絲設定");
        this.gameObject.transform.SetParent(null);
        isFirstCollider = false;
        rb.isKinematic = false;
        anim.SetBool("place",false);
        if (firstColliderObject != null)
        {
            firstColliderObject.GetComponent<Object_Transform>().hasPlace = false;
            screwEnum = ScrewEnum.hold;
            firstColliderObject = null;
            isFirstCollider = false;
        }
        removeScrewOutline();
    }

    public void showScrewOutline()
    {
        ObjectsTransform = GameObject.FindGameObjectsWithTag("Screw");
        if (ObjectsTransform != null)
        {
            foreach (GameObject obj in ObjectsTransform)
            {
                if (obj.GetComponent<Object_Transform>() != null && obj.GetComponent<Outline>() != null)
                {
                    if (obj.GetComponent<Object_Transform>().screwType == screwType)
                    {
                        obj.GetComponent<Outline>().enabled = true;
                    }
                }
            }
            this.GetComponent<Outline>().enabled = true;
        }
    }
    public void removeScrewOutline()
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
