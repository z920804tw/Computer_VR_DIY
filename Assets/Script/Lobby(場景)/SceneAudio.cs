using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SceneAudio : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] AudioSource inside, outside;
    [SerializeField] float outsideVolume, insideVolume;
    public float transitionDuration;

    GameObject currentPos;
    bool isTransitioning = false;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Inside")
        {
            currentPos = other.gameObject;
            inside.Play();
            StartCoroutine(transitionVolume());
            Debug.Log("室內");

            //outside.Pause();
            //inside.volume = 0.2f;
            //inside.Play();

        }
        else if (other.gameObject.name == "Outside")
        {
            currentPos = other.gameObject;
            outside.Play();
            StartCoroutine(transitionVolume());
            Debug.Log("室外");

            //inside.Pause();
            //outside.volume = audioVolume;
            //outside.Play();

        }
    }

    private IEnumerator transitionVolume()   //音樂的轉場效果
    {
        float timer = 0;
        if (isTransitioning == false)
        {
            isTransitioning = true;
            while (timer < transitionDuration)
            {
                timer += Time.deltaTime;
                float t = timer / transitionDuration;
                //Debug.Log(t);
                
                if (currentPos.name == "Inside")
                {
                    inside.volume = Mathf.Lerp(0, insideVolume, t);
                    outside.volume = Mathf.Lerp(outsideVolume, 0, t);
                    if (outside.volume == 0)
                    {
                        outside.Pause();
                    }
                }
                else if (currentPos.name == "Outside")
                {
                    outside.volume = Mathf.Lerp(0, outsideVolume, t);
                    inside.volume = Mathf.Lerp(insideVolume, 0, t);
                    if (inside.volume == 0)
                    {
                        inside.Pause();
                    }
                }
                yield return null;
            }


        }

        isTransitioning = false;
        Debug.Log("完成!");
    }

}
