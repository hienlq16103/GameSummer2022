using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TurretVision))]
public class EnemyDetectRadius : Editor {
    private void OnSceneGUI() {
        TurretVision turretVision = (TurretVision) target;
        Handles.color = Color.red;
        Handles.DrawWireArc(turretVision.transform.position, Vector3.forward, Vector3.right, 360, turretVision.detectRadius);

        if (turretVision.IsTargetDetected()) {
            Handles.color = Color.yellow;
            Handles.DrawLine(turretVision.transform.position, turretVision.playerTransform.position);
        }
        
    }
}
