using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyState : State {
    public override void OnEnter(GravityBallStateController stateController) {
        stateController.defaultGrabPoint.enabled = true;
    }
    public override void OnExit(GravityBallStateController stateController) {
        stateController.defaultGrabPoint.enabled = false;
    }
}
