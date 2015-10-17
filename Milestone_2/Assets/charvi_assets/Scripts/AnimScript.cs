using UnityEngine;
using System.Collections;


[RequireComponent(typeof (Animator))]
[RequireComponent(typeof (CapsuleCollider))]
[RequireComponent(typeof (Rigidbody))]
public class AnimScript : MonoBehaviour
{
	[System.NonSerialized]					

	public float animSpeed = 1.25f;				
	public float lookSmoother = 3f;									
	private Animator anim;							
	private AnimatorStateInfo currentBaseState;		
	private CapsuleCollider col;					
	static int idleState = Animator.StringToHash("Base Layer.Idle");	
	static int runState = Animator.StringToHash("Base Layer.Runs");		
	static int jumpState = Animator.StringToHash("Base Layer.Jump");			

	void Start ()
	{

		anim = GetComponent<Animator>();					  
		col = GetComponent<CapsuleCollider>();				

		if(anim.layerCount ==2)
			anim.SetLayerWeight(1, 1);
	}
	
	void FixedUpdate ()
	{
		float h = Input.GetAxis("Horizontal");	
		float v = Input.GetAxis("Vertical");	
		anim.SetFloat("Speed", v);					
		anim.SetFloat("Direction", h); 			
		anim.speed = animSpeed;				
		currentBaseState = anim.GetCurrentAnimatorStateInfo(0);	

		if (currentBaseState.nameHash == runState)
		{
			if(Input.GetKeyDown(KeyCode.Space))
			{
				anim.SetBool("Jump", true);
			}
		}

		else if(currentBaseState.nameHash == jumpState)
		{

			if(!anim.IsInTransition(0))
			{
				col.height = anim.GetFloat("ColliderHeight");
				anim.SetBool("Jump", false);
			}
			
	
			Ray ray = new Ray(transform.position + Vector3.up, -Vector3.up);
			RaycastHit hitInfo = new RaycastHit();
			
			if (Physics.Raycast(ray, out hitInfo))
			{
				if (hitInfo.distance > 1.75f)
				{
					anim.MatchTarget(hitInfo.point, Quaternion.identity, AvatarTarget.Root, new MatchTargetWeightMask(new Vector3(0, 1, 0), 0), 0.35f, 0.5f);
				}
			}
		}
		
		

	}
}
