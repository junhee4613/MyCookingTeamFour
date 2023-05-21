using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public AudioSource[] AS = new AudioSource[2];//0¹ø = BGM,1¹ø SFX
    private static SoundManager instance;
    public static SoundManager SMInstance()
    {
        return instance;
    }
    void Start()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            if(instance != this)
            {
                Destroy(this);
            }
        }
        AS[0] = GetComponents<AudioSource>()[0];
        AS[1] = GetComponents<AudioSource>()[1];
    }
}
