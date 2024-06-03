using System;
using System.Collections;
using System.Data;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class Tutorial_LevelSelect : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Dropdown TD_LevelName;       //取的當前下拉清單
    public Image LoadingBarImage;           //讀取UI的圖片
    public TextMeshProUGUI progressText;    //讀取UI的文字

    public Menu LoadingUI;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SelectLevel()    //在關卡選擇某個零件後,會有下拉選單,這邊是給選好要的關卡後可以讀取的功能。
    {
        GameObject currentComponet = this.gameObject;                               //取得當前的componet所屬的物件
        string selectedLevelName = TD_LevelName.options[TD_LevelName.value].text;   //取得當前TMP_DP的所選值是甚麼
        Debug.Log(selectedLevelName);
        switch (currentComponet.name)                                               //去switch當前的componet物件名稱，如果是CPU就做CPU的事情...以此類推
        {
            case "CPU_Level":
                CPU_Level(selectedLevelName);
                break;
            case "HardDriver_Level":
                HardDriver_Level(selectedLevelName);
                break;
            case "Power_Level":
                Power_Level(selectedLevelName);
                break;

            case "MotherBoard_Level":
                MotherBoard_Level(selectedLevelName);
                break;

            case "Memory_Level":
                Memory_Level(selectedLevelName);
                break;

            case "GraphicsCard_Level":
                GraphicsCard_Level(selectedLevelName);
                break;


            default:
                Debug.Log("找不到關卡");
                break;

        }

    }
    //會傳入剛剛抓到的TMP_DP值，看當前是選哪個值，去讀取對應的關卡。
    void CPU_Level(string i)
    {
        switch (i)
        {
            case "CPU安裝關卡":
                StartCoroutine(LoadingLevel("CPU_Level1"));

                break;
            case "CPU風扇安裝關卡":
                StartCoroutine(LoadingLevel("CPU_Level2"));
                break;
            default:
                Debug.Log("目前找不到你所選的關卡");
                break;

        }

    }

    void GraphicsCard_Level(string i)
    {
        switch (i)
        {
            case "顯示卡安裝關卡(無供電)":
                StartCoroutine(LoadingLevel("GraphicsCrad_Level1"));
                break;
            case "顯示卡安裝關卡(有供電)":
                StartCoroutine(LoadingLevel("GraphicsCrad_Level2"));
                break;
            default:
                Debug.Log("目前找不到你所選的關卡");
                break;
        }

    }

    void Power_Level(string i)
    {
        switch (i)
        {
            case "電源供應器安裝關卡":
                StartCoroutine(LoadingLevel("Power_Level1"));
                break;
            default:
                Debug.Log("目前找不到你所選的關卡");
                break;
        }
    }
    void HardDriver_Level(string i)
    {
        switch (i)
        {
            case "機械硬碟安裝關卡":
                StartCoroutine(LoadingLevel("HardDriver_Level1"));
                break;
            case "固態硬碟(SATA SSD)安裝關卡":
                StartCoroutine(LoadingLevel("HardDriver_Level2"));
                break;
            case "M.2 SSD安裝關卡":
                StartCoroutine(LoadingLevel("HardDriver_Level3"));
                break;
            default:
                Debug.Log("目前找不到你所選的關卡");
                break;
        }
    }
    void Memory_Level(string i)
    {
        switch (i)
        {
            case "記憶體安裝關卡":
                StartCoroutine(LoadingLevel("Memory_Level1"));
                break;
            default:
                Debug.Log("目前找不到你所選的關卡");
                break;

        }
    }

    void MotherBoard_Level(string i)
    {
        switch (i)
        {
            case "主機板安裝關卡":
                StartCoroutine(LoadingLevel("MotherBoard_Level1"));
                break;
            default:
                Debug.Log("目前找不到你所選的關卡");
                break;
        }
    }
    //背景讀取關卡的協程
    IEnumerator LoadingLevel(string LevelName)
    {
        LoadingUI.closeAllUI();
        LoadingUI.MenuPanel[8].SetActive(true);
        AsyncOperation Scence = SceneManager.LoadSceneAsync(LevelName);
        //Scence.allowSceneActivation = false;
        while (Scence.isDone != true)
        {
            progressText.text = $"關卡載入進度 {Scence.progress * 100}%";
            LoadingBarImage.fillAmount = Scence.progress;
            Debug.Log(Scence.progress);
            if (Scence.progress >= 0.9f)
            {
                progressText.text = $"關卡載入進度 100%";
                LoadingBarImage.fillAmount = 1f;
            }

            yield return null;
        }

        //Scence.allowSceneActivation = true;
    }

}
