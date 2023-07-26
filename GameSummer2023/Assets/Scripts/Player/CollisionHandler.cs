using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour {
    [SerializeField] PlayerStatus playerStatus;

    EnemyDamage enemyDamage;

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Enemy")) {
            enemyDamage = collision.gameObject.GetComponent<EnemyDamage>();
            playerStatus.ChangeHealthBy(-enemyDamage.ImpactDamage());
        }
    }
    private void OnCollisionStay(Collision collision) {
        if (collision.gameObject.CompareTag("Enemy")) {
            enemyDamage = collision.gameObject.GetComponent<EnemyDamage>();
            playerStatus.ChangeHealthBy(-enemyDamage.StayingDamage() * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Enemy")) {
            enemyDamage = other.GetComponent<EnemyDamage>();
            playerStatus.ChangeHealthBy(-enemyDamage.ImpactDamage());
        }
    }
}
