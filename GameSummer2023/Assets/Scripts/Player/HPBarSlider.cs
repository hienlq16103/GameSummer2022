using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBarSlider : MonoBehaviour {
    [SerializeField] Slider slider;

    public void SetMaxValue(float maxValue) {
        slider.maxValue = maxValue;
        slider.value = maxValue;
    }
    public void SetValue(float value) {
        slider.value = value;
    }
}
