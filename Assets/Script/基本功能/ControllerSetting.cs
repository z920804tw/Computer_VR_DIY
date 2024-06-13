using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ControllerSetting : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("移動控制設定")]
    public ActionBasedContinuousMoveProvider ContinuousMove;
    public TeleportationProvider Teleportation;
    public ActionBasedController XRcontroller;

    [SerializeField] TMP_Dropdown move;         //大廳設定就好
    static int moveIndex = 0;

    [Header("旋轉控制設定")]
    public ActionBasedContinuousTurnProvider continuousTurnProvider;
    public ActionBasedSnapTurnProvider snapTurnProvider;
    [SerializeField] TMP_Dropdown turn;           //大廳設定就好
    static int turnIndex = 0;


    void Awake()
    {

        if (move != null && turn != null)
        {
            move.value=moveIndex;
            turn.value=turnIndex;
        }


        if (continuousTurnProvider != null && snapTurnProvider != null)
        {
            setMoveMode(moveIndex);
            setTurnMode(turnIndex);

        }


    }

    // Update is called once per frame


    public void setMoveMode(int i)
    {
        if (i == 0)
        {
            ContinuousMove.enabled = true;
            Teleportation.enabled = false;
            XRcontroller.enableInputActions = false;
            moveIndex = 0;

        }
        else if (i == 1)
        {
            ContinuousMove.enabled = false;
            Teleportation.enabled = true;
            XRcontroller.enableInputActions = true;
            moveIndex = 1;
        }
    }
    public void setTurnMode(int i)
    {
        if (i == 0)
        {
            continuousTurnProvider.enabled = true;
            snapTurnProvider.enabled = false;
            turnIndex = 0;
        }
        else if (i == 1)
        {
            continuousTurnProvider.enabled = false;
            snapTurnProvider.enabled = true;
            turnIndex = 1;
        }
    }
}
