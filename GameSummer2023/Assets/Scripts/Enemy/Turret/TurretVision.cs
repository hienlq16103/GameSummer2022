using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretVision : MonoBehaviour {
    public float detectRadius = 10f;
    [SerializeField] LayerMask obstructionMask;

    [HideInInspector] public Transform playerTransform;

    private bool isTargetDetected;
    private float distanceToPlayer;
    private float visionScanDelayTime;

    private void Awake() {
        isTargetDetected = false;
        visionScanDelayTime = 0.2f;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(VisionRoutine());
    }
    public bool IsTargetDetected() {
        return isTargetDetected;
    }

    private IEnumerator VisionRoutine() {
        while (true) {
            yield return new WaitForSeconds(visionScanDelayTime);
            VisionScan();
        }
    }
    private void VisionScan() {
        distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
        if (distanceToPlayer > detectRadius) {
            isTargetDetected = false;
            return;
        }
        //return true if linecast detect wall or groudn layer mask
        if (Physics.Linecast(transform.position, playerTransform.position, obstructionMask)) {
            isTargetDetected = false;
            return;
        }
        isTargetDetected = true;
    }

}
