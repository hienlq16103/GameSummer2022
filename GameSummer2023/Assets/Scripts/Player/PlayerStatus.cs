using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour {
    [SerializeField] float maxHealtPoint = 100f;
    [SerializeField] float maxObjective = 1f;

    [SerializeField] HPBarSlider slider;

    private float currentHealthPoint;
    private float currentAchievedObjective;

    private void Start() {
        currentAchievedObjective = 0f;
        currentHealthPoint = maxHealtPoint;
        slider.SetMaxValue(maxHealtPoint);
    }

    public void IncreaseAchievedObjective() {
        currentAchievedObjective++;
    }
    public void ChangeHealthBy(float value) {
        currentHealthPoint += value;
        CheckHealth();
        slider.SetValue(currentHealthPoint);
    }
    private void CheckHealth() {
        if (currentHealthPoint > maxHealtPoint) {
            currentHealthPoint = maxHealtPoint;
        }
        if (currentHealthPoint < 0) {
            currentHealthPoint = 0f;
        }
    }

    public float CurrentHealthPoint() {
        return currentHealthPoint;
    }
    public float CurrentAchievedObjective() {
        return currentAchievedObjective;
    }
    public float MaxObjective() {
        return maxObjective;
    }
}
