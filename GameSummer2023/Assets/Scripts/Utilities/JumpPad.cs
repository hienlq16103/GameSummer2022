using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour {
    [SerializeField] float bounceForce = 20f;

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.TryGetComponent<Rigidbody>(out Rigidbody targetRigidbody)) {
            //targetRigidbody.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
            targetRigidbody.velocity = new Vector3(
                targetRigidbody.velocity.x,
                bounceForce,
                targetRigidbody.velocity.z);
        }
    }
}
