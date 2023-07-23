using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDefaultState : MonoBehaviour {
    [SerializeField] GravityBallStateController stateController;

    private void OnEnable() {
        stateController.ChangeState(stateController.readyState);
    }
    private void OnDisable() {
        stateController.ChangeState(stateController.readyState);
    }
}
