using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPU_Level2_Stauts : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] int status;
    [SerializeField] Level_Select l;
    [SerializeField] GameObject[] MenuPanels, Pictures;

    [SerializeField] GameObject CPU_Thermal_GameObject, pickUI;
    [SerializeField] GameObject Fan_Object;

    AudioSource audioSource;
    void Start()
    {
        audioSource = GameObject.Find("Camera Offset").GetComponent<AudioSource>();
        if (audioSource != null)
        {
            audioSource.volume = Menu.guideVolume;
        }
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
                Pictures[0].SetActive(true);
                break;
            case 2:
                MenuPanels[2].SetActive(true);
                if (pickUI.activeSelf == true)
                {
                    Pictures[1].SetActive(true);
                    if (CPU_Thermal_GameObject.activeSelf == true)
                    {
                        NextStatus();
                    }
                }

                break;
            case 3:
                MenuPanels[3].SetActive(true);
                Pictures[2].SetActive(true);
                if (CPU_Thermal_GameObject == true && Fan_Object.GetComponent<Object_Transform>().hasPlace == true)
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
        foreach (GameObject i in Pictures)
        {
            i.SetActive(false);
        }

        status++;

    }


}
