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

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        isFirstCollider = false;
        isHolding = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (firstColliderObject != null && isHolding == false)
        {
            Physics.IgnoreCollision(firstColliderObject.GetComponent<Object_Transform>().colliderObj, GetComponent<BoxCollider>(), true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == this.gameObject.tag && other.gameObject.GetComponent<Object_Transform>() != null)
        {
            if (other.gameObject.GetComponent<Object_Transform>().hasPlace == false) //要先判斷該放置座標的hasPlace必須為false(上面沒東西)才能放置
            {
                Object_Transform obj = other.gameObject.GetComponent<Object_Transform>();
                if (isFirstCollider == false && obj.m_FanBracketType == this.fanBracketType)
                {
                    firstColliderObject = other.gameObject;
                    isFirstCollider = true;
                }
            }

        }
    }



    public void showFanBracketOutline()
    {

        ObjectsTransform = GameObject.FindGameObjectsWithTag(this.gameObject.tag);
        foreach (GameObject obj in ObjectsTransform)
        {
            if (obj.GetComponent<Object_Transform>() != null && obj.GetComponent<Outline>() != null)
            {
                if (obj.GetComponent<Object_Transform>().m_FanBracketType == this.fanBracketType)
                {
                    obj.GetComponent<Outline>().enabled = true;
                }
            }
        }
        isHolding = true;

        this.gameObject.GetComponent<Outline>().enabled = true;

    }


    public void RemoveFanBracketSetting()
    {
        Debug.Log("重製風扇設定");
        isHolding = false;
        rb.isKinematic = false;
        anim.SetBool("place", false);

        this.gameObject.transform.SetParent(null);


        if (firstColliderObject != null)
        {
            firstColliderObject.GetComponent<Object_Transform>().hasPlace = false;
            Physics.IgnoreCollision(firstColliderObject.GetComponent<Object_Transform>().colliderObj, GetComponent<BoxCollider>(), false);
            firstColliderObject = null;
            isFirstCollider = false;
        }


        foreach (GameObject obj in ObjectsTransform)
        {
            if (obj.GetComponent<Outline>() != null)
            {
                obj.GetComponent<Outline>().enabled = false;
            }

        }


    }


}
