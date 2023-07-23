using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State {
    public virtual void OnEnter(GravityBallStateController stateController) { }
    public virtual void OnUpdate(GravityBallStateController stateController) { }
    public virtual void OnExit(GravityBallStateController stateController) { }

    public virtual void OnEnter(FloatingPadStateController stateController) { }
    public virtual void OnUpdate(FloatingPadStateController stateController) { }
    public virtual void OnExit(FloatingPadStateController stateController) { }

    public virtual void OnEnter(SatelliteStateController stateController) { }
    public virtual void OnUpdate(SatelliteStateController stateController) { }
    public virtual void OnExit(SatelliteStateController stateController) { }
}