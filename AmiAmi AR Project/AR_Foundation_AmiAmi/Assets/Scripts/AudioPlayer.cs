using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    AudioSource audioSource;

    public AudioClip FigureSpawnSFX;
    public AudioClip FigureDespawnSFX;
    public AudioClip PhoneTapSFX;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playAudioClip(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }

    public void PlayFigureSpawnSFX()
    {
        audioSource.PlayOneShot(FigureSpawnSFX);
    }

    public void PlayFigureDespawnSFX()
    {
        audioSource.PlayOneShot(FigureDespawnSFX);
    }

    public void PlayPhoneTap()
    {
        audioSource.PlayOneShot(PhoneTapSFX);
    }

}
