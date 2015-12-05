using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	
	public Transform player;
	public float damping = 20.0f;
	public float verticalAngle;
	

	public float camera_OffsetForward;
	public float camera_OffsetUpward;
	
	public float rotateSpeed;
	public float translateSpeed;

    public float freeCam_horizontalRange;
    public float freeCam_verticalRange;
    public Vector3 freeCam_initialAngle;
    public bool freeCam_initialized;
    public Vector3 freeCam_MouseInitialPos;

    public bool freeCamera;
	private Camera cam;
	// Use this for initialization

	void Start () {
		cam = gameObject.GetComponent<Camera> ();
        freeCamera = false;
        freeCam_initialized = false;
	}

    // Update is called once per frame
    void LateUpdate() {
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            freeCamera = true;
            if (!freeCam_initialized)
            {
                freeCam_initialAngle = transform.eulerAngles;
                freeCam_MouseInitialPos = Input.mousePosition;
                freeCam_initialized = true;
            }
            
        }
        if (Input.GetKeyUp(KeyCode.LeftAlt))
        {
            freeCamera = false;
            freeCam_initialized = false;
        }

        if (!freeCamera)
        {
            CamRotate();
        }
        else
        {
            HandleFreeCamera();
        }
        CamTranslate();
    }
	
    void HandleFreeCamera()
    {

        Vector3 mousePos = Input.mousePosition;
        //Debug.Log(mousePos);
        float height = Screen.height;
        float width = Screen.width;

        float mouseDeltaX = mousePos.x - freeCam_MouseInitialPos.x;
        float mouseDeltaY = mousePos.y - freeCam_MouseInitialPos.y;

        float XRotation = mouseDeltaY / width * freeCam_horizontalRange;
        float YRotation = mouseDeltaX / height * freeCam_verticalRange;
        

        Debug.Log("Xrot = " + XRotation + " Yrot = " + YRotation);
        transform.eulerAngles = new Vector3(-XRotation + freeCam_initialAngle.x, YRotation + freeCam_initialAngle.y, 0f);
    }

	void CamRotate(){
		Vector3 targetDir = FindTargetCameraDirection (player);
		targetDir.Set (targetDir.x, 0f+verticalAngle, targetDir.z);
		//if(Vector3.Angle(targetDir, transform.forward) > 8f){
		//float step = rotateSpeed * Time.deltaTime;
		Quaternion newRotation = Quaternion.LookRotation(targetDir);;
		//Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
		//transform.rotation = Quaternion.LookRotation(newDir);
		transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * damping);
		//}
	}
	
	void CamTranslate(){
		
		Vector3 targetPos = FindTargetCameraPoint (player);
		//if(Vector3.Distance(targetPos, transform.position) > 1f){
		float step = translateSpeed * Time.deltaTime;
		transform.position = Vector3.Lerp(targetPos, transform.position, 0.05f);
		//}
		
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