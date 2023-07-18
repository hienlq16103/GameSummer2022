using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State {
    public virtual void OnEnter(GravityBallStateController stateController) { }
    public virtual void OnUpdate(GravityBallStateController stateController) { }
    public virtual void OnExit(GravityBallStateController stateController) { }
}