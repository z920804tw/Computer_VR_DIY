using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class Object_Transform : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject colliderObject;
    [Header("主機板腳位設定")]
    public int m_LGA;


    //Transform objectRotation;
    public bool hasPlace;



    void Start()
    {
        hasPlace = false;
    }

    // Update is called once per frame
    void Update()
    {

    }



    //判斷碰撞偵測的物件，並把物件變成子物件
    private void OnTriggerStay(Collider other)
    {


        if (other.gameObject.tag == this.gameObject.tag)                                                   //判斷是否碰撞物件的tag是否與自己的tag一致
        {
            if (hasPlace == false)                                                                         //判斷這個放置座標物件是不是已經有被放置東西了
            {
                colliderObject = other.gameObject;                                                        //沒有的話會記錄碰撞到的物件
                switch (colliderObject.tag)                                                              //使用switch判斷物件的tag來選擇要執行的函示
                {
                    case "Cpu":
                        CPU_ObjectTransform();
                        break;
                    case "Fans":
                        Cpu_Fan_ObjectTransform();
                        break;
                    case "MotherBoard":
                        MotherBoard_ObjectTransform();
                        break;
                    case "GraphicsCard":
                        GraphicsCard_ObjectTransform();
                        break;
                    case "Memory":
                        Memory_ObjectTransform();
                        break;
                    case "Power":
                        Power_ObjectTransform();
                        break;
                    case "SSD":
                        SSD_ObjectTransform();
                        break;
                    default:
                        ObjectTransform();

                        break;

                }

            }


        }



    }

    //CPU用的，主要多了CPU跟主機板的LGA腳位判斷
    void CPU_ObjectTransform()
    {

        if (colliderObject.GetComponent<CPU_Object>().firstColliderObject != null)                            //判斷碰撞物件上的ObjectParent中的firstCollider是不是有東西
        {
            if (colliderObject.GetComponent<CPU_Object>().firstColliderObject.name == this.gameObject.name && colliderObject.GetComponent<CPU_Object>().c_LGA == m_LGA)  //如果有東西就判斷他紀錄的值跟自己的名字是不是一樣，並且雙方的LGA也要一樣
            {
                colliderObject.transform.SetParent(this.gameObject.transform);                               //設定成自己的子物件並套用座標、旋轉
                colliderObject.transform.position = this.gameObject.transform.position;
                colliderObject.transform.rotation = this.gameObject.transform.rotation;
                colliderObject.GetComponent<Rigidbody>().isKinematic = true;                                   //解決設成子物件後物件會亂動，所以把他的Kinematic設定成true，要變成false在ObjectParent.cs上面有註解。
                hasPlace = true;                                                                               //確定物件都用好後，這格放置座標就設定有放置物件了。
            }
        }
    }
    void Cpu_Fan_ObjectTransform()
    {
        if (colliderObject.GetComponent<CPU_Fan_Object>().firstColliderObject != null)
        {
            if (colliderObject.GetComponent<CPU_Fan_Object>().firstColliderObject.name == gameObject.name && colliderObject.GetComponent<CPU_Fan_Object>().cpuHasPlace == true)  
            {
                colliderObject.transform.SetParent(this.gameObject.transform);
                colliderObject.transform.position = this.gameObject.transform.position;
                colliderObject.transform.rotation = this.gameObject.transform.rotation;
                colliderObject.GetComponent<Rigidbody>().isKinematic = true;
                hasPlace = true;
            }
        }

    }
    void MotherBoard_ObjectTransform()
    {
        if (colliderObject.GetComponent<Mother_Board_Object>().firstColliderObject != null)                            //判斷碰撞物件上的ObjectParent中的firstCollider是不是有東西
        {
            if (colliderObject.GetComponent<Mother_Board_Object>().firstColliderObject.name == this.gameObject.name)  //如果有東西就判斷他紀錄的值跟自己的名字是不是一樣
            {
                colliderObject.transform.SetParent(this.gameObject.transform);                               //設定成自己的子物件並套用座標、旋轉
                colliderObject.transform.position = this.gameObject.transform.position;
                colliderObject.transform.rotation = this.gameObject.transform.rotation;
                colliderObject.GetComponent<Rigidbody>().isKinematic = true;                                   //解決設成子物件後物件會亂動，所以把他的Kinematic設定成true，要變成false在ObjectParent.cs上面有註解。
                hasPlace = true;
            }
        }

    }

    void GraphicsCard_ObjectTransform()
    {
        if (colliderObject.GetComponent<GraphicsCard_Object>().firstColliderObject != null)                            //判斷碰撞物件上的ObjectParent中的firstCollider是不是有東西
        {
            if (colliderObject.GetComponent<GraphicsCard_Object>().firstColliderObject.name == this.gameObject.name)  //如果有東西就判斷他紀錄的值跟自己的名字是不是一樣
            {
                colliderObject.transform.SetParent(this.gameObject.transform);                               //設定成自己的子物件並套用座標、旋轉
                colliderObject.transform.position = this.gameObject.transform.position;
                colliderObject.transform.rotation = this.gameObject.transform.rotation;
                colliderObject.GetComponent<Rigidbody>().isKinematic = true;                                   //解決設成子物件後物件會亂動，所以把他的Kinematic設定成true，要變成false在ObjectParent.cs上面有註解。
                hasPlace = true;
            }
        }
    }

    void Memory_ObjectTransform()
    {
        if (colliderObject.GetComponent<Memory_Object>().firstColliderObject != null)                            //判斷碰撞物件上的ObjectParent中的firstCollider是不是有東西
        {
            if (colliderObject.GetComponent<Memory_Object>().firstColliderObject.name == this.gameObject.name)  //如果有東西就判斷他紀錄的值跟自己的名字是不是一樣
            {
                colliderObject.transform.SetParent(this.gameObject.transform);                               //設定成自己的子物件並套用座標、旋轉
                colliderObject.transform.position = this.gameObject.transform.position;
                colliderObject.transform.rotation = this.gameObject.transform.rotation;
                colliderObject.GetComponent<Rigidbody>().isKinematic = true;                                   //解決設成子物件後物件會亂動，所以把他的Kinematic設定成true，要變成false在ObjectParent.cs上面有註解。
                hasPlace = true;
            }
        }
    }
    void Power_ObjectTransform()
    {
        if (colliderObject.GetComponent<Power_Object>().firstColliderObject != null)                            //判斷碰撞物件上的ObjectParent中的firstCollider是不是有東西
        {
            if (colliderObject.GetComponent<Power_Object>().firstColliderObject.name == this.gameObject.name)  //如果有東西就判斷他紀錄的值跟自己的名字是不是一樣
            {
                colliderObject.transform.SetParent(this.gameObject.transform);                               //設定成自己的子物件並套用座標、旋轉
                colliderObject.transform.position = this.gameObject.transform.position;
                colliderObject.transform.rotation = this.gameObject.transform.rotation;
                colliderObject.GetComponent<Rigidbody>().isKinematic = true;                                   //解決設成子物件後物件會亂動，所以把他的Kinematic設定成true，要變成false在ObjectParent.cs上面有註解。
                hasPlace = true;
            }
        }
    }
    void SSD_ObjectTransform()
    {
        if (colliderObject.GetComponent<SSD_Object>().firstColliderObject != null)                            //判斷碰撞物件上的ObjectParent中的firstCollider是不是有東西
        {
            if (colliderObject.GetComponent<SSD_Object>().firstColliderObject.name == this.gameObject.name)  //如果有東西就判斷他紀錄的值跟自己的名字是不是一樣
            {

                colliderObject.transform.SetParent(this.gameObject.transform);                               //設定成自己的子物件並套用座標、旋轉
                colliderObject.transform.position = this.gameObject.transform.position;
                colliderObject.transform.rotation = this.gameObject.transform.rotation;
                colliderObject.GetComponent<Rigidbody>().isKinematic = true;                                   //解決設成子物件後物件會亂動，所以把他的Kinematic設定成true，要變成false在ObjectParent.cs上面有註解。
                hasPlace = true;
                Debug.Log("SSD放置");
            }
        }
    }
    //預設的物件座標函示，如果沒有特別設定的物件會統一使用這個。
    void ObjectTransform()
    {

        if (colliderObject.GetComponent<ObjectParent>().firstColliderObject != null)                            //判斷碰撞物件上的ObjectParent中的firstCollider是不是有東西
        {

            if (colliderObject.GetComponent<ObjectParent>().firstColliderObject.name == this.gameObject.name)  //如果有東西就判斷他紀錄的值跟自己的名字是不是一樣
            {

                colliderObject.transform.SetParent(this.gameObject.transform);                               //設定成自己的子物件並套用座標、旋轉
                colliderObject.transform.position = this.gameObject.transform.position;
                colliderObject.transform.rotation = this.gameObject.transform.rotation;
                colliderObject.GetComponent<Rigidbody>().isKinematic = true;                                   //解決設成子物件後物件會亂動，所以把他的Kinematic設定成true，要變成false在ObjectParent.cs上面有註解。
                hasPlace = true;
            }
        }


    }



}
