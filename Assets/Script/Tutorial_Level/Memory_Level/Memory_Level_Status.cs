using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Memory_Level_Status : MonoBehaviour
{
    // Start is called before the first frame update


    [SerializeField] GameObject pickUI;

    [SerializeField] Level_Select l;
    [SerializeField] int currentTransformIndex;
    [SerializeField] int status = 0;
    [SerializeField] GameObject[] Memory;
    [SerializeField] GameObject[] Memory_Transform;
    public GameObject[] MenuPanels;
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
                    foreach (GameObject i in Memory)
                    {
                        if (i.GetComponent<Memory_Object>().isHolding == true)
                        {
                            NextStatus();
                        }
                    }
                }
                break;
            case 3:
                MenuPanels[3].SetActive(true);
                foreach (GameObject i in Memory_Transform)
                {
                    if (i.GetComponent<Object_Transform>().hasPlace == true)
                    {
                        currentTransformIndex = Array.IndexOf(Memory_Transform, i);
                        NextStatus();
                    }

                }
                break;
            case 4:
                MenuPanels[4].SetActive(true);
                switch (currentTransformIndex)
                {
                    case 0:
                    case 2:
                        Memory_Transform[1].SetActive(false);
                        Memory_Transform[3].SetActive(false);
                        checkIndex(currentTransformIndex);
                        break;
                    case 1:
                    case 3:
                        Memory_Transform[0].SetActive(false);
                        Memory_Transform[2].SetActive(false);
                        checkIndex(currentTransformIndex);
                        break;
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
        }
        else
        {
            Debug.Log("123");
        }
        status++;
    }

    void checkIndex(int i)
    {
        switch (i)
        {
            case 0:
                if (Memory_Transform[2].GetComponent<Object_Transform>().hasPlace == true)
                {
                    NextStatus();
                }
                break;
            case 1:
                if (Memory_Transform[3].GetComponent<Object_Transform>().hasPlace == true)
                {
                    NextStatus();
                }
                break;
            case 2:
                if (Memory_Transform[0].GetComponent<Object_Transform>().hasPlace == true)
                {
                    NextStatus();
                }
                break;
            case 3:
                if (Memory_Transform[1].GetComponent<Object_Transform>().hasPlace == true)
                {
                    NextStatus();
                }
                break;
        }
    }
}
