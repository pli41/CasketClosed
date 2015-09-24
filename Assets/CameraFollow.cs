using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform player;

	public float camera_OffsetForward;
	public float camera_OffsetUpward;

	public float rotateSpeed;
	public float translateSpeed;

	private Camera cam;
	// Use this for initialization
	void Start () {
		cam = gameObject.GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
		CamTranslate ();
		CamRotate ();

	}

	void CamRotate(){

		Vector3 targetDir = FindTargetCameraDirection (player);
		float step = rotateSpeed * Time.deltaTime;
		Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
		Debug.DrawRay(transform.position, newDir, Color.red);
		transform.rotation = Quaternion.LookRotation(newDir);
	}

	void CamTranslate(){
		float step = translateSpeed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(FindTargetCameraPoint(player), transform.position, step);
	}


	Vector3 FindTargetCameraPoint(Transform player){
		Vector3 playerPos = player.position;
		Vector3 targetPos = player.position - player.forward * camera_OffsetForward + player.up * camera_OffsetUpward;
		return targetPos;
	}

	Vector3 FindTargetCameraDirection(Transform player){
		Vector3 direction = player.position - transform.position;
		return direction;
	}

}
