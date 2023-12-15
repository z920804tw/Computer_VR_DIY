using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ObjectParent : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject firstColliderObject;                                  //紀錄第一個碰撞的物件
    public GameObject[] ObjectsTransform;                                   //紀錄要該物件要放置的位置

    bool check;
    [SerializeField] bool isFirstCollider;                                  //判斷是否第一次碰撞
    void Start()
    {
        isFirstCollider=false;
        check=false;
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
        firstColliderObject=null;                                       //第一次碰撞值=null
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
            if(ObjectsTransform!=null)                                                 
            {
                
                ObjectsTransform=GameObject.FindGameObjectsWithTag(this.gameObject.tag);                //每次抓取特定物件就會去抓跟這個物件tag一致的物件
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
}
