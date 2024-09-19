using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InitializationSetting : MonoBehaviour
{
    // Start is called before the first frame update

    void Awake()
    {
        if (PlayerPrefs.HasKey("isInitialization") == false)    //初始化，只會在第一次執行，或是有設定重製按鈕時會執行。
        {
            PlayerPrefs.SetInt("isInitialization", 1);                   //初始化參數設定
            PlayerPrefs.SetFloat("guideVolume", 0.2f);                   //引導音量設定
            PlayerPrefs.SetFloat("bgVolume", 0.15f);                     //背景音樂設定

            PlayerPrefs.SetInt("MoveMode", 0);                           //預設移動模式
            PlayerPrefs.SetInt("ContinuousMoveValue", 3);              //持續移動的參數

            PlayerPrefs.SetInt("TurnMode", 0);                           //預設旋轉模式
            PlayerPrefs.SetInt("ContinuousTurnValue", 60);               //預設旋轉參數(持續)
            PlayerPrefs.SetInt("SnapTurnValue", 45);                     //預設旋轉參數(角度)

            PlayerPrefs.Save();



            Debug.Log("初始化完成");
        }

    }
}
