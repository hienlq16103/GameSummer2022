using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPadInteractionCircle : MonoBehaviour {
    [SerializeField] FloatingPadStateController stateController;

    private void OnMouseUp() {
        stateController.ChangeState(stateController.readyState);
    }
    private void OnMouseDrag() {
        stateController.ChangeState(stateController.directioningState);
    }
}
