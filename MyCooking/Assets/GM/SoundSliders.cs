using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSliders : MonoBehaviour
{
    AudioSource targetSource;
    public bool isThisBGMSlider;
    Slider thisSlider;
    private void Start()
    {
        switch (isThisBGMSlider)
        {
            case true:
                targetSource = GameObject.Find("BGM").GetComponent<AudioSource>();
                break;
            case false:
                targetSource = GameObject.Find("SFX").GetComponent<AudioSource>();
                break;
        }

        thisSlider = GetComponent<Slider>();
        thisSlider.value = targetSource.volume;
    }
    public void OnSliderValue()
    {
        targetSource.volume = thisSlider.value;
    }
}
