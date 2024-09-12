using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("abc",2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void abc(){
            Debug.Log("123");
    }
}
