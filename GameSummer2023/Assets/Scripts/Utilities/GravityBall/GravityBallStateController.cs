using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GravityBallStateController : MonoBehaviour {
    public ReadyState readyState = new ReadyState();
    public GrabbingState grabbingState = new GrabbingState();
    public FlyingState flyingState = new FlyingState();

    [HideInInspector] public float distanceToCenter;
    [HideInInspector] public Vector3 directionToMouse;
    [HideInInspector] public Vector3 screenPosition;
    [HideInInspector] public Vector3 worldPosition;
    [HideInInspector] public Vector3 arrowPosition;
    [HideInInspector] public Quaternion toRotaion;
    [HideInInspector] public Plane mouseInteractionPlane = new Plane(Vector3.forward, 0f);
    [HideInInspector] public float flyingTimeCounter = 0f;

    public float throwingForce = 10f;
    public float nonArrowRadius = 0.5f;
    public float showArrowRadius = 3f;
    public float flyingTime = 1.5f;

    public Camera mainCamera;
    public GameObject arrow;
    public Image defaultGrabPoint;
    public Image holdingMouseRadius;
    public Image arrowImage;
    public Rigidbody rigidbodyComponent;
    public LinkingControl linkingControl;

    [HideInInspector] public State currentState;

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
}