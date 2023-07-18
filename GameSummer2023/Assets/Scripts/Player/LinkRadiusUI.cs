using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LinkRadiusUI : MonoBehaviour {
    [SerializeField] RectTransform radiusImageRect;
    [SerializeField] LinkingControl linkingControl;

    float currentLinkingRadius;

    private void Update() {
        ChangeRadiusUI();
    }

    private void ChangeRadiusUI() {
        currentLinkingRadius = linkingControl.CurrentLinkingRadius();
        radiusImageRect.sizeDelta = 2 * new Vector2(currentLinkingRadius, currentLinkingRadius);
    }
}