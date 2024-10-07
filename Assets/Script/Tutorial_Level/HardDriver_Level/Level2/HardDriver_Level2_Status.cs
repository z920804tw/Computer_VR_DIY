using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardDriver_Level2_Status : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Level_Select l;
    [SerializeField] int status = 0;

    [Header("UI設定")]
    public GameObject[] MenuPanels;
    [SerializeField] GameObject[] Picture;
    [SerializeField] GameObject[] pages;

    [Header("物件參考設定")]
    [SerializeField] GameObject HardDriver;
    [SerializeField] Object_Transform HardDriver_Transform;
    [SerializeField] Object_Transform[] Cables_Transform;



    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (status)
        {
            case 0:                                                                     //開始介紹
                MenuPanels[0].SetActive(true);
                break;
            case 1:                                                                     //硬碟介紹 有1-1跟1-2
                MenuPanels[1].SetActive(true);
                Picture[0].SetActive(true);
                break;
            case 2:                                                                     //2-1硬碟安裝方式介紹 2-2是會要求使用者拿起硬碟
                MenuPanels[2].SetActive(true);
                if (pages[0].activeSelf == true)
                {
                    Picture[1].SetActive(true);
                    if (HardDriver.GetComponent<HardDriver_Object>().isHolding == true)
                    {
                        NextStatus();
                    }
                }
                break;
            case 3:                                                                     //要求使用者將硬碟放置到主機殼上的硬碟架上
                MenuPanels[3].SetActive(true);
                Picture[2].SetActive(true);
                if (HardDriver_Transform.hasPlace == true && HardDriver.GetComponent<HardDriver_Object>().isHolding == false)
                {
                    NextStatus();
                }
                break;
            case 4:                                                                     //要求使用者先安裝主板-硬碟的電源線安裝, 元素0跟1分別是主板的安裝位置跟硬碟的安裝位置。
                MenuPanels[4].SetActive(true);
                Picture[3].SetActive(true);
                if (Cables_Transform[0].hasPlace == true && Cables_Transform[1].hasPlace == true)
                {
                    NextStatus();
                }
                break;
            case 5:                                                                     //要求使用者安裝電源供應器-硬碟的電源線安裝,元素2跟3分別是電源供應器跟硬碟(PW)部分
                MenuPanels[5].SetActive(true);
                Picture[4].SetActive(true);
                if (Cables_Transform[2].hasPlace == true && Cables_Transform[3].hasPlace == true)
                {
                    NextStatus();
                }
                break;
            case 6:
                MenuPanels[6].SetActive(true);
                break;

        }


    }
    public void NextStatus()
    {
        if (l != null)
        {
            l.closeAllUI(MenuPanels);
            l.closeAllPicture(Picture);
            GameObject.Find("Camera Offset").GetComponent<AudioSource>().Stop();
        }
        else
        {
            Debug.Log("123");
        }
        status++;
    }
}