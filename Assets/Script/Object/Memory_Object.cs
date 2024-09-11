using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Memory_Object : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("記憶體物件設定")]

    public GameObject[] ObjectsTransform;
    public Animator anim;


    [Header("Debug")]
    public GameObject firstColliderObject;                                  //紀錄第一個碰撞的物件
    [SerializeField] bool isFirstCollider;                                  //判斷是否第一次碰撞
    public bool isHolding;
    Rigidbody rb;

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
        if (firstColliderObject != null && isHolding == false)
        {
            Physics.IgnoreCollision(firstColliderObject.GetComponent<Object_Transform>().colliderObj,GetComponent<BoxCollider>(),true);
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
    }

    public void Remove_Memory_setting()
    {

        Debug.Log("重製記憶體設定");
        isHolding = false;
        this.gameObject.transform.SetParent(null);
        rb.isKinematic = false;
        anim.SetBool("place", false);
        if (firstColliderObject != null)
        {
            firstColliderObject.GetComponent<Object_Transform>().hasPlace = false;
            Physics.IgnoreCollision(firstColliderObject.GetComponent<Object_Transform>().colliderObj,GetComponent<BoxCollider>(),false);
            firstColliderObject = null;
            isFirstCollider = false;
        }

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

    }

    public void showMemoryOutline()
    {


        ObjectsTransform = GameObject.FindGameObjectsWithTag(this.gameObject.tag);                //每次抓取特定物件就會去抓跟這個物件tag一致的物件

        if (ObjectsTransform != null)
        {
            foreach (GameObject obj in ObjectsTransform)
            {
                obj.GetComponent<Outline>().enabled = true;
            }
        }
        isHolding = true;

    }
}
