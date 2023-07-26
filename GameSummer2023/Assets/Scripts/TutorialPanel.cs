using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialPanel : MonoBehaviour {
    [SerializeField] string tutorialMessage;

    [SerializeField] GameObject canvas;
    [SerializeField] TextMeshProUGUI textMeshPro;

    private void Start() {
        textMeshPro.text = tutorialMessage;
        canvas.SetActive(false);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            canvas.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            canvas.SetActive(false);
        }
    }
}
