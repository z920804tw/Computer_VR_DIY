using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Event : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject[] sidePanels;
    public TMP_Dropdown T_dp;
    Dropdown item_dropdown;
    public GameObject[] cpu_items;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }






    public void CloseSidePanels(){
        sidePanels=GameObject.FindGameObjectsWithTag("SidePanels"); 
        if(sidePanels!=null)
        {
            foreach(GameObject panel in sidePanels)
            {
                panel.SetActive(false);
            }

        }
    }

    public void OpenSidePanels(){
        if(sidePanels!=null)
        {
            foreach(GameObject panel in sidePanels)
            {
                panel.SetActive(true);
            }

        }
    }

    public void SpawnItem(){

        GameObject selectItem=this.gameObject;
        switch(selectItem.name){
            case "CPU_Dropdown":
                string selectedItem=T_dp.options[T_dp.value].text;
                
                foreach(GameObject item in cpu_items)
                {
                    if(item.name==selectedItem)
                    {
                        Debug.Log("生成"+selectedItem);
                    }

                }

                break;
            case "GraphicsCard_Dropdown":
                Debug.Log("Item_2");
                break;
            default:
                Debug.Log("Error");
                break;
        }

    }
}
