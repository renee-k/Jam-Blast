using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager sInstance;
    public AudioSource buttons;
    public AudioClip click;
    public AudioClip button;
    
    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void TheVoice()
    {
        buttons.PlayOneShot (button);
    }
    public void Button()
    {
        buttons.PlayOneShot (click);
    }
}
