using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject button1;
    
    bool isPressed = false;

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

        if (other.gameObject.tag == "Hands")
        {
            if (other.gameObject.name == "Left Controller")
            {

                float value = other.gameObject.GetComponent<HandInput>().left.action.ReadValue<float>();
                button1.GetComponent<Outline>().enabled = true;
                PressButton(value);
            }
            else if (other.gameObject.name == "Right Controller")
            {
                float value = other.gameObject.GetComponent<HandInput>().right.action.ReadValue<float>();
                button1.GetComponent<Outline>().enabled = true;
                PressButton(value);
            }

        }
    }
    private void OnTriggerExit(Collider other)
    {
        button1.GetComponent<Outline>().enabled = false;
    }


    void PressButton(float v)
    {
        if (v == 1 && isPressed == false)
        {
            isPressed = true;
            anim.SetBool("place", true);
            GameObject.Find("XR Origin (XR Rig)").GetComponent<SceneAudio>().testGuideVolume();
            Invoke("Reset", 1.3f);
        }
    }
    void Reset()
    {
        isPressed = false;
        anim.SetBool("place", false);
    }
    
}
