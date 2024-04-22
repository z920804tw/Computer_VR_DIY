using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UIElements;

public class Object_Transform : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject colliderObject;
    Color currentOutlineColor;
    [Header("主機板腳位設定")]
    public int m_LGA;
    [Header("電纜設定")]
    public CableType T_cableType;
    public CableDirection T_cableDirection;
    [Header("螺絲設定")]
    public ScrewEnum screwEnum = ScrewEnum.None;
    public ScrewType screwType = ScrewType.None;

    [Header("硬碟設定")]
    public HardDriverType hardDriverType = HardDriverType.None;

    [Header("Debug")]
    public bool hasPlace;

    void Start()
    {
        hasPlace = false;
        currentOutlineColor = Color.red;
    }

    // Update is called once per frame



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
                        HardDriver_ObjectTransform();
                        break;

                    case "Cable":
                        Cable_ObjectTransform();
                        break;

                    case "Screw":
                        Screw_ObjectTransform();
                        break;
                    default:
                        //ObjectTransform();
                        Debug.Log("找不到");
                        break;

                }

            }


        }
    }

    void place()
    {
        colliderObject.GetComponent<Animator>().enabled=false;   //如果不把動畫控制器關掉,他會浮空。
        hasPlace = true;
    }
    //CPU用的，主要多了CPU跟主機板的LGA腳位判斷
    void CPU_ObjectTransform()
    {
        CPU_Object cpuObj = colliderObject.GetComponent<CPU_Object>();
        if (cpuObj.firstColliderObject != null && cpuObj.isHolding == false)
        {
            if (cpuObj.firstColliderObject.name == this.gameObject.name && cpuObj.c_LGA == m_LGA)  //如果有東西就判斷他紀錄的值跟自己的名字是不是一樣，並且雙方的LGA也要一樣
            {
                
                colliderObject.transform.SetParent(this.gameObject.transform);                               //設定成自己的子物件並套用座標、旋轉
                colliderObject.transform.position = this.gameObject.transform.position;
                colliderObject.transform.rotation = this.gameObject.transform.rotation;
                colliderObject.GetComponent<Rigidbody>().isKinematic = true;                                   //解決設成子物件後物件會亂動，所以把他的Kinematic設定成true，要變成false在ObjectParent.cs上面有註解。
                cpuObj.anim.SetBool("place",true);                                                           //執行放置的動畫
                Invoke("place", 2.1f);
            }
        }
    }
    void Cpu_Fan_ObjectTransform()
    {
        CPU_Fan_Object cpuFanObj = colliderObject.GetComponent<CPU_Fan_Object>();
        if (cpuFanObj.firstColliderObject != null && cpuFanObj.isHolding == false)
        {
            if (cpuFanObj.firstColliderObject.name == gameObject.name && cpuFanObj.cpuHasPlace)
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
        Mother_Board_Object motherboardObj = colliderObject.GetComponent<Mother_Board_Object>();
        if (motherboardObj.firstColliderObject != null && motherboardObj.isHolding == false)                            //判斷碰撞物件上的ObjectParent中的firstCollider是不是有東西
        {
            if (motherboardObj.firstColliderObject.name == this.gameObject.name)  //如果有東西就判斷他紀錄的值跟自己的名字是不是一樣
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
        GraphicsCard_Object graphicsObj = colliderObject.GetComponent<GraphicsCard_Object>();
        if (graphicsObj.firstColliderObject != null && graphicsObj.isHolding == false)                            //判斷碰撞物件上的ObjectParent中的firstCollider是不是有東西
        {
            if (graphicsObj.firstColliderObject.name == this.gameObject.name)  //如果有東西就判斷他紀錄的值跟自己的名字是不是一樣
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
        Memory_Object memoryObj = colliderObject.GetComponent<Memory_Object>();
        if (memoryObj.firstColliderObject != null && memoryObj.isHolding == false)                            //判斷碰撞物件上的ObjectParent中的firstCollider是不是有東西
        {
            if (memoryObj.firstColliderObject.name == this.gameObject.name)  //如果有東西就判斷他紀錄的值跟自己的名字是不是一樣
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
        Power_Object powerObj = colliderObject.GetComponent<Power_Object>();
        if (powerObj.firstColliderObject != null && powerObj.isHolding == false)                            //判斷碰撞物件上的ObjectParent中的firstCollider是不是有東西
        {
            if (powerObj.firstColliderObject.name == this.gameObject.name)  //如果有東西就判斷他紀錄的值跟自己的名字是不是一樣
            {
                colliderObject.transform.SetParent(this.gameObject.transform);                               //設定成自己的子物件並套用座標、旋轉
                colliderObject.transform.position = this.gameObject.transform.position;
                colliderObject.transform.rotation = this.gameObject.transform.rotation;
                colliderObject.GetComponent<Rigidbody>().isKinematic = true;                                   //解決設成子物件後物件會亂動，所以把他的Kinematic設定成true，要變成false在ObjectParent.cs上面有註解。
                hasPlace = true;
            }
        }
    }
    void HardDriver_ObjectTransform()
    {
        HardDriver_Object hard_driverObj = colliderObject.GetComponent<HardDriver_Object>();
        if (hard_driverObj.firstColliderObject != null && hard_driverObj.isHolding == false)                            //判斷碰撞物件上的ObjectParent中的firstCollider是不是有東西
        {
            if (hard_driverObj.firstColliderObject.name == this.gameObject.name)  //如果有東西就判斷他紀錄的值跟自己的名字是不是一樣
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

    void Cable_ObjectTransform()
    {
        Cable_Object cableObj = colliderObject.GetComponent<Cable_Object>();
        if (cableObj.firstColliderObject != null && cableObj.isHolding == false)
        {
            if (cableObj.firstColliderObject.name == this.gameObject.name)
            {

                if (cableObj.cableType == T_cableType && cableObj.cableDirection == T_cableDirection)
                {
                    colliderObject.transform.SetParent(this.gameObject.transform);
                    colliderObject.transform.position = this.gameObject.transform.position;
                    colliderObject.transform.rotation = this.gameObject.transform.rotation;
                    colliderObject.GetComponent<Rigidbody>().isKinematic = true;
                    hasPlace = true;
                }
            }
        }
    }
    void Screw_ObjectTransform()
    {
        Screw_Object screwObj = colliderObject.GetComponent<Screw_Object>();
        if (screwObj != null)
        {


            if (screwObj.firstColliderObject != null)
            {
                if (screwObj.screwEnum == screwEnum && screwObj.screwType == screwType)
                {
                    screwObj.firstColliderObject.GetComponent<Object_Transform>().hasPlace = false;
                    screwObj.firstColliderObject = this.gameObject;

                    colliderObject.transform.SetParent(this.gameObject.transform);
                    colliderObject.transform.position = this.gameObject.transform.position;
                    colliderObject.transform.rotation = this.gameObject.transform.rotation;
                    colliderObject.GetComponent<Rigidbody>().isKinematic = true;
                    hasPlace = true;
                    if (screwEnum == ScrewEnum.hold)
                    {

                        screwObj.screwEnum = ScrewEnum.place;
                        screwObj.showScrewOutline();

                        Debug.Log("現在接的是螺絲起子，螺絲更改成place");
                    }
                    else if (screwEnum == ScrewEnum.place)
                    {
                        screwObj.screwEnum = ScrewEnum.hold;
                        screwObj.removeScrewOutline();
                        Debug.Log("現在接的是螺絲Transform，螺絲更改成hold");

                    }
                }

            }

        }
    }
    /*void ObjectTransform()
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


    }*/



}
