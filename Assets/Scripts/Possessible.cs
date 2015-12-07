using UnityEngine;
using RAIN.Core;
using System.Collections;

public class Possessible : MonoBehaviour {
	GameObject player;
	bool possessible;
	public bool isPossessed = false;
	public float rotationSpeed;
	int possDelay;
	Animator anim;
    public AIRig ai;
	public Component[] boneRig;
    Collider[] colliders;
	public int ReviveTime;
	int time;
	public float animSpeed = 1.5f;
	RuntimeAnimatorController controller;
    ParticleSystem poof;
	// Use this for initialization
	void Start () {
        poof = GameObject.Find("ghoul").GetComponentInChildren<ParticleSystem>();
        ai = GetComponentInChildren<AIRig>();
		possDelay = 0;
		possessible = false;
		anim = GetComponent<Animator> ();
		boneRig = gameObject.GetComponentsInChildren <Rigidbody>();
        colliders = gameObject.GetComponentsInChildren<Collider>();
		controller = anim.runtimeAnimatorController;
       // Revive();
    }

	void Update () { 
		if (isPossessed) {
			player.transform.position = transform.position;
			player.transform.rotation = transform.rotation;
			float h = Input.GetAxis ("Horizontal");	
			float v = Input.GetAxis ("Vertical");	
			anim.SetFloat ("Speed", v);
			if (v > 0.1 || v < -0.1){
			   anim.SetFloat ("Direction", h);
                
            } else {
				transform.Rotate(Vector3.up, h * rotationSpeed * Time.deltaTime);
			}
			anim.speed = animSpeed;

			possDelay += 1;
		} else {
			anim.SetInteger ("AnimState", 0);
		}
	
	}
   
	void OnTriggerEnter(Collider target){
		if (target.gameObject.tag.Equals ("Player")) {
			
			possessible = true;
		}
	}
 
	void OnTriggerExit(){
		possessible = false;
	}

	public void possess(GameObject target){
        player = target;
		if (possessible && !player.GetComponent<GhostScript>().poss) {
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

			// Update animator 
			anim.runtimeAnimatorController = player.GetComponent<Animator>().runtimeAnimatorController;
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
            poof.Play();
			anim.runtimeAnimatorController = controller;
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
		possessible = true;
	}

}
