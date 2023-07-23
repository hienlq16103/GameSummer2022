using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingPadStateController : MonoBehaviour {
    public FloatingPadReadyState readyState = new FloatingPadReadyState();
    public FloatingPadDirectioningState directioningState = new FloatingPadDirectioningState();

    [HideInInspector] public float distanceToCenter;
    [HideInInspector] public Vector3 directionToMouse;
    [HideInInspector] public Vector3 screenPosition;
    [HideInInspector] public Vector3 worldPosition;
    [HideInInspector] public Vector3 arrowPosition;
    [HideInInspector] public Quaternion toRotaion;
    [HideInInspector] public Plane mouseInteractionPlane = new Plane(Vector3.forward, 0f);
    [HideInInspector] public Transform playerTransform;

    [Header("Floating pad attribute")]
    public float movementSpeed = 7f;
    public float nonArrowRadius = 0.5f;
    public float showArrowRadius = 1f;

    [Header("Caching components")]
    public Camera mainCamera;
    public GameObject arrow;
    public Image defaultGrabPoint;
    public Image holdingMouseRadius;
    public Image arrowImage;
    public Transform leftPoint;
    public Transform rightPoint;

    State currentState;

    private void Start() {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        ChangeState(readyState);
    }
    private void FixedUpdate() {
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
