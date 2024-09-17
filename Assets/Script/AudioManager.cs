using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource bgmAudioSource;
    public GameObject sfxAudioSource;
    public AudioSource sfxSwitchAudioSource;

    void Start()
    {
        PlayBGM();
    }

    private void PlayBGM()
    {
        bgmAudioSource.Play();
    }

    public void PlaySFX(Vector3 spawnPosition)
    {
        GameObject.Instantiate(sfxAudioSource, spawnPosition, Quaternion.identity);
    }

    public void PlaySFXSwitch(Vector3 spawnPosition)
    {
        GameObject.Instantiate(sfxSwitchAudioSource, spawnPosition, Quaternion.identity);
    }
}
