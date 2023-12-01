using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform objectTransform;
    public Transform object2Transform;

    bool isInstall;
    void Start()
    {   
        isInstall=false;
    }

    // Update is called once per frame
    void Update()
    {

        
        float distance= Vector3.Distance(objectTransform.position, object2Transform.position);
        if(distance<0.5f)
        {
            
            transform.position=object2Transform.position;
            transform.rotation=object2Transform.rotation;

            isInstall=true;
        }

       



    }
}
