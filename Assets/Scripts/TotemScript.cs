using UnityEngine;
using System.Collections;

public class TotemScript : MonoBehaviour {
	public string collectedText = "You've collected a totem.";
	public string lockedText = "You must posess a human to pick up this totem!";
	public GameManager gameManager;

	// Use this for initialization
	void Start () {
		gameManager.addTotem (transform.name);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
