using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAudio : MonoBehaviour
{
    [SerializeField]
    private AudioClip audioShot;
    [SerializeField]
    private AudioClip audioReload;
    [SerializeField]
    private AudioSource source;

    public void PlayShot()
    {
        source.PlayOneShot(audioShot);
    }

    public void PlayReload()
    {
        source.PlayOneShot(audioReload);
    }
}
