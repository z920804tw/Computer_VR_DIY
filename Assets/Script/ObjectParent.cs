using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectParent : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject firstColliderObject;
    [SerializeField] bool isFirstCollider;
    void Start()
    {
        isFirstCollider=false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionStay(Collision other) {
        if(other.gameObject.tag==this.gameObject.tag)                 
        {   


        }


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

    public void removeParent(){
        Debug.Log("重製物件");
        this.gameObject.transform.parent = null;
        firstColliderObject=null;
        isFirstCollider=false;

    }
}
