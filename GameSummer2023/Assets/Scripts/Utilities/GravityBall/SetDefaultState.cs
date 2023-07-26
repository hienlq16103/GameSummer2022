using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDefaultState : MonoBehaviour {
    [SerializeField] GravityBallStateController stateController;

    private void OnEnable() {
        stateController.ChangeState(stateController.readyState);
    }
    private void OnDisable() {
        if (stateController.currentState == stateController.flyingState) {
            return;
        }
        stateController.ChangeState(stateController.readyState);
    }
}
