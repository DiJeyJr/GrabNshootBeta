using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sfx : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] clip;

    public void playSfx(AudioClip audioClip)
    {
        AudioSource audioInstance = Instantiate(audioSource, GameObject.FindGameObjectWithTag("Player").transform.position, Quaternion.identity);
        audioInstance.clip = audioClip;
        audioInstance.Play();
        Destroy(audioInstance.gameObject, audioInstance.clip.length);
    }
}
