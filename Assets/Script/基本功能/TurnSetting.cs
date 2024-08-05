using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class TurnSetting : MonoBehaviour
{
    // Start is called before the first frame update
    ActionBasedSnapTurnProvider snapTurn;
    ContinuousTurnProviderBase continuousTurn;
    [Header("大廳用參數")]
    public TMP_Dropdown tMP_Dropdown;

    [Header("持續旋轉設定(大廳用)")]
    public GameObject continuousObject;
    public Slider continousSlider;
    public TMP_Text continuousValue;
    [Header("角度旋轉設定(大廳用)")]
    public GameObject snapTurnObject;
    public Slider snapSlider;
    public TMP_Text snapValue;

    int turnMode;
    void Start()
    {
        snapTurn = GetComponent<ActionBasedSnapTurnProvider>();
        continuousTurn = GetComponent<ContinuousTurnProviderBase>();

        turnMode = PlayerPrefs.GetInt("TurnMode");
        SetTurnMode(turnMode);
    }

    public void SetTurnMode(int i)
    {
        if (i == 0)                 //持續旋轉
        {
            turnMode = 0;
            SetTurnValue(PlayerPrefs.GetInt("ContinuousTurnValue"));
        }
        else if (i == 1)            //定點旋轉
        {
            turnMode = 1;

            SetTurnValue(PlayerPrefs.GetInt("SnapTurnValue"));
        }

    }
    public void SetTurnValue(float i)
    {
        if (turnMode == 0)
        {
            if (continuousObject != null)
            {
                continuousObject.SetActive(true);
                snapTurnObject.SetActive(false);
                
                continousSlider.value = i;
                continuousValue.text = i.ToString();
                tMP_Dropdown.value = 0;
            }
            continuousTurn.turnSpeed = i;
            snapTurn.turnAmount = 0;
            PlayerPrefs.SetInt("ContinuousTurnValue", (int)i);
            PlayerPrefs.SetInt("TurnMode", 0);
        }
        else if (turnMode == 1)
        {
            if (snapTurnObject != null)
            {
                continuousObject.SetActive(false);
                snapTurnObject.SetActive(true);

                snapSlider.value = i;
                snapValue.text = i.ToString();
                tMP_Dropdown.value = 1;
            }

            continuousTurn.turnSpeed = 0;
            snapTurn.turnAmount = i;
            PlayerPrefs.SetInt("SnapTurnValue", (int)i);
            PlayerPrefs.SetInt("TurnMode", 1);
        }
        PlayerPrefs.Save();
    }
}
