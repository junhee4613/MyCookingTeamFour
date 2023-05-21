using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSliders : MonoBehaviour
{
    public bool isThisBGMSlider;
    Slider thisSlider;
    private void Start()
    {
        thisSlider = GetComponent<Slider>();
    }
    public void OnSliderValue()
    {

        switch (isThisBGMSlider)
        {
            case true:
                SoundManager.SMInstance().AS[0].volume = thisSlider.value;
                break;
            case false:
                SoundManager.SMInstance().AS[1].volume = thisSlider.value;
                break;
        }
    }
}
