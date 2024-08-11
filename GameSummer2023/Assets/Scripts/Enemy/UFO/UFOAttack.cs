using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOAttack : MonoBehaviour {
    [SerializeField] float zapCoolDown = 1f;

    [SerializeField] TurretVision vision;
    private Transform playerTransform;

    private void Awake() {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Start() {
        StartCoroutine(ZappingCoroutine());
    }

    private IEnumerator ZappingCoroutine() {
        while (true) {
            yield return new WaitForSeconds(zapCoolDown);
            ZapPlayer();
        }
    }

    private void ZapPlayer() {
        if (vision.IsTargetDetected() == false) {
            return;
        }
    }
}