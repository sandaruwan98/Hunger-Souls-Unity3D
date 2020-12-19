using System.Collections;
using System.Collections.Generic;
using UnityEngine;


  
public class BgSound : MonoBehaviour
{

    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerManger.instance.isSeen)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.PlayDelayed(0.5f);
            }
        }
        else
        {
            audioSource.Pause();
        }
    }
}
