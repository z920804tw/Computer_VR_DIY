using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public enum FanBracketType
{
    None,
    Big,
    Med,
    Small,
}
public class FanBracket_Object : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("塔扇物件設定")]

    public Animator anim;
    public FanBracketType fanBracketType;
    public GameObject[] ObjectsTransform;
    [Header("Debug")]
    public GameObject firstColliderObject;
    public bool isHolding;
    [SerializeField] bool isFirstCollider;
    Rigidbody rb;
    bool check;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        check = false;
        isFirstCollider = false;
        isHolding = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == this.gameObject.tag && other.gameObject.GetComponent<Object_Transform>() != null)
        {
            Object_Transform obj = other.gameObject.GetComponent<Object_Transform>();
            if (isFirstCollider == false && obj.m_FanBracketType == this.fanBracketType)
            {
                firstColliderObject = other.gameObject;
                isFirstCollider = true;
            }
        }
    }



    public void showFanBracketOutline()
    {
        if (check == false)
        {
            ObjectsTransform = GameObject.FindGameObjectsWithTag(this.gameObject.tag);
            foreach (GameObject obj in ObjectsTransform)
            {
                if (obj.GetComponent<Object_Transform>().m_FanBracketType == this.fanBracketType)
                {
                    obj.GetComponent<Outline>().enabled = true;
                }

            }
        }
    }


    public void RemoveFanBracketSetting()
    {
        isHolding = false;
        this.gameObject.transform.SetParent(null);
        rb.isKinematic = false;
        anim.SetBool("place", false);
        if (firstColliderObject != null)
        {
            firstColliderObject.GetComponent<Object_Transform>().hasPlace = false;
            firstColliderObject = null;
            isFirstCollider = false;
        }

        if (check == true && ObjectsTransform != null)
        {
            foreach (GameObject obj in ObjectsTransform)
            {
                obj.GetComponent<Outline>().enabled = false;
            }
            check = false;
        }
    }
}
