using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;
public class Setting : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("關聯物件設定")]
    public GameObject SettingMenu;
    public GameObject[] Menu;
    public GameObject SettingMenuPos;
    public Transform camR;
    [Header("音量設定")]
    public Slider guideVolumeSlider;
    public AudioClip[] audioClips;
    public AudioSource audioSource;

    [Header("VR按鈕設定")]
    public InputActionReference OpenMenu;
    

    static float guideVolume=0.5f;

    InputAction Action;

    bool settingMenuOpen;



    void Start()
    {
        guideVolumeSlider.value=guideVolume;
        audioSource.volume=guideVolume;
        settingMenuOpen = false;
        Action = OpenMenu;
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

    public  void SwitchMenu(){
        string currentBtn=EventSystem.current.currentSelectedGameObject.GetComponentInChildren<TextMeshProUGUI>().text;
        closeAllSettingMenu();
        switch(currentBtn){
            case "音量設定":
                Menu[1].SetActive(true);
            break;
            case "返回設定選單":
                Menu[0].SetActive(true);
            break;
            default:
            break;
        }
    }
    public void closeMenu(){
        closeAllSettingMenu();
        Menu[0].SetActive(true);
        SettingMenu.SetActive(false);
        settingMenuOpen=false;

    }
    public void closeAllSettingMenu(){
        foreach( GameObject i in Menu){
            i.SetActive(false);
        }
    }
    public void testGuideVolume(){
        guideVolume=guideVolumeSlider.value;
        audioSource.volume=guideVolume;
        int rnd=Random.Range(0,9);
        audioSource.PlayOneShot(audioClips[rnd]);
    }


}
