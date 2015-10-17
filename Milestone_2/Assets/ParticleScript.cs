using UnityEngine;
using System.Collections;

public class ParticleScript : MonoBehaviour {
	public GameObject player;
	public string particleState;

	private Animator playerAnim;
	private ParticleSystem particles;

	// Use this for initialization
	void Start () {
		playerAnim = player.GetComponent<Animator> ();
		particles = GetComponent<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (playerAnim.GetCurrentAnimatorStateInfo (0).IsName (particleState)) {
			particles.enableEmission = true;
		} else {
			particles.enableEmission = false;
		}
		print (particles.enableEmission);
	}
}
