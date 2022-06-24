using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Buttons : MonoBehaviour
{
    public static Buttons bInstance;
    public AudioSource sound;
    
    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void Sound()
    {
        sound.Play();
    }
}
