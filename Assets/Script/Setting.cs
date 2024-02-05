using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;
using UnityEngine.InputSystem;
using Unity.Mathematics;
public class Setting : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject SettingMenu;
    public GameObject SettingMenuPos;
    public Transform camR;
    public InputActionReference testAction;
    InputAction Action;

    bool settingMenuOpen;



    void Start()
    {
        settingMenuOpen = false;
        Action = testAction;
        Action.performed += Test;
    }

    private void Test(InputAction.CallbackContext context)
    {

        if (settingMenuOpen == false)
        {
            Quaternion r=camR.rotation;
            SettingMenu.transform.rotation=Quaternion.Euler(0,r.eulerAngles.y,0);
            SettingMenu.transform.position = SettingMenuPos.transform.position;
            settingMenuOpen = true;
            SettingMenu.SetActive(true);
        }
        else
        {
            settingMenuOpen = false;
            SettingMenu.SetActive(false);
        }

    }




}
