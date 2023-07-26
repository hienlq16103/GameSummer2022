using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SatelliteStateController : MonoBehaviour {
    public SatelliteReadyState readyState = new SatelliteReadyState();
    public SatelliteFixingState fixingState = new SatelliteFixingState();
    public SatelliteFinishState finishState = new SatelliteFinishState();

    [HideInInspector] public float currentFixingTime = 0f;

    public float fixingTime = 2.5f;

    public Image fixGearIcon;
    public Image greenTick;
    public GameObject process;
    public ProcessSlider slider;
    public GrabPointMechanic grabPointMechanic;
    public SatelliteSetDefaultState setDefaultState;
    public GameObject interactionCircle;
    public PlayerStatus playerStatus;

    State currentState;

    private void Start() {
        ChangeState(readyState);
    }
    private void Update() {
        if (currentState == null) {
            return;
        }
        currentState.OnUpdate(this);
    }
    public void ChangeState(State nextState) {
        if (currentState == nextState) {
            return;
        }
        if (currentState != null) {
            currentState.OnExit(this);
        }
        currentState = nextState;
        currentState.OnEnter(this);
    }

    public void FinishFixing() {
        grabPointMechanic.enabled = false;
        setDefaultState.enabled = false;
        interactionCircle.SetActive(false);
        playerStatus.IncreaseAchievedObjective();
    }
}
