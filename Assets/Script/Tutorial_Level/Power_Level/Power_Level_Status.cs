using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power_Level_Status : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject pickUI;
    [SerializeField] Level_Select l;
    [SerializeField] int status = 0;

    [SerializeField] GameObject Power_Transform;
    [SerializeField] GameObject Power;
    [SerializeField] GameObject[] Screw_Transform;
    public GameObject[] MenuPanels;


    Object_Transform screw1, screw2, screw3, scrwe4;   //到時候再階段4要拿來判斷4個螺絲有沒有鎖上用的

    void Start()
    {
        screw1 = Screw_Transform[0].GetComponent<Object_Transform>();
        screw2 = Screw_Transform[1].GetComponent<Object_Transform>();
        screw3 = Screw_Transform[2].GetComponent<Object_Transform>();
        scrwe4 = Screw_Transform[3].GetComponent<Object_Transform>();
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
                break;
            case 2:
                MenuPanels[2].SetActive(true);
                if (pickUI.activeSelf == true)
                {
                    if (Power.GetComponent<Power_Object>().isHolding == true)
                    {
                        NextStatus();
                    }
                }
                break;
            case 3:
                MenuPanels[3].SetActive(true);
                if (Power_Transform.GetComponent<Object_Transform>().hasPlace == true)
                {
                    NextStatus();
                }
                break;
            case 4:
                MenuPanels[4].SetActive(true);
                foreach (GameObject i in Screw_Transform)
                {
                    i.GetComponent<Outline>().enabled = true;
                }
                if(screw1.hasPlace==true && screw2.hasPlace == true && screw3.hasPlace == true && scrwe4.hasPlace == true)
                {
                    NextStatus();
                }
                break;
            case 5:
                MenuPanels[5].SetActive(true);
                break;
            default:
                Debug.Log("找不到目標");
                break;
        }

    }
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
