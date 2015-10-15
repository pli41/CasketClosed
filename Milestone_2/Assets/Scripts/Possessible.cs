using UnityEngine;
using System.Collections;

public class Possessible : MonoBehaviour {
	GameObject player;
	bool possessable;
	bool isPossessed = false;
	int possDelay;
	Animator anim;
	public Component[] boneRig;
    Component[] colliders;
	public int ReviveTime;
    float radius;
	int time;
	// Use this for initialization
	void Start () {
		possDelay = 0;
		possessable = false;
		anim = GetComponent<Animator> ();
		boneRig = gameObject.GetComponentsInChildren <Rigidbody>();
        colliders = gameObject.GetComponentsInChildren<Collider>();
        radius = GetComponent<CapsuleCollider>().radius;
        Revive();
	}

	void Update () { 
		if (isPossessed) {
           
            player.transform.position = transform.position;
			player.transform.rotation = transform.rotation;
			if (Input.GetAxisRaw ("Vertical") > 0) {
				anim.SetInteger ("AnimState", 1);
			} else if (Input.GetAxisRaw ("Vertical") < 0) {
				anim.SetInteger ("AnimState", -1);
			} else {
				anim.SetInteger ("AnimState", 0);
			}
			if (Input.GetAxisRaw ("Horizontal") != 0) {
				transform.Rotate (0, Input.GetAxisRaw ("Horizontal") * 80.0f * Time.deltaTime, 0, Space.World);

			}
            if (Input.GetKey(KeyCode.LeftShift))
            {
                if(anim.GetFloat("speed") < 1)
                {
                    float speed = anim.GetFloat("speed");
                    speed += .1f;
                    anim.SetFloat("speed", speed);
                }
            } else {
                anim.SetFloat("speed", 0);
            }
            GetComponent<CapsuleCollider>().radius = radius + (GetComponent<Rigidbody>().velocity.magnitude/20) * anim.GetInteger("AnimState");
            possDelay += 1;
		} else {
			anim.SetInteger ("AnimState", 0);
            
		}
       
	}

	void OnTriggerEnter(Collider target){
		if (target.gameObject.tag.Equals ("Player")) {
			Debug.Log ("player Enters");
			player = target.gameObject;
			possessable = true;
		}
	}

	void OnTriggerExit(){
		//possessable = false;
	}

	public void possess(){

		if (possessable && !player.GetComponent<GhostScript>().poss) {
			player.gameObject.GetComponent<CapsuleCollider>().enabled = false;
			player.gameObject.GetComponent<Rigidbody>().useGravity = false;
			transform.position = player.transform.position; 
			//player.transform.SetParent (this.transform);
			player.GetComponentInChildren<SkinnedMeshRenderer> ().enabled = false;
			isPossessed = true;
			player.GetComponent<GhostScript>().poss = true;

		}
	}

	public void dePossess(){
        
        if (possDelay > 10) {
			Kill ();
			player.GetComponentInChildren<SkinnedMeshRenderer> ().enabled = true;
			isPossessed = false;


			player.GetComponent<GhostScript>().poss = false;
			possDelay = 0;

			player.gameObject.GetComponent<CapsuleCollider> ().enabled = true;
			player.gameObject.GetComponent<Rigidbody> ().useGravity = true;
			possessable = false;
		}
	}

	public void Kill(){
		for (int i = 0; i < boneRig.Length; i++) {
            Rigidbody ragbone = (Rigidbody)boneRig[i];
            Collider coll = (Collider)colliders[i];
            ragbone.isKinematic = false;
            ragbone.useGravity = true;
            coll.enabled = true;
            
		}
		GetComponent<Animator> ().enabled = false;
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<CapsuleCollider>().enabled = false;
		time = 0;
	}

	void Revive(){
        for (int i = 0; i < boneRig.Length; i++)
        {
            Rigidbody ragbone = (Rigidbody)boneRig[i];
            Collider coll = (Collider)colliders[i];
            ragbone.useGravity = false;
            //ragbone.isKinematic = true;
            coll.enabled = false;
        }
        GetComponent<Animator> ().enabled = true;
		possessable = true;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<CapsuleCollider>().enabled = true;
        GetComponent<BoxCollider>().enabled = true;

    }

}
