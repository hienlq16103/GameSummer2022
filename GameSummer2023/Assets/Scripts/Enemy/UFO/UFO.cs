using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour {

    [SerializeField] float movementSpeed = 2f;

    [SerializeField] Transform leftPoint;
    [SerializeField] Transform rightPoint;

    private void Start() {
        StartCoroutine(PatrolingRoutine());
    }

    IEnumerator PatrolingRoutine() {
        while (true) {
            yield return StartCoroutine(MoveToPoint(leftPoint));
            yield return StartCoroutine(MoveToPoint(rightPoint));
        }
    }

    IEnumerator MoveToPoint(Transform point) {
        while (transform.position != point.position) {
            transform.position = Vector3.MoveTowards(transform.position, point.position, movementSpeed * Time.deltaTime);
            yield return null;
        }
    }

}
