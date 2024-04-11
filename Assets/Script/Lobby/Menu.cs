using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] MenuPanel;          //會用到的UI請放到這裡面。

    [Header("音量設定")]
    public Slider guideVolumeSlider;
    public AudioClip[] audioClips;
    public AudioSource audioSource;
    public static float guideVolume = 0.5f;

    void Start()
    {
        guideVolumeSlider.value = guideVolume;
        audioSource.volume = guideVolume;
    }

    // Update is called once per frame
    void Update()
    {

    }
    //主菜單按鈕用的功能,目前只有關卡選擇跟設定會用到
    public void MenuSelect()
    {
        string select = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<TextMeshProUGUI>().text;
        closeAllUI();
        switch (select)
        {
            case "關卡選擇":
                
                MenuPanel[1].SetActive(true);
                break;
            case "設定":
                
                MenuPanel[9].SetActive(true);
                break;
            case "音量設定":
                MenuPanel[10].SetActive(true);
                break;
            default:
                break;

        }
    }





    //TotlaLevelSelect裡面各個電腦零件的關卡選擇
    public void LevelChoose()
    {
        //EventSystem.current.currentSelectedGameObject是判斷我現在互動的那個按鈕，然後去取得他的子物件的text。
        string button = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<TextMeshProUGUI>().text;
        Debug.Log(button);
        if (button != null)
        {
            //先把MenuPanel的所有會用到的UI全部關閉
            closeAllUI();
            //去switch剛剛取得的互動按鈕裡的文字，根據零件名稱去開啟MenuPanel陣列裡對應的零件選擇關卡。
            switch (button)
            {
                case "處理器":
                    MenuPanel[2].SetActive(true);
                    break;
                case "電源供應器":
                    MenuPanel[3].SetActive(true);
                    break;
                case "硬碟":
                    MenuPanel[4].SetActive(true);
                    break;
                case "主機板":
                    MenuPanel[5].SetActive(true);
                    break;
                case "記憶體":
                    MenuPanel[6].SetActive(true);
                    break;
                case "顯示卡":
                    MenuPanel[7].SetActive(true);
                    break;
                default:
                    Debug.Log("123");
                    break;

            }
        }

    }

    //提供給返回按鈕用，原理跟上面的切換到關卡選擇差不多
    public void Back()
    {
        string current_click = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<TextMeshProUGUI>().text;


        if (current_click != null)
        {
            closeAllUI();
            switch (current_click)
            {
                case "返回主選單":
                    MenuPanel[0].SetActive(true);
                    break;
                case "返回關卡選擇":
                    MenuPanel[1].SetActive(true);
                    break;
                case "返回設定選單":
                    MenuPanel[9].SetActive(true);
                    break;

            }

        }


    }

    public void closeAllUI()
    {
        foreach (GameObject i in MenuPanel)
        {
            i.SetActive(false);
        }
    }

    public void testGuideVolume()
    {
        guideVolume = guideVolumeSlider.value;
        audioSource.volume = guideVolume;
        int rnd = UnityEngine.Random.Range(0,9);
        audioSource.PlayOneShot(audioClips[rnd]);
    }

}
