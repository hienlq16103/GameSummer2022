using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkingControl : MonoBehaviour {
    [SerializeField] float maxLinkingRadius = 5f;
    [SerializeField] float radiusIncreasingRate = 2f;
    [SerializeField] float radiusDecreaseRate = 15f;
    [SerializeField] float linkingCoolDown = 1f;

    float currentLinkingRadius = 0f;
    float coolDownTimer = 0f;
    class InputString {
        static public string CastLinking = "CastLinking";
    }

    private void Update() {
        DecreaseCoolDownTimer();
        CastLinking();
    }

    public float CurrentLinkingRadius() {
        return currentLinkingRadius;
    }
    public void ResetCurrentLinkingRadius() {
        currentLinkingRadius = 0f;
        coolDownTimer = linkingCoolDown;
    }

    private void CastLinking() {
        if (coolDownTimer > 0) {
            return;
        }
        if (Input.GetButton(InputString.CastLinking)) {
            if (currentLinkingRadius == maxLinkingRadius) {
                return;
            }
            if (currentLinkingRadius > maxLinkingRadius) {
                currentLinkingRadius = maxLinkingRadius;
                return;
            }
            currentLinkingRadius += radiusIncreasingRate * Time.deltaTime;
        } else {
            if (currentLinkingRadius == 0) {
                return;
            }
            if (currentLinkingRadius < 0) {
                currentLinkingRadius = 0;
                return;
            }
            currentLinkingRadius -= radiusDecreaseRate * Time.deltaTime;
        }
    }
    private void DecreaseCoolDownTimer() {
        if (coolDownTimer == 0) {
            return;
        }
        coolDownTimer -= Time.deltaTime;
    }
}
