using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class SceneAudio : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("背景音量設定")]
    [SerializeField] AudioSource inside;
    [SerializeField] AudioSource outside;
    [SerializeField] float outsideVolume, insideVolume;
    public float transitionDuration;
    public static float bgVolume = 0.15f;


    GameObject currentPos;
    bool isTransitioning = false;


    [Header("引導音量設定")]
    public AudioClip[] audioClips;
    public AudioSource audioSource;
    [SerializeField] Slider guideVolumeSlider;
    [SerializeField] Slider bgVolumeSilder;
    public static float guideVolume = 0.5f;


    void Start()
    {
        //只會在大廳關卡執行,其他的不會。
        if (guideVolumeSlider != null && bgVolumeSilder != null)
        {
            guideVolumeSlider.value = guideVolume;
            bgVolumeSilder.value = bgVolume;
        }

        //設定引導的音量
        audioSource = GameObject.Find("Camera Offset").GetComponent<AudioSource>();
        if (audioSource != null)
        {
            audioSource.volume = guideVolume;

        }

        //設定背景音樂的音量
        inside = GameObject.Find("Inside").GetComponent<AudioSource>();
        outside = GameObject.Find("Outside").GetComponent<AudioSource>();
        if (inside != null && outside != null)
        {
            insideVolume = bgVolume;
            outsideVolume = bgVolume;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other) //進入室內跟室外的時候會執行以下的內容
    {
        if (other.gameObject.name == "Inside")
        {
            currentPos = other.gameObject;
            inside.Play();
            StartCoroutine(transitionVolume());
            Debug.Log("室內");

        }
        else if (other.gameObject.name == "Outside")
        {
            currentPos = other.gameObject;
            outside.Play();
            StartCoroutine(transitionVolume());
            Debug.Log("室外");

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

    public void testGuideVolume()       //給設定->音量設定裡面的引導音量測試按鈕用
    {
        guideVolume = guideVolumeSlider.value;
        audioSource.volume = guideVolume;
        int rnd = UnityEngine.Random.Range(0, 9);
        audioSource.PlayOneShot(audioClips[rnd]);
    }
    public void testBgVolume()          //給設定->音量設定裡面的背景音量測試按鈕用
    {
        bgVolume = bgVolumeSilder.value;
        //要立即改室內跟室外的音量
        //inside.volume=bgVolume;
        //outside.volume=bgVolume;
        insideVolume = bgVolume;
        outsideVolume = bgVolume;
        if (isTransitioning == false)
        {
            StartCoroutine(transitionVolume());
        }

    }

}
