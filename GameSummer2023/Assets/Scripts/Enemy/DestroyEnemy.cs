using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour {

    [SerializeField] GameObject explosionParticleObject;

    GravityBallStateController stateController;

    private void OnCollisionEnter(Collision collision) {    
        if (collision.gameObject.CompareTag("GravityBall") == false) {
            return;
        }
        
        stateController = collision.gameObject.GetComponent<GravityBallStateController>();
        
        if (stateController.currentState != stateController.flyingState) {
            return;
        }
        Instantiate(explosionParticleObject,transform.position,transform.rotation);
        Destroy(gameObject);
    }
    private void OnCollisionStay(Collision collision) {
        if (collision.gameObject.CompareTag("GravityBall") == false) {
            return;
        }

        stateController = collision.gameObject.GetComponent<GravityBallStateController>();

        if (stateController.currentState != stateController.flyingState) {
            return;
        }
        Instantiate(explosionParticleObject,transform.position,transform.rotation);
        Destroy(gameObject);
    }
}
