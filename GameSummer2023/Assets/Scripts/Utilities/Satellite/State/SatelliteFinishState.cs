using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatelliteFinishState : State {
    public override void OnEnter(SatelliteStateController stateController) {
        stateController.greenTick.enabled = true;
        stateController.FinishFixing();
    }
}
