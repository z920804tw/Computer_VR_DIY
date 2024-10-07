using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CPU_Protect_Object : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Debug")]
    public bool isOpen;
    bool isChange;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Hands" && isChange == false)
        {
            if (other.transform.parent.GetComponent<HandInput>().triggerButton.action.WasPressedThisFrame())
            {
                Debug.Log("123");
                if (isOpen)
                {
                    anim.SetBool("open", false);
                }
                else
                {
                    anim.SetBool("open", true);
                }
                isChange=true;
                Invoke("ShellStatus", 1.3f);
            }
            GetComponent<Outline>().enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GetComponent<Outline>().enabled = false;
    }

    void ShellStatus()
    {
        isChange=false;
        isOpen = !isOpen;
    }

}
