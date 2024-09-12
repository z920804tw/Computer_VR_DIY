using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.Mathematics;

using UnityEngine;

public class Thermal_paste_Object : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("Debug")]
    public bool isHolding;
    public Transform SpawnPos;
    public GameObject firstColliderObject;



    bool canSpawn;
    void Start()
    {
        isHolding = false;


    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (isHolding == true)
        {
            if (other.gameObject.tag == "Cpu")
            {
                if (other.gameObject.GetComponent<CPU_Object>() != null)
                {
                    canSpawn = true;
                    firstColliderObject = other.gameObject;
                }

            }
        }

    }

    public void SpawnThermalPaste()
    {
        if (canSpawn == true && firstColliderObject != null)
        {
            if (firstColliderObject.GetComponent<CPU_Object>() != null)
            {
                firstColliderObject.GetComponent<CPU_Object>().CpuThermal.SetActive(true);
            }
        }


    }

    public void Remove_ThermalPaste_Setting()
    {

        Debug.Log("放開散熱高");
        this.gameObject.GetComponent<Outline>().enabled = false;
        firstColliderObject = null;

        canSpawn = false;
        isHolding = false;


    }
    public void showThermalOutline()
    {

        Debug.Log("拿起散熱高");
        this.gameObject.GetComponent<Outline>().enabled = true;

        isHolding = true;

    }
}
