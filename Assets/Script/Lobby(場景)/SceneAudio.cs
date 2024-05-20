using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneAudio : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] AudioSource inside, outside;
    [SerializeField] float audioVolume;



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
            //StartCoroutine(increaseVolume(inside));
            //StartCoroutine(reduceVolume(outside));
            outside.Pause();
            inside.volume = 0.2f;
            inside.Play();
            Debug.Log("室內");
        }
        else if (other.gameObject.name == "Outside")
        {
            inside.Pause();
            //StartCoroutine(increaseVolume(outside));
            //StartCoroutine(reduceVolume(inside));
            outside.volume = audioVolume;
            outside.Play();
            Debug.Log("室外");
        }
    }

    private IEnumerator increaseVolume(AudioSource audio)
    {
        audio.Play();
        while (audio.volume < audioVolume)
        {

            audio.volume += 0.01f;

        }

        yield return 0;
    }

    private IEnumerator reduceVolume(AudioSource audio)
    {
        while (audio.volume > 0)
        {

            audio.volume -= 0.01f;

        }
        audio.Pause();
        yield return 0;
    }
}
