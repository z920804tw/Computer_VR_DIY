using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializationSetting : MonoBehaviour
{
    // Start is called before the first frame update

    void Awake()
    {
        if (PlayerPrefs.HasKey("isInitialization") == false)    //初始化，只會在第一次執行，或是有設定重製按鈕時會執行。
        {
            PlayerPrefs.SetInt("isInitialization",1);
            PlayerPrefs.SetFloat("guideVolume",0.2f);
            PlayerPrefs.SetFloat("bgVolume",0.15f);

            PlayerPrefs.SetInt("MoveMode",0);
            PlayerPrefs.SetFloat("ContinuousMoveValue",3);
            
            PlayerPrefs.SetInt("TurnMode",0);
            
            PlayerPrefs.Save();
            Debug.Log("123");
        }
        
    }
}
