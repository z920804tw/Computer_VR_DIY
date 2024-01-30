using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Thermal_paste_Object : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    public bool isHolding;
    public Transform SpawnPos;
    bool check;

    public GameObject ThermalPastePrefab;
    void Start()
    {
        isHolding = false;
        check=false;
        rb = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SpawnThermalPaste()
    {
        Instantiate(ThermalPastePrefab,SpawnPos.position,Quaternion.identity);

    }

    public void Remove_ThermalPaste_Setting(){
        if(check==true){
            this.gameObject.GetComponent<Outline>().enabled=false;

        }
    }
    public void showCpuFansOutline()
    {
        if (check == false)
        {
            this.gameObject.GetComponent<Outline>().enabled=true;
            check = true;
        }
    }
}
