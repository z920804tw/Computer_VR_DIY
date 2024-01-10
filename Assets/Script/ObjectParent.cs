using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ObjectParent : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject firstColliderObject;                                  //紀錄第一個碰撞的物件
    public GameObject[] ObjectsTransform;                                   //紀錄要該物件要放置的位置

    [Header("CPU腳位設定")]
    public int c_LGA;                                                       //CPU的腳位設定，如果不是cpu的物件不用去設定

    Rigidbody rb;                                                           //rb

    bool check;


    [SerializeField] bool isFirstCollider;                                  //判斷是否第一次碰撞
    void Start()
    {
        isFirstCollider=false;
        check=false;
        rb=this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other) {
        if(other.gameObject.tag==this.gameObject.tag){                  //判斷碰撞到的物體tag是否與自己的tag一致，如果一致就進到裡面

            if(isFirstCollider==false)                                  //判斷是否第一次碰撞
            {
                isFirstCollider=true;                                   //設定true，這樣就不會修改到第一次紀錄的值
                firstColliderObject=other.gameObject;                   //設定第一次碰撞物為碰撞到的物件
            }

        }
    }

    //用來重製這個物件的所有值，會在手柄放開時自動執行
    public void removeParent(){                                                    
        Debug.Log("重製物件");
        this.gameObject.transform.SetParent(null);                       //設定這個物件的子物件為null(會預設在根目錄下)
        rb.isKinematic=false;                                            //對應Object_Transform，這邊是關閉。

        if(firstColliderObject!=null)                                    //這個if判斷是要先判斷firstColliderObject是不是有東西
        {
            firstColliderObject.GetComponent<Object_Transform>().hasPlace=false;            //這個是要有東西才會去抓它裡面的Object_transform，並且把裡面的已經放置給他設成false。
            firstColliderObject=null;                                       
        }

        isFirstCollider=false;                                          //第一次碰撞=false

        if(check==true)
        {
            if(ObjectsTransform!=null)                                      //看放置座標陣列裡有沒有值，如果有才會執行
            {
                foreach(GameObject obj in ObjectsTransform)             //用foreach來把該陣列裡面的所有物件的Outline都關閉
                {

                    if(obj.GetComponent<Outline>()!=null)               //會先檢查這個物件有沒有Outline這個Component，如果有才會把他關閉，否則就什麼都不做
                    {
                        obj.GetComponent<Outline>().enabled=false;
                    }
                }
            }


            check=false;
        }
        
    }

    //跟上面的差不多，只是這個是把她打開
    public void showOutline(){
        if(check==false)
        {

            switch(this.gameObject.tag)
            {
                case "Cpu":
                showCpuOutline();
                break;
                

                default:
                showObjectOutline();
                break;
            }

            
        }
      
      
    }

    void showCpuOutline(){

            ObjectsTransform=GameObject.FindGameObjectsWithTag(this.gameObject.tag);                //每次抓取特定物件就會去抓跟這個物件tag一致的物件
            if(ObjectsTransform!=null)                                                 
            {
                

                foreach(GameObject obj in ObjectsTransform)
                {
                    if(obj.GetComponent<Outline>()!=null&& obj.GetComponent<Object_Transform>()!=null)               //會先檢查這個物件有沒有Outline這個Component，如果有才會把他關閉，否則就什麼都不做
                    {
                      
                        if(obj.GetComponent<Object_Transform>().m_LGA==c_LGA)
                        {
                                
                            obj.GetComponent<Outline>().OutlineColor=new Color(255f/255,208f/255,0f ,255f/255);
                        }
                        else
                        {
                            obj.GetComponent<Outline>().OutlineColor=Color.red;
                            
                        }

                        
                        

                    }
                    obj.GetComponent<Outline>().enabled=true;
                    
                }                                          
            
            }
            check=true;

    }
    void showObjectOutline(){

            ObjectsTransform=GameObject.FindGameObjectsWithTag(this.gameObject.tag);                //每次抓取特定物件就會去抓跟這個物件tag一致的物件
            if(ObjectsTransform!=null)                                                 
            {
                

                foreach(GameObject obj in ObjectsTransform)
                {
                    if(obj.GetComponent<Outline>()!=null)               //會先檢查這個物件有沒有Outline這個Component，如果有才會把他關閉，否則就什麼都不做
                    {

                        
                        obj.GetComponent<Outline>().enabled=true;
                    }
                    
                }                                          
            
            }
            check=true;

    }
}
