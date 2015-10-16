using UnityEngine;
using System.Collections;


[RequireComponent(typeof (Animator))]
[RequireComponent(typeof (CapsuleCollider))]
public class GhostScript : MonoBehaviour
{
	[System.NonSerialized]					
	
	public float animSpeed = 1.25f;				
	public float lookSmoother = 3f;		
	public bool poss;
	public GameObject npc;
	private Animator anim;							
	private AnimatorStateInfo currentBaseState;		
	private CapsuleCollider col;			

	static int idleState = Animator.StringToHash("Base Layer.Idle");	
	static int locoState = Animator.StringToHash("Base Layer.Locomotion");		
	static int possessState = Animator.StringToHash("Base Layer.Possess");			
	
	void Start ()
	{
		
		anim = GetComponent<Animator>();					  
		col = GetComponent<CapsuleCollider>();				

	}
	
	void FixedUpdate ()
	{
		if (!poss) {
			float h = Input.GetAxis ("Horizontal");	
			float v = Input.GetAxis ("Vertical");	
			anim.SetFloat ("Speed", v);					
			anim.SetFloat ("Direction", h); 			
			anim.speed = animSpeed;				
			currentBaseState = anim.GetCurrentAnimatorStateInfo (0);	
		}
		if (currentBaseState.nameHash == locoState)
		{
			/*
			if(Input.GetKeyDown(KeyCode.Space))
			{
				anim.SetTrigger("Possess");
				possess ();
			}
			*/
		}
		if(Input.GetKeyDown(KeyCode.Space))
		{
			anim.SetTrigger("Possess");
			possess ();
		}
	}

	void OnTriggerEnter(Collider target){
		if (target.tag.Equals ("NPC") && !poss) {
			npc = target.gameObject;
		}
	}
	
	void OnTriggerExit(){
		if (!poss) {
			npc = null;
		}
	}
	
	void possess(){
		if (poss) {
			npc.GetComponent<Possessible> ().dePossess ();
		} else if (!poss && npc) {
			Debug.Log("ask NPC to possess");
			npc.GetComponent<Possessible> ().possess ();

		}
	}
	IEnumerator Example() {
		yield return new WaitForSeconds(2);
	}
}

