using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtObject : MonoBehaviour{
    [SerializeField] Transform targetTransform;

    Vector3 lookingDirection;

    private void Update() {
        lookingDirection = transform.position - targetTransform.position;
        transform.rotation = Quaternion.LookRotation(lookingDirection);
    }
}
