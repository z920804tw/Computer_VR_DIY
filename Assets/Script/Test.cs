using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    //測試簡單的階段性劇本功能
    [Header("劇本狀態")]
    public int state = 1;
    public int finish_value=0;
    void Start()
    {
        Debug.Log("state is "+state);
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case 1:
                State1();
                break;
            case 2:
                State2();
                break;
            case 3:
                State3();
                break;

            default:
                State4();
                break;

        }
    }



    void State1()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            finish_value+=1;
            Debug.Log("finish_value is "+finish_value);
            
            if(finish_value==5){
                state++;
                Debug.Log("state is "+state);
                finish_value=0;
            }    
            
        }

    }
    void State2()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            finish_value+=1;
            Debug.Log("finish_value is "+finish_value);
            
            if(finish_value==5){
                state++;
                Debug.Log("state is "+state);
                finish_value=0;
            }    
        }
    }
    void State3()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            finish_value+=1;
            Debug.Log("finish_value is "+finish_value);
            
            if(finish_value==5){
                state++;
                Debug.Log("state is "+state);
                finish_value=0;
            }    
        }
    }
    void State4()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("final!");
        }
    }
}
