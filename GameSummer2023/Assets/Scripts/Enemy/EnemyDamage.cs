using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {
    [SerializeField] float impactDamage;
    [SerializeField] float stayingDamage;

    public float ImpactDamage() {
        return impactDamage;
    }
    public float StayingDamage() {
        return stayingDamage;
    }
}
