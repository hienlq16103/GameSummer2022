using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAggro : MonoBehaviour {

    [SerializeField] float rotationSpeed = 100f;
    [SerializeField] float rotationModifier = -180f;
    [SerializeField] float shootCoolDown = 1f;

    [SerializeField] TurretVision vision;
    [SerializeField] Transform turretBarrel;
    [SerializeField] Transform barrelEnd;
    [SerializeField] GameObject bullet;
    private Transform playerTransform;

    private Vector3 directionToTarget;
    private Quaternion toRotation;

    private void Awake() {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Start() {
        StartCoroutine(ShootingCoroutine());
    }
    private void Update() {
        AimAtTarget();
    }
    
    private void AimAtTarget() {
        if (vision.IsTargetDetected() == false) {
            return;
        }
        directionToTarget = Vector3.Normalize(turretBarrel.position - playerTransform.position);
        toRotation = TargetRotaionFromDirection(directionToTarget);
        turretBarrel.rotation = Quaternion.RotateTowards(turretBarrel.rotation, toRotation, rotationSpeed * Time.deltaTime);
        
    }
    private Quaternion TargetRotaionFromDirection(Vector3 targetDirection) {
        float angle =
            Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - rotationModifier;
        return Quaternion.AngleAxis(angle, Vector3.forward);
    }
    private IEnumerator ShootingCoroutine() {
        while (true) {
            yield return new WaitForSeconds(shootCoolDown);
            ShootLaser();
        }
    }
    private void ShootLaser() {
        if (vision.IsTargetDetected() == false) {
            return;
        }
        if (turretBarrel.rotation != toRotation) { 
            return;
        }
        Instantiate(bullet, barrelEnd.position, barrelEnd.rotation);
    }
}
