using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicsCard_Level2_Status : MonoBehaviour
{
    // Start is called before the first frame update
    public int status = 0;


    [SerializeField] Level_Select l;
    [SerializeField] GameObject GraphicsCard;
    [SerializeField] Object_Transform GraphicsCard_Transform;
    [SerializeField] Object_Transform[] PCIE_Transform;

    public GameObject[] MenuPanels, Pictures, pages;


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
                if (pages[0].activeSelf)
                {
                    Pictures[0].SetActive(true);
                }
                else if (pages[1].activeSelf)
                {
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
                if (GraphicsCard_Transform.GetComponent<Object_Transform>().hasPlace == true)
                {
                    NextStatus();
                }
                break;
            case 4:
                MenuPanels[4].SetActive(true);
                Pictures[4].SetActive(true);
                if (PCIE_Transform[0].hasPlace == true && PCIE_Transform[1].hasPlace == true)
                {
                    NextStatus();
                }
                break;
            case 5:
                MenuPanels[5].SetActive(true);
                break;
            default:
                Debug.Log("無選項");
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
