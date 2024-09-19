using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class MoveSetting : MonoBehaviour
{
    // Start is called before the first frame update
    ActionBasedController snapMove;
    ContinuousMoveProviderBase continuousMove;
    [Header("持續移動控制設定")]

    public TMP_Dropdown tMP_Dropdown;
    public TMP_Text text;
    public Slider slider;
    public GameObject moveObject;
    int moveMode;

    void Start()
    {
        snapMove = GameObject.Find("Left Ray Interactor(Teleport)").GetComponent<ActionBasedController>();
        continuousMove = GetComponent<ContinuousMoveProviderBase>();

        moveMode = PlayerPrefs.GetInt("MoveMode");
        SetMoveMode(moveMode);

    }


    public void SetMoveMode(int i)
    {
        moveMode = i;
        if (i == 0)                          //持續移動
        {
            SetMoveValue(PlayerPrefs.GetInt("ContinuousMoveValue"));
        }
        else if (i == 1)                     //定點移動
        {
            SetMoveValue(-1);
        }

    }

    public void SetMoveValue(float i)
    {
        if (moveMode == 0)
        {
            if (moveObject != null)
            {
                moveObject.SetActive(true);
                text.text = i.ToString();
                tMP_Dropdown.value = 0;
                slider.value = i;
            }
            snapMove.enableInputActions = false;
            continuousMove.moveSpeed = i;

            PlayerPrefs.SetInt("ContinuousMoveValue", (int)i);
            PlayerPrefs.SetInt("MoveMode", 0);
        }
        else if (moveMode == 1)
        {
            if (moveObject != null)
            {
                moveObject.SetActive(false);
                tMP_Dropdown.value = 1;
            }
            snapMove.enableInputActions = true;
            continuousMove.moveSpeed = 0;

            PlayerPrefs.SetInt("MoveMode", 1);
        }
        PlayerPrefs.Save();
    }
}
