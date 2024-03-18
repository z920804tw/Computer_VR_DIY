using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level_Select : MonoBehaviour
{
    // Start is called before the first frame update
    public Image LoadingBarImage;                           //讀取UI的進度條圖片
    public TextMeshProUGUI progressText;                    //讀取UI的進度文字
    public GameObject levelUI;                              //在這個程式碼中會去控制讀取UI的開關

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    //看我按鈕是按哪個
    public void SceneSelect()
    {
        string selected = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<TextMeshProUGUI>().text;   //會去取得當前按的按鈕的子物件TMP.text
        switch (selected)
        {
            case "返回大廳":                                //如果是返回大廳，就讀取大廳場景，反之就讀取這個關卡的場景
                StartCoroutine(asynSceneLoad("Program_Lobby"));
                break;
            case "重新一次":
                StartCoroutine(asynSceneLoad(SceneManager.GetActiveScene().name));
                break;
            default:
                Debug.Log("找不到關卡");
                break;

        }
    }
    //背景載入場景功能
    IEnumerator asynSceneLoad(string LevelName)
    {
        AsyncOperation scence = SceneManager.LoadSceneAsync(LevelName);     //用背景載入的方式來讀取，這樣不會讓程式有卡頓。
        //levelStauts.closeAllUI();                                           //關閉全部UI
        levelUI.SetActive(true);                                            //打開讀取UI
        while (scence.isDone != true)                                       //判斷場景有沒有被載入完成，如果還沒就繼續更新進度條，如果載入完成就補到100%並自動切換場景。
        {
            progressText.text = $"關卡載入進度 {scence.progress * 100}%";
            LoadingBarImage.fillAmount = scence.progress;
            if (scence.progress >= 0.9f)
            {
                progressText.text = $"關卡載入進度 100%";
                LoadingBarImage.fillAmount = 1f;
            }
            yield return null;

        }

    }

    public void closeAllUI(GameObject[] MenuPanels)
    {
        if (MenuPanels != null)
        {
            foreach (GameObject i in MenuPanels)
            {
                i.SetActive(false);
            }
        }

    }


}
