using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardDriver_Level3_Status : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Level_Select l;
    [SerializeField] int status = 0;
    [SerializeField] GameObject HardDriver;
    [SerializeField] Object_Transform HardDriver_Transform, Screw_Transform;

    public GameObject[] MenuPanels,Pictures,pages;

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
                if (pages[0].activeSelf == true)
                {
                    Pictures[1].SetActive(true);
                    if (HardDriver.GetComponent<HardDriver_Object>().isHolding == true)
                    {
                        NextStatus();
                    }
                }
                break;
            case 3:
                MenuPanels[3].SetActive(true);
                Pictures[2].SetActive(true);
                if (HardDriver_Transform.hasPlace == true)
                {
                    NextStatus();
                }
                break;
            case 4:
                MenuPanels[4].SetActive(true);
                Pictures[3].SetActive (true);
                if (Screw_Transform.hasPlace == true)
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
            l.closeAllPicture(Pictures);
        }
        else
        {
            Debug.Log("123");
        }
        status++;
    }
}
