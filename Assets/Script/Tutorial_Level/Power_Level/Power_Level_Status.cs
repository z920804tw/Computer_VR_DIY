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
    [SerializeField] Object_Transform[] Screw_Transform,Soket_Transform;
    public GameObject[] MenuPanels;

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

                if (Screw_Transform[0].hasPlace == true && Screw_Transform[1].hasPlace == true && Screw_Transform[2].hasPlace == true && Screw_Transform[3].hasPlace == true)
                {
                    NextStatus();
                }
                break;
            case 5:
                MenuPanels[5].SetActive(true);
                if (Soket_Transform[0].hasPlace == true && Soket_Transform[1].hasPlace == true)
                {
                    NextStatus();
                }
                break;
            case 6:
                MenuPanels[6].SetActive(true);
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
