using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SelectObjectOutline : MonoBehaviour
{
    [Header("手把設定")]            //設定手部模型和設限距離等等的功能
    public GameObject hand1;
    public GameObject hand2;
    public int RayDistance = 20;
    public LayerMask layerMask;

    [Header("互動功能")]            //設定輸入控制的地方
    public InputActionReference LeftHandgripInputActionReference;
    public InputActionReference RightHandgripInputActionReference;

    [Header("Debug")]               //Debug區域，這邊是用來看左右手設限是打到哪裡。
    [SerializeField] GameObject preObject1;
    [SerializeField] GameObject preObject2;
    GameObject hitObject1, hitObject2;

    Ray ray1, ray2;

    RaycastHit raycastHit1, raycastHit2;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()//會抓手柄有沒有握住，如果有握住就不會有設限出來。
    {
        float Lefthold = LeftHandgripInputActionReference.action.ReadValue<float>();
        float Righthold = RightHandgripInputActionReference.action.ReadValue<float>();
        //Debug.Log(hold);



        if (Lefthold == 0)
        {
            Hand1();
        }
        else { }


        if (Righthold == 0)
        {
            Hand2();
        }
        else { }


        //讓雙手只到某個物件就會有outline顯示出來

    }


    //2
    void Hand1()
    {


        ray1 = new Ray(hand1.transform.position, hand1.transform.forward);
        if (Physics.Raycast(ray1, out raycastHit1, RayDistance, layerMask))
        {
            if (preObject1 != null)   //如果設限直接射到下一個物件，會將上一個物件的Outline關掉
            {
                preObject1.GetComponent<Outline>().enabled = false;
            }

            hitObject1 = raycastHit1.collider.gameObject;

            if (hitObject1.GetComponent<Outline>() != null)
            {
                hitObject1.GetComponent<Outline>().enabled = true;
                preObject1 = hitObject1;

            }
        }
        else
        {
            if (hitObject1 != null)
            {
                hitObject1.GetComponent<Outline>().enabled = false;

            }
            hitObject1 = null;
            preObject1 = null;

        }
    }
    void Hand2()
    {
        ray2 = new Ray(hand2.transform.position, hand2.transform.forward);
        if (Physics.Raycast(ray2, out raycastHit2, 20, layerMask))
        {
            if (preObject2 != null)
            {
                preObject2.GetComponent<Outline>().enabled = false;
            }

            hitObject2 = raycastHit2.collider.gameObject;
            if (hitObject2.GetComponent<Outline>() != null)
            {
                hitObject2.GetComponent<Outline>().enabled = true;
                preObject2 = hitObject2;

            }
            //Debug.DrawRay(hand2.transform.position, raycastHit2.point - hand2.transform.position, Color.red);
        }
        else
        {
            if (hitObject2 != null)
            {
                hitObject2.GetComponent<Outline>().enabled = false;

            }
            hitObject2 = null;
            preObject2 = null;
        }
    }




}
