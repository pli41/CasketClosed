using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	private Animator anim;
	float speed = 0.0f;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxisRaw ("Vertical") > 0) {
			anim.SetInteger ("AnimState", 1);
		} else if (Input.GetAxisRaw ("Vertical") < 0) {
			anim.SetInteger ("AnimState", -1);
		} else {
			anim.SetInteger ("AnimState", 0);
		}
		if (Input.GetKey (KeyCode.Space)) {
			anim.SetInteger("AnimState", 2);
		}
		if (Input.GetAxisRaw ("Horizontal") != 0) {
			transform.Rotate (0, Input.GetAxisRaw ("Horizontal")*80.0f * Time.deltaTime, 0, Space.World);
		}	
		if (Input.GetKey (KeyCode.LeftShift)) {
			speed += .1f;
			if (speed >= 1.0f) {
				speed = 1.0f;
			}
			anim.SetFloat ("speed", speed);
		} else {
			speed -= .1f;
			if (speed <= 0.0f) {
				speed = 0.0f;
			}
			anim.SetFloat ("speed", speed);
		}
	}
}
