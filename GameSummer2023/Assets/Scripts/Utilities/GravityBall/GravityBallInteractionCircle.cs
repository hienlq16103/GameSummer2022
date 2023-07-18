using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBallInteractionCircle : MonoBehaviour{
    [SerializeField] GravityBallStateController stateController;

    private void OnMouseUpAsButton() {
        stateController.ChangeState(stateController.readyState);
    }
    private void OnMouseDrag() {
        stateController.ChangeState(stateController.grabbingState);
    }
}
