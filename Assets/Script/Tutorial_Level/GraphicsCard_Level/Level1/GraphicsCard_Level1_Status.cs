using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicsCard_Level1_Status : MonoBehaviour
{
    // Start is called before the first frame update
    public int status = 0;
    public Level_Select l;
    [SerializeField] GameObject[] MenuPanels, Pictures, pages;

    [SerializeField] GameObject GraphicsCard;
    [SerializeField] Object_Transform GraphicsCard_Transform;

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
                if (pages[0].activeSelf == true)
                {
                    l.closeAllPicture(Pictures);
                    Pictures[0].SetActive(true);
                }
                else if (pages[1].activeSelf)
                {
                    l.closeAllPicture(Pictures);
                    Pictures[1].SetActive(true);
                }
                break;
            case 2:
                MenuPanels[2].SetActive(true);
                if (pages[2].activeSelf == true)
                {
                    Pictures[2].SetActive(true);
                    if (GraphicsCard.GetComponent<GraphicsCard_Object>().isHolding == true)
                    {
                        NextStatus();

                    }
                }
                break;
            case 3:

                MenuPanels[3].SetActive(true);
                Pictures[3].SetActive(true);
                if (GraphicsCard_Transform.hasPlace == true)
                {

                    NextStatus();
                }
                break;
            case 4:
                MenuPanels[4].SetActive(true);
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
