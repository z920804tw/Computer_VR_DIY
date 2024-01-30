using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void showOutline(GameObject Object)
    {
        switch (Object.tag)
        {
            case "Cpu":
                //cpuOutline(Object);
                break;
        }

    }

    public void ResettingObject(GameObject Object){
        
        switch(Object.tag){
            case "Cpu":

            break;

        }
    }

    /*void cpuOutline(GameObject i)
    {
        var cpu_componet = i.GetComponent<CPU_Object>();
        if (cpu_componet.check == false)
        {
            cpu_componet.ObjectsTransform = GameObject.FindGameObjectsWithTag(i.tag);
            if (cpu_componet.ObjectsTransform != null)
            {
                foreach (GameObject obj in cpu_componet.ObjectsTransform)
                {
                    if (obj.GetComponent<Outline>() != null && obj.GetComponent<Object_Transform>() != null)
                    {
                        if (obj.GetComponent<Object_Transform>().m_LGA == cpu_componet.c_LGA)
                        {
                            obj.GetComponent<Outline>().OutlineColor = new Color(255f / 255, 208f / 255, 0f, 255f / 255);

                        }
                        else
                        {
                            obj.GetComponent<Outline>().OutlineColor = Color.red;

                        }
                    }
                    obj.GetComponent<Outline>().enabled = true;
                }
            }
            cpu_componet.isHolding = true;
            cpu_componet.check = true;
        }
    }*/
    


}
