using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingState : State {
    public override void OnEnter(GravityBallStateController stateController) {
        stateController.flyingTimeCounter = stateController.flyingTime;
    }
    public override void OnUpdate(GravityBallStateController stateController) {
        if (stateController.flyingTimeCounter <= 0) {
            stateController.ChangeState(stateController.readyState);
            return;
        }
        stateController.flyingTimeCounter -= Time.deltaTime;
    }
}
