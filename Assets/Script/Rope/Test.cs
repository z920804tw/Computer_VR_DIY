using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject partPrefab, parentObject;


    [Range(1, 10)]
    public int length = 1;


    public float partDistance = 0.1f;



    public bool reset, spawn, snapFirst, snapLast;


    // Update is called once per frame
    void Update()
    {
        if (reset)
        {
            foreach (GameObject tmp in GameObject.FindGameObjectsWithTag("Player"))
            {

                Destroy(tmp);
            }
        }
        if(spawn){
            Spawn();
            spawn=false;
        }
    }

    public void Spawn()
    {
        int count = (int)(length / partDistance);
        for (int x = 0; x < count; x++)
        {
            GameObject tmp;
            tmp = Instantiate(partPrefab, new Vector3(transform.position.x, transform.position.y + partDistance * (x + 1), transform.position.z), Quaternion.identity, parentObject.transform);
            tmp.transform.eulerAngles=new Vector3(180,0,0);
            tmp.name = parentObject.transform.childCount.ToString();
            if (x == 0)
            {
                Destroy(tmp.GetComponent<CharacterJoint>());

                if(snapFirst){
                    tmp.GetComponent<Rigidbody>().constraints=RigidbodyConstraints.FreezeAll;
                }
            }
            else
            {
                tmp.GetComponent<CharacterJoint>().connectedBody = parentObject.transform.Find((parentObject.transform.childCount - 1).ToString()).GetComponent<Rigidbody>();
            }


        }

        if(snapLast){

            parentObject.transform.Find((parentObject.transform.childCount).ToString()).GetComponent<Rigidbody>().constraints=RigidbodyConstraints.FreezeAll;

        }

    }
}
