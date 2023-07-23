using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatelliteReadyState : State {
    public override void OnEnter(SatelliteStateController stateController) {
        stateController.fixGearIcon.enabled = true;
    }
    public override void OnExit(SatelliteStateController stateController) {
        stateController.fixGearIcon.enabled = false;
    }
}
