using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SelectObjectOutline : MonoBehaviour
{
    [Header("手把設定")]            //設定手部模型和設限距離等等的功能
    public GameObject hand;
    public int RayDistance = 20;
    public LayerMask layerMask;


    [Header("互動功能")]            //設定輸入控制的地方
    public InputActionProperty handHold;
    [Header("Debug")]               //Debug區域，這邊是用來看左右手設限是打到哪裡。
    [SerializeField] GameObject preObject;






    // Start is called before the first frame update
    void Start()
    {
        hand = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (hand != null && handHold.action.ReadValue<float>() != 1)
        {
            HandRay();
        }

    }
    void HandRay()
    {
        Ray ray = new Ray(hand.transform.position, hand.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, RayDistance, layerMask))
        {
            if (preObject != null)
            {
                preObject.GetComponent<Outline>().enabled = false;
                preObject = null;
            }
            preObject = hit.collider.gameObject;
            hit.collider.gameObject.GetComponent<Outline>().enabled = true;
        }
        else
        {
            if (preObject != null)
            {
                preObject.GetComponent<Outline>().enabled = false;
                preObject = null;
            }
        }
    }

}
