using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taunt : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] audioClips; // Assign 3 clips in the Inspector

    public float minDelay = 10f;
    public float maxDelay = 30f;

    void Start()
    {
        StartCoroutine(PlayRandomAudio());
    }

    IEnumerator PlayRandomAudio()
    {
        while (true)
        {
            float waitTime = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(waitTime);

            if (audioClips.Length > 0 && audioSource != null)
            {
                int index = Random.Range(0, audioClips.Length);
                audioSource.clip = audioClips[index];
                audioSource.Play();
            }
        }
    }
}