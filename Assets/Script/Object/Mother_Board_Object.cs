using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mother_Board_Object : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject firstColliderObject;                                  //紀錄第一個碰撞的物件
    public GameObject[] ObjectsTransform;
    

    public bool isHolding;
    public Animator anim;

    [SerializeField] bool isFirstCollider;                                  //判斷是否第一次碰撞
    Rigidbody rb;
    bool check;
    void Start()
    {
        check = false;
        isFirstCollider = false;
        isHolding = false;
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

            if (isFirstCollider == false)                                  //判斷是否第一次碰撞
            {
                isFirstCollider = true;                                   //設定true，這樣就不會修改到第一次紀錄的值
                firstColliderObject = other.gameObject;                   //設定第一次碰撞物為碰撞到的物件
            }

        }
    }

    public void Remove_MotherBoard_Setting()
    {
        Debug.Log("重製主機板設定");
        isHolding = false;
        this.gameObject.transform.SetParent(null);
        rb.isKinematic = false;
        
        anim.SetBool("place",false);
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
    public void showMotherBoardOutline()
    {
        if (check == false)
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
            check = true;


        }
    }
}
