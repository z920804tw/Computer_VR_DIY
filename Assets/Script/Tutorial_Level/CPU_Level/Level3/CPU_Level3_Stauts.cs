using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPU_Level3_Stauts : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("關卡設定")]
    public Level_Select l;
    [SerializeField] GameObject[] MenuPanels;
    [SerializeField] GameObject[] Pictures;
    [SerializeField] int status;

    [Header("物件設定")]
    public GameObject CPU_Fan;
    public GameObject CPU_Thermal_GameObject;

    public GameObject[] pages;
    public GameObject[] fanBrackets;
    public Object_Transform[] objectsTransform;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (status)
        {
            case 0:                                     //開始頁面
                MenuPanels[0].SetActive(true);
                break;
            case 1:                                     //塔扇的介紹，會有1-1跟1-2
                MenuPanels[1].SetActive(true);
                l.closeAllPicture(Pictures);
                if (pages[0].activeSelf)
                {
                    Pictures[0].SetActive(true);
                }
                else if (pages[1].activeSelf)
                {
                    Pictures[1].SetActive(true);
                }



                break;
            case 2:                                     //塔扇的安裝，會有2-1、2-2。 2-2會要求使用者先將塔扇背面扣具拿在手中
                MenuPanels[2].SetActive(true);
                if (pages[2].activeSelf)
                {
                    Pictures[2].SetActive(true);
                    if (fanBrackets[0].GetComponent<FanBracket_Object>().isHolding)
                    {
                        NextStatus();
                    }
                }

                break;
            case 3:                                     //要安裝塔扇的基本固定架，包含主機板背面、CPU上下兩個固定架。
                MenuPanels[3].SetActive(true);
                Pictures[3].SetActive(true);
                if (objectsTransform[0].hasPlace && objectsTransform[1].hasPlace && objectsTransform[2].hasPlace)
                {
                    NextStatus();
                }
                break;
            case 4:                                     //塗抹散熱膏
                MenuPanels[4].SetActive(true);
                Pictures[4].SetActive(true);
                if (CPU_Thermal_GameObject.activeSelf)
                {
                    NextStatus();
                }
                break;
            case 5:
                MenuPanels[5].SetActive(true);          //安裝塔扇
                Pictures[5].SetActive(true);
                if (objectsTransform[3].hasPlace)
                {
                    NextStatus();
                }
                break;
            case 6:                                     //風扇零件安裝
                MenuPanels[6].SetActive(true);
                Pictures[6].SetActive(true);
                if (objectsTransform[4].hasPlace)
                {
                    NextStatus();
                }
                break;
            case 7:                                     //最後總結
                MenuPanels[7].SetActive(true);
                break;

        }
    }


    public void NextStatus()
    {
        if (l != null)
        {
            l.closeAllUI(MenuPanels);
            l.closeAllPicture(Pictures);
        }
        status++;
    }
}
