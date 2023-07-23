using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPadDirectioningState : State {
    public override void OnEnter(FloatingPadStateController stateController) {
        stateController.holdingMouseRadius.enabled = true;
    }
    public override void OnUpdate(FloatingPadStateController stateController) {
        stateController.screenPosition = Input.mousePosition;
        Ray cameraToMouseRay = stateController.mainCamera.ScreenPointToRay(stateController.screenPosition);
        if (stateController.mouseInteractionPlane.Raycast(cameraToMouseRay, out float distanceToPlane)) {
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

            stateController.toRotaion = Quaternion.LookRotation(Vector3.back, stateController.directionToMouse);
            stateController.arrow.transform.rotation = stateController.toRotaion;
            if (stateController.directionToMouse.x > 0) {
                stateController.transform.position =
                    Vector3.MoveTowards(stateController.transform.position,
                    stateController.rightPoint.position, stateController.movementSpeed * Time.deltaTime);
            } else {
                stateController.transform.position =
                    Vector3.MoveTowards(stateController.transform.position,
                    stateController.leftPoint.position, stateController.movementSpeed * Time.deltaTime);
            }
        } else {
            stateController.arrowImage.enabled = false;
        }
    }
    public override void OnExit(FloatingPadStateController stateController) {
        stateController.holdingMouseRadius.enabled = false;
        stateController.arrowImage.enabled = false;
    }
}
