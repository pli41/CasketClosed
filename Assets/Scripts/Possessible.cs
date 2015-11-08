using UnityEngine;
using RAIN.Core;
using System.Collections;

public class Possessible : MonoBehaviour {
	GameObject player;
	bool possessable;
	public bool isPossessed = false;
	int possDelay;
	Animator anim;
    public AIRig ai;
	public Component[] boneRig;
    Collider[] colliders;
	public int ReviveTime;
	int time;
	// Use this for initialization
	void Start () {
        ai = GetComponentInChildren<AIRig>();
		possDelay = 0;
		possessable = false;
		anim = GetComponent<Animator> ();
		boneRig = gameObject.GetComponentsInChildren <Rigidbody>();
        colliders = gameObject.GetComponentsInChildren<Collider>();
       // Revive();
    }

	void Update () { 
		if (isPossessed) {
			player.transform.position = transform.position;
			player.transform.rotation = transform.rotation;
			if (Input.GetAxisRaw ("Vertical") > 0) {
				anim.SetFloat ("speed", 1.5f);
			} else if (Input.GetAxisRaw ("Vertical") < 0) {
				anim.SetFloat ("speed", -1f);
			} else {
				anim.SetFloat("speed", 0);
			}
			if (Input.GetAxisRaw ("Horizontal") > 0) {
                anim.SetFloat("turn", 360f);
			} else if (Input.GetAxisRaw("Horizontal") < 0)
            {
                anim.SetFloat("turn", -360f);
            } else
            {
                anim.SetFloat("turn", 0f);
            }
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
            ai.enabled = false;
            anim.SetInteger("AnimState", 0);
			player.gameObject.GetComponent<CapsuleCollider>().enabled = false;
			player.gameObject.GetComponent<Rigidbody>().useGravity = false;
			transform.position = player.transform.position; 
			//player.transform.SetParent (this.transform);
			player.GetComponentInChildren<SkinnedMeshRenderer> ().enabled = false;
			isPossessed = true;
			player.GetComponent<GhostScript>().poss = true;
            gameObject.GetComponent<CapsuleCollider>().enabled = true;
		}
	}

	public void dePossess(){
		if (possDelay > 10) {
      
            //Kill ();

			player.GetComponentInChildren<SkinnedMeshRenderer> ().enabled = true;

			isPossessed = false;

            
            player.GetComponent<GhostScript>().poss = false;
			possDelay = 0;

			
			player.gameObject.GetComponent<Rigidbody> ().useGravity = true;
			
            ai.enabled = true;
		}
	}

	public void Kill(){
		foreach (Rigidbody ragbone in boneRig) {
			ragbone.isKinematic = false;
		}
        foreach(Collider coll in colliders)
        {
            coll.enabled = true;
        }
        GetComponent<CapsuleCollider>().enabled = false;
		GetComponent<Animator> ().enabled = false;
		time = 0;
	}

	void Revive(){
        foreach (Collider coll in colliders)
        {
            coll.enabled = false;
        }
        GetComponent<CapsuleCollider>().enabled = true;
        foreach (Rigidbody ragbone in boneRig) {
			ragbone.isKinematic = true;
		}
		GetComponent<Animator> ().enabled = true;
		possessable = true;
	}

}
