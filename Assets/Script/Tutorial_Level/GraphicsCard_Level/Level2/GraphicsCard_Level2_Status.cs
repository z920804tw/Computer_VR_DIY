using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicsCard_Level2_Status : MonoBehaviour
{
    // Start is called before the first frame update
    public int status = 0;


    [SerializeField] GameObject pickUI;
    [SerializeField] Level_Select l;
    [SerializeField] GameObject GraphicsCard;
    [SerializeField] GameObject GraphicsCard_Transform;
    [SerializeField] GameObject MotherBoard_Transform;
    [SerializeField] GameObject Power_Transform;
    [SerializeField] GameObject PCIE_P_Transform, PCIE_G_Transform;

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
                    if (GraphicsCard.GetComponent<GraphicsCard_Object>().isHolding == true)
                    {
                        NextStatus();
                    }
                }
                break;
            case 3:
                MenuPanels[3].SetActive(true);
                if(GraphicsCard_Transform.GetComponent<Object_Transform>().hasPlace==true){
                    NextStatus();
                }
                break;
            case 4:
                MenuPanels[4].SetActive(true);
                if(MotherBoard_Transform.GetComponent<Object_Transform>().hasPlace==true){
                    NextStatus();
                }
                break;
            case 5:
                MenuPanels[5].SetActive(true);
                if(Power_Transform.GetComponent<Object_Transform>().hasPlace==true){
                    NextStatus();
                }
                break;
            case 6:
                MenuPanels[6].SetActive(true);
                Object_Transform p=PCIE_P_Transform.GetComponent<Object_Transform>();
                Object_Transform g=PCIE_G_Transform.GetComponent<Object_Transform>();
                if(p.hasPlace==true&&g.hasPlace==true){
                    NextStatus();
                }
                break;
            case 7:
                MenuPanels[7].SetActive(true);
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
        }
        else
        {
            Debug.Log("123");
        }

        status++;

    }
}
