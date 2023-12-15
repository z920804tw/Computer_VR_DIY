using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPU_Parent : MonoBehaviour
{
// Start is called before the first frame update

//這個跟ObjectParent一樣，只是這個物件要有腳位。
    public GameObject firstColliderObject;
    public GameObject[] ObjectsTransform;

    [Header("腳位")]
    public int LGA;

    bool check;
    [SerializeField] bool isFirstCollider;
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
                isFirstCollider=true;
                firstColliderObject=other.gameObject;                   //設定第一次碰撞物為碰撞到的物件
            }

        }
    }

    //重製這個物件所有的參數
    public void removeParent(){
        Debug.Log("重製物件");
        this.gameObject.transform.SetParent(null);
        firstColliderObject=null;
        isFirstCollider=false;
        if(check==true)
        {

            if(ObjectsTransform!=null)                                    
            {
           
                foreach(GameObject obj in ObjectsTransform)             
                {
                    if(obj.GetComponent<Outline>()!=null)               
                    {
                    obj.GetComponent<Outline>().enabled=false;
                    }
                }
            }
            check=false;
        }
        

    }

    //顯示相關物件的Outline
    public void showOutline(){

        if(check==false)
        {                                                  
            ObjectsTransform=GameObject.FindGameObjectsWithTag(this.gameObject.tag);
            if(ObjectsTransform!=null)                                                 
            {
                foreach(GameObject obj in ObjectsTransform)
                {
                    if(obj.GetComponent<Outline>()!=null)              
                    {
                        obj.GetComponent<Outline>().enabled=true;
                    }   
                }
            }
            check=true;

        }
       
    }
}
