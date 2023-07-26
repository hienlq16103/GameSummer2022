using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [SerializeField] float bulletSpeed = 1f;

    [SerializeField] GameObject laserExplosion;
    
    private void Update() {
        transform.Translate(bulletSpeed * new Vector3(1, 0, 0));
    }
    private void OnTriggerEnter(Collider other) {
        Instantiate(laserExplosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
