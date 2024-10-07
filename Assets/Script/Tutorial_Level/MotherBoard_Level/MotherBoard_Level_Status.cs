using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherBoard_Level_Status : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Level_Select l;
    [SerializeField] int status = 0;

    [Header("UI設定")]
    [SerializeField] GameObject[] MenuPanels;
    [SerializeField] GameObject[] Pictures;
    [SerializeField] GameObject[] pages;

    [Header("物件設定")]

    [SerializeField] GameObject MotherBoard;
    [SerializeField] GameObject Mother_Board_Transform;
    [SerializeField] Object_Transform[] screw;




    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (status)
        {
            case 0:
                MenuPanels[0].SetActive(true);
                break;
            case 1:
                MenuPanels[1].SetActive(true);
                l.closeAllPicture(Pictures);
                if (pages[0].activeSelf == true)
                {
                    Pictures[0].SetActive(true);
                }
                else if (pages[1].activeSelf == true)
                {
                    Pictures[1].SetActive(true);
                }
                else if (pages[2].activeSelf == true)
                {
                    Pictures[2].SetActive(true);
                }
                break;
            case 2:
                MenuPanels[2].SetActive(true);
                if (pages[3].activeSelf == true)
                {
                    Pictures[3].SetActive(true);
                    if (MotherBoard.GetComponent<Mother_Board_Object>().isHolding == true)
                    {
                        NextStatus();
                    }
                }
                break;
            case 3:
                MenuPanels[3].SetActive(true);
                Pictures[4].SetActive(true);
                if (Mother_Board_Transform.GetComponent<Object_Transform>().hasPlace == true)
                {
                    NextStatus();
                }
                break;
            case 4:
                MenuPanels[4].SetActive(true);
                Pictures[5].SetActive(true);
                if (screw[0].hasPlace && screw[1].hasPlace && screw[2].hasPlace && screw[3].hasPlace && screw[4].hasPlace &&
                    screw[5].hasPlace && screw[6].hasPlace && screw[7].hasPlace)
                {
                    NextStatus();
                }
                break;
            case 5:
                MenuPanels[5].SetActive(true);
                break;
            default:
                Debug.Log("找不到");
                break;


        }
    }
    public void NextStatus()
    {
        if (l != null)
        {
            l.closeAllUI(MenuPanels);
            l.closeAllPicture(Pictures);
            GameObject.Find("Camera Offset").GetComponent<AudioSource>().Stop();
        }
        else
        {
            Debug.Log("123");
        }
        status++;
    }
}
