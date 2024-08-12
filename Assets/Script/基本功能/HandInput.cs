using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandInput : MonoBehaviour
{
    // Start is called before the first frame update

    public InputActionReference left, right;
    public InputActionProperty primaryButton, secondaryButton;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (primaryButton.action.WasPressedThisFrame())
        {
            Debug.Log("Primary被按下");
        }
        if (secondaryButton.action.WasPressedThisFrame())
        {
            Debug.Log("Secondary被按下");
        }
    }
}
