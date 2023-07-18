using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrabPointMechanic : MonoBehaviour {
    [SerializeField] LinkingControl linkingControl;
    [SerializeField] GameObject grabPointCanvas;
    [SerializeField] GameObject interactionCircle;
    Transform playerTransform;

    float distanceToPlayer;
    bool isWithinLinkingRadius;

    private void Start() {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        grabPointCanvas.SetActive(false);
        interactionCircle.SetActive(false);
        isWithinLinkingRadius = false;
    }
    private void Update() {
        SetGrabPointActiveState();
    }

    public bool IsWithinLinkingRadius() {
        return isWithinLinkingRadius;
    }

    void SetGrabPointActiveState() {
        distanceToPlayer = Vector3.Distance(playerTransform.position, transform.position);
        if (distanceToPlayer <= linkingControl.CurrentLinkingRadius()) {
            if (isWithinLinkingRadius) {
                return;
            }
            grabPointCanvas.SetActive(true);
            interactionCircle.SetActive(true);
            isWithinLinkingRadius = true;
        } else {
            if (isWithinLinkingRadius == false) {
                return;
            }
            grabPointCanvas.SetActive(false);
            interactionCircle.SetActive(false);
            isWithinLinkingRadius = false;
        }
    }
}
