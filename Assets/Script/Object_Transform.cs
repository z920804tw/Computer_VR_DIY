using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Transform : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject colliderObject;
    
    //Transform objectRotation;
   // bool isParent;
    
    void Start()
    {
        //isParent=false;
    }

    // Update is called once per frame
    void Update()
    {

    }



    //判斷碰撞偵測的物件，並把物件變成子物件
    private void OnTriggerStay(Collider other) {

        if(other.gameObject.tag==this.gameObject.tag)                                                   //判斷是否碰撞物件的tag是否與自己的tag一致
        {   
            if(other.GetComponent<ObjectParent>().firstColliderObject!=null)                            //判斷碰撞物件上的ObjectParent中的firstCollider是不是有東西
            {
                if(other.GetComponent<ObjectParent>().firstColliderObject.name==this.gameObject.name )  //如果有東西就判斷他紀錄的值跟自己的名字是不是一樣
                {
                        
                    other.transform.SetParent(this.gameObject.transform);                               //設定成自己的子物件並套用座標、旋轉
                    other.transform.position=this.gameObject.transform.position;
                    other.transform.rotation=this.gameObject.transform.rotation;
                        
                }
                

            }

        }
    }



}
