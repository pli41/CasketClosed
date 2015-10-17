using UnityEngine;
using System.Collections;

public class SnowWalk : MonoBehaviour {

	private Animator anim;							
	private AnimatorStateInfo currentState;
	private CapsuleCollider col;			
	AudioSource audio;
	static int locoState = Animator.StringToHash("Base Layer.Locomotion");		
	static int walkBackState = Animator.StringToHash("Base Layer.WalkBack");
	// Use this for initialization
	void Start () {
		audio= GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {


	}
	void OnCollisionEnter (Collision other) 
	{
		if((other.gameObject.tag == "floor")&&((currentState.nameHash == locoState) || (currentState.nameHash == walkBackState)))
		{
			audio.Play();
		}
		
	}
	void OnCollisionStay (Collision other) 
	{
		if((other.gameObject.tag == "floor")&&((currentState.nameHash == locoState) || (currentState.nameHash == walkBackState)))
		{
			audio.Play();
		}
		
	}

}
