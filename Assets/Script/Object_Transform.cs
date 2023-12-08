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



    private void OnTriggerStay(Collider other) {

        if(other.gameObject.tag==this.gameObject.tag)
        {
            colliderObject=other.gameObject;


            if(other.GetComponent<ObjectParent>().firstColliderObject!=null)
            {
                if(other.GetComponent<ObjectParent>().firstColliderObject.name==this.gameObject.name )
                {
               // Debug.Log(colliderObject.name);
                other.transform.SetParent(this.gameObject.transform);
                other.transform.position=this.gameObject.transform.position;
                other.transform.rotation=this.gameObject.transform.rotation;


                }
            }



        }
    }

}
