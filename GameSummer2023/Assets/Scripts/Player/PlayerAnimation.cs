using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {
    [SerializeField] Animator playerAnimator;

    private void Update() {
        playerAnimator.SetBool("isLinking", Input.GetButton("CastLinking"));
        if (Input.GetAxisRaw("Horizontal") != 0) {
            playerAnimator.SetBool("isMoving", true);
        } else {
            playerAnimator.SetBool("isMoving", false);
        }
    }
}
