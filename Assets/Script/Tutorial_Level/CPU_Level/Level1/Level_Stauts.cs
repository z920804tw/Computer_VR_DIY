using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Stauts : MonoBehaviour
{
    // Start is called before the first frame update

    public int status = 0;
    public Level_Select l;
    public GameObject[] MenuPanels;

    public GameObject[] CPU_GameObject;
    public GameObject Mother_GameObject;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //會去看status的數字來進行現在劇情是到哪邊
        switch (status)
        {
            case 0:
                MenuPanels[0].SetActive(true);
                break;
            case 1:
                MenuPanels[1].SetActive(true);
                break;
            case 2:
                //CPU的安裝頁面，會去偵測CPU有沒有被玩家拿起，如果有就切換到下一個劇情。
                MenuPanels[2].SetActive(true);
                foreach (GameObject i in CPU_GameObject)
                {
                    if (i.GetComponent<CPU_Object>().isHolding == true)
                    {
                        NextStatus();
                    }
                }

                break;
            case 3:
                MenuPanels[3].SetActive(true);
                if (Mother_GameObject.GetComponent<Object_Transform>().hasPlace == true)
                {
                    NextStatus();
                }
                break;

            case 4:
                MenuPanels[4].SetActive(true);
                break;
            default:
                break;

        }
    }

    //切換下一個劇情進度的功能
    public void NextStatus()
    {

        if (l != null)
        {
            l.closeAllUI(MenuPanels);
        }
        else
        {
            Debug.Log("123");
        }

        status++;

    }

}
