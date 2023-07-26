using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatelliteFixingState : State {
    public override void OnEnter(SatelliteStateController stateController) {
        stateController.process.SetActive(true);
        stateController.slider.SetMaxValue(stateController.fixingTime);
        stateController.currentFixingTime = 0;
        stateController.audioSource.loop = true;
    }
    public override void OnUpdate(SatelliteStateController stateController) {
        if (stateController.currentFixingTime >= stateController.fixingTime) {
            stateController.ChangeState(stateController.finishState);
            return;
        }
        stateController.currentFixingTime += Time.deltaTime;
        stateController.slider.SetValue(stateController.currentFixingTime);
        if (stateController.audioSource.isPlaying) {
            return;
        }
        stateController.audioSource.PlayOneShot(stateController.fixingAudio);
    }
    public override void OnExit(SatelliteStateController stateController) {
        stateController.process.SetActive(false);
        stateController.audioSource.loop = false;
        stateController.audioSource.Stop();
    }
}