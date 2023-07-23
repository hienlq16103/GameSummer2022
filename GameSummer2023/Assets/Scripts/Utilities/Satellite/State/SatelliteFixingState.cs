using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatelliteFixingState : State {
    public override void OnEnter(SatelliteStateController stateController) {
        stateController.process.SetActive(true);
        stateController.slider.SetMaxValue(stateController.fixingTime);
        stateController.currentFixingTime = 0;
    }
    public override void OnUpdate(SatelliteStateController stateController) {
        if (stateController.currentFixingTime >= stateController.fixingTime) {
            stateController.ChangeState(stateController.finishState);
            return;
        }
        stateController.currentFixingTime += Time.deltaTime;
        stateController.slider.SetValue(stateController.currentFixingTime);
    }
    public override void OnExit(SatelliteStateController stateController) {
        stateController.process.SetActive(false);
    }
}