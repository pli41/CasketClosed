using UnityEngine;
using System.Collections;

public class ObjectPhysics : MonoBehaviour {

	void OnControllerColliderHit(ControllerColliderHit hit){

		float pushPower = 1.0f; 
		float weight = 6.0f;
		Vector3 force;
		Rigidbody body = hit.collider.attachedRigidbody;

		if (body == null || body.isKinematic) {
			return;
		}

		if (hit.moveDirection.y < -0.3) {
			return;
		}

		force = hit.controller.velocity * pushPower;
		Vector3 pushDir = new Vector3 (hit.moveDirection.x, 0, hit.moveDirection.z) * pushPower;

		body.velocity = pushDir;
//		body.AddForceAtPosition (force, hit.point);

	
	}

}
