using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPadReadyState : State {
    public override void OnEnter(FloatingPadStateController stateController) {
        stateController.defaultGrabPoint.enabled = true;
    }
    public override void OnExit(FloatingPadStateController stateController) {
        stateController.defaultGrabPoint.enabled = false;
    }
}
