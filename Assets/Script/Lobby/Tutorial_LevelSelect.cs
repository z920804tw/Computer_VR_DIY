using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    public void SelectLevel()
    {
        GameObject currentComponet = this.gameObject;                               //取得當前的componet所屬的物件
        string selectedLevelName = TD_LevelName.options[TD_LevelName.value].text;   //取得當前TMP_DP的所選值是甚麼
        Debug.Log(selectedLevelName);
        switch (currentComponet.name)                                               //去switch當前的componet物件名稱，如果是CPU就做CPU的事情
        {
            case "CPU_Level":
                CPU_Level(selectedLevelName);
                break;
            case "HardDriver_Level":

                break;
            case "Power_Level":

                break;

            case "MotherBoard_Level":

                break;

            case "Memory_Level":

                break;

            case "GraphicsCard_Level":

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
