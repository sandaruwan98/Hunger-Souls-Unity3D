using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySoundManager : MonoBehaviour
{

    public AudioClip[] attackClips;
    public AudioClip[] moveClips;
    public AudioClip[] dieClips;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayAttackSound()
    {
        int index = Random.Range(0, attackClips.Length);
        audioSource.clip = attackClips[index];
        audioSource.PlayOneShot(audioSource.clip);
    }
    public void PlayMoveSound()
    {
        if (!audioSource.isPlaying)
        {
            int index = Random.Range(0, moveClips.Length);
            audioSource.clip = moveClips[index];
            audioSource.PlayOneShot(audioSource.clip);
        }
        
    }
    public void PlayDieSound()
    {
        int index = Random.Range(0, dieClips.Length );
        audioSource.clip = dieClips[index];
        audioSource.PlayOneShot(audioSource.clip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
