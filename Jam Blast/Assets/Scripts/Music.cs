using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
public static Music mInstance;

    void Awake()
    {
        if (mInstance != null && mInstance != this)
        {
            Destroy (this.gameObject);
            return;
        }

        mInstance = this;
        DontDestroyOnLoad(this);
    }
}
