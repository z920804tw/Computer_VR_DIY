using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPU_Transform : MonoBehaviour
{
// Start is called before the first frame update
//這個跟Object_Transform一樣，但有腳位問題，所以多了個腳位的判斷
    public GameObject colliderObject;
    [Header("腳位")]
    public int LGA;
    
    //Transform objectRotation;
   // bool isParent;
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }



    private void OnTriggerStay(Collider other) {

        if(other.gameObject.tag==this.gameObject.tag)
        {
            
            

            if(other.GetComponent<CPU_Parent>().firstColliderObject!=null)
            {

                CPU_Parent colliderObject=other.gameObject.GetComponent<CPU_Parent>();
                
                if(colliderObject.firstColliderObject.name==this.gameObject.name && colliderObject.LGA==LGA)
                {
                        
                    other.transform.SetParent(this.gameObject.transform);
                    other.transform.position=this.gameObject.transform.position;
                    other.transform.rotation=this.gameObject.transform.rotation;
                        
                }
                

            }

        }
    }

}
