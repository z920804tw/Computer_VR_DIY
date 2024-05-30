using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ComputerDIY_Level_Status : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("雜項")]
    [SerializeField] int status;
    [SerializeField] Level_Select l;
    [SerializeField] GameObject[] MenuPanels;
    [SerializeField] GameObject CpuThermal;
    [SerializeField] GameObject ScrewDriver;

    int currentTransformIndex = 0;

    [Header("CPU物件設定")]
    [SerializeField] Object_Transform CPU_Transform;
    [SerializeField] Object_Transform CPU_Fan_Transform;
    [SerializeField] Object_Transform CPU_Fan_Cable_transform;

    [Space]
    [Header("記憶體物件設定")]
    [SerializeField] Object_Transform[] Memory_Transform;

    [Space]
    [Header("顯示卡物件設定")]
    [SerializeField] Object_Transform GraphicsCard_Transform;
    [SerializeField] Object_Transform[] GraphiscCard_Cable_Transform;

    [Space]
    [Header("主機板物件設定")]
    [SerializeField] Object_Transform MotherBoard_Transform;

    [Space]
    [Header("硬碟物件設定")]
    [SerializeField] Object_Transform M2_SSD_Transform;
    [SerializeField] Object_Transform HHD_Transform;
    [SerializeField] Object_Transform[] HardDriver_Cable_Transform;

    [Space]
    [Header("電源供應器物件設定")]
    [SerializeField] Object_Transform Power_Transform;
    [SerializeField] Object_Transform[] Cable_Transform;

    [Space]
    [Header("螺絲")]
    [SerializeField] Object_Transform[] MB_Screw__transform;
    [SerializeField] Object_Transform[] PW_Screw__transform;



    void Start()
    {

        currentTransformIndex = -1;
        //status = 0;


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
                if (CPU_Transform.hasPlace == true)
                {
                    NextStatus();
                }
                break;
            case 2:
                MenuPanels[2].SetActive(true);
                if (CpuThermal.activeSelf == true)
                {
                    if (CPU_Fan_Transform.hasPlace && CPU_Fan_Cable_transform.hasPlace)
                    {
                        NextStatus();
                    }
                }
                break;
            case 3:
                MenuPanels[3].SetActive(true);
                if (currentTransformIndex == -1)
                {
                    foreach (Object_Transform i in Memory_Transform)
                    {
                        if (i.hasPlace == true)
                        {
                            currentTransformIndex = Array.IndexOf(Memory_Transform, i);
                        }
                    }
                }
                else if (currentTransformIndex != -1)
                {
                    switch (currentTransformIndex)
                    {
                        case 0:
                        case 2:
                            Memory_Transform[1].gameObject.SetActive(false);
                            Memory_Transform[3].gameObject.SetActive(false);
                            checkIndex(currentTransformIndex);
                            break;
                        case 1:
                        case 3:
                            Memory_Transform[0].gameObject.SetActive(false);
                            Memory_Transform[2].gameObject.SetActive(false);
                            checkIndex(currentTransformIndex);
                            break;
                    }
                }
                break;
            case 4:
                MenuPanels[4].SetActive(true);
                ScrewDriver.GetComponentInChildren<Object_Transform>().screwType=ScrewType.Medium;
                if (M2_SSD_Transform.hasPlace && MB_Screw__transform[8].hasPlace)
                {
                    NextStatus();
                }
                break;
            case 5:
                MenuPanels[5].SetActive(true);
                ScrewDriver.GetComponentInChildren<Object_Transform>().screwType=ScrewType.Small;
                if (MotherBoard_Transform.hasPlace == true)
                {
                    if (MB_Screw__transform[0].hasPlace && MB_Screw__transform[1].hasPlace && MB_Screw__transform[2].hasPlace &&
                        MB_Screw__transform[3].hasPlace && MB_Screw__transform[4].hasPlace && MB_Screw__transform[5].hasPlace &&
                        MB_Screw__transform[6].hasPlace && MB_Screw__transform[7].hasPlace)
                    {
                        NextStatus();
                    }
                }
                break;
            case 6:
                MenuPanels[6].SetActive(true);
                ScrewDriver.GetComponentInChildren<Object_Transform>().screwType=ScrewType.Large;
                if (Power_Transform.hasPlace == true)
                {
                    if (PW_Screw__transform[0].hasPlace && PW_Screw__transform[1].hasPlace &&
                        PW_Screw__transform[2].hasPlace && PW_Screw__transform[3].hasPlace)
                    {
                        NextStatus();
                    }
                }
                break;
            case 7:
                MenuPanels[7].SetActive(true);
                if (GraphicsCard_Transform.hasPlace == true)
                {
                    if (GraphiscCard_Cable_Transform[0].hasPlace && GraphiscCard_Cable_Transform[1].hasPlace)
                    {
                        NextStatus();
                    }
                }
                break;
            case 8:
                MenuPanels[8].SetActive(true);
                if (HHD_Transform.hasPlace == true)
                {
                    if (HardDriver_Cable_Transform[0].hasPlace && HardDriver_Cable_Transform[1].hasPlace &&
                        HardDriver_Cable_Transform[2].hasPlace && HardDriver_Cable_Transform[3].hasPlace)
                    {
                        NextStatus();
                    }
                }
                break;
            case 9:
                MenuPanels[9].SetActive(true);
                if (Cable_Transform[0].hasPlace && Cable_Transform[1].hasPlace &&
                    Cable_Transform[2].hasPlace && Cable_Transform[3].hasPlace&&
                    Cable_Transform[4].hasPlace && Cable_Transform[5].hasPlace)
                {
                    NextStatus();
                }
                break;

            case 10:
                MenuPanels[10].SetActive(true);
                break;
            default:
                break;

        }
    }

    //記憶體用的,主要是用在雙通道功能偵測上
    void checkIndex(int index)
    {
        switch (index)
        {
            case 0:
                if (Memory_Transform[2].hasPlace == true)
                {
                    NextStatus();
                }
                break;

            case 1:
                if (Memory_Transform[3].hasPlace == true)
                {
                    NextStatus();
                }
                break;

            case 2:
                if (Memory_Transform[0].hasPlace == true)
                {
                    NextStatus();
                }
                break;

            case 3:
                if (Memory_Transform[1].hasPlace == true)
                {
                    NextStatus();
                }
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
            Debug.Log("找不到L");
        }
        status++;
    }
}
