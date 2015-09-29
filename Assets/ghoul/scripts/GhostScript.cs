using UnityEngine;
using System.Collections;


[RequireComponent(typeof (Animator))]
[RequireComponent(typeof (CapsuleCollider))]
[RequireComponent(typeof (Rigidbody))]
public class GhostScript : MonoBehaviour
{
	[System.NonSerialized]					
	
	public float animSpeed = 1.25f;				
	public float lookSmoother = 3f;		

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
		float h = Input.GetAxis("Horizontal");	
		float v = Input.GetAxis("Vertical");	
		anim.SetFloat("Speed", v);					
		anim.SetFloat("Direction", h); 			
		anim.speed = animSpeed;				
		currentBaseState = anim.GetCurrentAnimatorStateInfo(0);	
		
		if (currentBaseState.nameHash == locoState)
		{
			if(Input.GetKeyDown(KeyCode.Space))
			{
				anim.SetTrigger("Possess");
			}
		}

	}
}

