using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryOtherObject : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player") == false) {
            return;
        }
        other.transform.SetParent(transform);
    }
    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player") == false) {
            return;
        }
        other.transform.SetParent(null);    
    }
}
