using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbingState : State {
    public override void OnEnter(GravityBallStateController stateController) {
        stateController.holdingMouseRadius.enabled = true;
    }
    public override void OnUpdate(GravityBallStateController stateController) {
        stateController.screenPosition = Input.mousePosition;
        Ray cameraToMouseRay = stateController.mainCamera.ScreenPointToRay(stateController.screenPosition);
        if (stateController.mouseInteractionPlane.Raycast(cameraToMouseRay,out float distanceToPlane)) {
            stateController.worldPosition = cameraToMouseRay.GetPoint(distanceToPlane);
        }
        stateController.distanceToCenter =
            Vector3.Distance(stateController.worldPosition, stateController.transform.position);
        if (stateController.distanceToCenter >= stateController.nonArrowRadius) {
            stateController.arrowImage.enabled = true;

            stateController.directionToMouse =
                (stateController.worldPosition - stateController.transform.position).normalized;

            stateController.arrowPosition =
                stateController.transform.position + 
                stateController.showArrowRadius * stateController.directionToMouse;

            stateController.arrow.transform.position = stateController.arrowPosition;

            stateController.toRotaion = Quaternion.LookRotation(Vector3.back,stateController.directionToMouse);
            stateController.arrow.transform.rotation = stateController.toRotaion;
            if (Input.GetMouseButtonUp(0)) {
                stateController.rigidbodyComponent.
                    AddForce(stateController.throwingForce * stateController.directionToMouse,
                    ForceMode.VelocityChange);
                stateController.linkingControl.ResetCurrentLinkingRadius();
                stateController.ChangeState(stateController.flyingState);
            }
        } else {
            stateController.arrowImage.enabled = false;
        }
    }
    public override void OnExit(GravityBallStateController stateController) {
        stateController.holdingMouseRadius.enabled = false;
        stateController.arrowImage.enabled = false;
    }
}
