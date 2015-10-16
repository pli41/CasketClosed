using UnityEngine;
using System.Collections;

public class TankScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.Rotate (0,0,50*Time.deltaTime); //rotates 50 degrees per second around z axis
	}
}
