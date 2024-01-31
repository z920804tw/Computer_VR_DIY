using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.Mathematics;
using UnityEditor.UIElements;
using UnityEngine;

public class Thermal_paste_Object : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    public bool isHolding;
    public Transform SpawnPos;
    public GameObject firstColliderObject;
    bool check;
    bool canSpawn;
    void Start()
    {
        isHolding = false;
        check = false;
        rb = this.gameObject.GetComponent<Rigidbody>();
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
                Debug.Log("456");
                canSpawn = true;
                firstColliderObject = other.gameObject;
            }
        }

    }

    public void SpawnThermalPaste()
    {
        if (canSpawn == true && firstColliderObject != null)
        {
            if(firstColliderObject.GetComponent<CPU_Object>()!=null){
                firstColliderObject.GetComponent<CPU_Object>().CpuThermal.SetActive(true);
            }
        }


    }

    public void Remove_ThermalPaste_Setting()
    {
        if (check == true)
        {
            this.gameObject.GetComponent<Outline>().enabled = false;
            firstColliderObject = null;
            canSpawn = false;
            isHolding=false;

        }
    }
    public void showCpuFansOutline()
    {
        if (check == false)
        {
            this.gameObject.GetComponent<Outline>().enabled = true;
            check = true;
            isHolding = true;
        }
    }
}