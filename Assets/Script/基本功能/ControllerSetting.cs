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

        if (ContinuousMove == null && Teleportation == null)
        {
            ContinuousMove = GameObject.Find("Locomotion System").GetComponent<ActionBasedContinuousMoveProvider>();
            Teleportation = GameObject.Find("Locomotion System").GetComponent<TeleportationProvider>();
        }

        if (continuousTurnProvider == null && snapTurnProvider == null)
        {
            continuousTurnProvider = GameObject.Find("Locomotion System").GetComponent<ActionBasedContinuousTurnProvider>();
            snapTurnProvider = GameObject.Find("Locomotion System").GetComponent<ActionBasedSnapTurnProvider>();
        }


    }

    private void Start()
    {
        if (move != null && turn != null)
        {
            move.value = moveIndex;
            turn.value = turnIndex;
        }


        if (continuousTurnProvider != null && snapTurnProvider != null && ContinuousMove != null && Teleportation != null)
        {
            setMoveMode(moveIndex);
            setTurnMode(turnIndex);

            //setMoveMode1(moveIndex);


        }
        else
        {
            Debug.Log("找不到snap or move");
        }
    }

    // Update is called once per frame

    /* public void setMoveMode()
     {
         string Option = move.options[move.value].text;

         switch (Option)
         {
             case "持續移動":
                 ContinuousMove.enabled = true;
                 Teleportation.enabled = false;
                 XRcontroller.enableInputActions = false;
                 moveIndex = 0;
                 break;
             case "定點移動":
                 ContinuousMove.enabled = false;
                 Teleportation.enabled = true;
                 XRcontroller.enableInputActions = true;
                 moveIndex = 1;
                 break;

             default:
                 Debug.Log("123");
                 break;
         }
     }
     void setMoveMode1(int i)
     {
         switch (i)
         {
             case 0:
                 ContinuousMove.enabled = true;
                 Teleportation.enabled = false;
                 XRcontroller.enableInputActions = false;
                 break;
             case 1:
                 ContinuousMove.enabled = false;
                 Teleportation.enabled = true;
                 XRcontroller.enableInputActions = true;
                 break;
         }
     }*/


    public void setMoveMode(int i)
    {
        if (ContinuousMove != null && Teleportation != null)
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

    }
    public void setTurnMode(int i)
    {
        if (continuousTurnProvider != null && snapTurnProvider != null)
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
}
