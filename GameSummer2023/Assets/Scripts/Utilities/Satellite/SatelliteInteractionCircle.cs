using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatelliteInteractionCircle : MonoBehaviour {

    [SerializeField] SatelliteStateController stateController;


    private void OnMouseUp() {
        stateController.ChangeState(stateController.readyState);
    }
    private void OnMouseExit() {
        stateController.ChangeState(stateController.readyState);
    }
    private void OnMouseDown() {
        stateController.ChangeState(stateController.fixingState);
    }
}