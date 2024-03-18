using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicsCard_Level1_Status : MonoBehaviour
{
    // Start is called before the first frame update
    public int status = 0;
    public Level_Select l;
    public GameObject[] MenuPanels;
    public GameObject pickUI;      //在2-2用的，防止2-1時使用者就拿起GPU導致直接跳過page2的內容
    [SerializeField] GameObject GraphicsCard;
    [SerializeField] GameObject GraphicsCard_Transform;
    [SerializeField] GameObject MotherBoard_Transform;


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
                break;
            case 2:
                MenuPanels[2].SetActive(true);
                if (pickUI.activeSelf == true)
                {
                    if (GraphicsCard.GetComponent<GraphicsCard_Object>().isHolding == true)
                    {
                        NextStatus();

                    }
                }
                break;
            case 3:

                MenuPanels[3].SetActive(true);
                if (GraphicsCard_Transform.GetComponent<Object_Transform>().hasPlace == true)
                {

                    NextStatus();
                }
                break;
            case 4:
                MenuPanels[4].SetActive(true);
                if (MotherBoard_Transform.GetComponent<Object_Transform>().hasPlace == true)
                {
                    NextStatus();
                }
                break;
            case 5:
                MenuPanels[5].SetActive(true);
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
