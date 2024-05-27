using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerDIY_Level_Status : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int status;
    [SerializeField] Level_Select l;
    [SerializeField] GameObject[] MenuPanels;
    [Header("CPU物件設定")]
    [SerializeField] Object_Transform CPU_Transform;
    [SerializeField] Object_Transform CPU_Fan_Transform;
    [SerializeField] Object_Transform CPU_Fan_Cable_transform;

    [Space]
    [Header("記憶體物件設定")]
    [SerializeField] Object_Transform[] Memory_Transform;

    [Space]
    [Header("顯示卡物件設定")]
    [SerializeField] Object_Transform GraphicsCard_Transform;
    [SerializeField] Object_Transform[] GraphiscCard_Cable_Transform;
    
    [Space]
    [Header("主機板物件設定")]
    [SerializeField] Object_Transform MotherBoard_Transform;

    [Space]
    [Header("硬碟物件設定")]
    [SerializeField] Object_Transform M2_SSD_Transform;
    [SerializeField] Object_Transform HHD_Transform;
    [SerializeField] Object_Transform[] HardDriver_Cable_Transform;

    [Space]
    [Header("電源供應器物件設定")]
    [SerializeField] Object_Transform Power_Transform;
    [SerializeField] Object_Transform[] Cable_Transform;

    [Space]
    [Header("螺絲")]
    [SerializeField] Object_Transform[] MB_Screw__transform;
    [SerializeField] Object_Transform[] PW_Screw__transform;


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

    }
}
