using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]

public class TotemScript : MonoBehaviour {
	public string collectedText = "You've collected a totem.";
	public string lockedText = "You must posess a human to pick up this totem!";
	public GameManager gameManager;
	public AudioClip pickupClip;
	public AudioClip failClip;
	AudioSource audio;

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource>();

		gameManager.addTotem (transform.name);
	}

	public void Pickup (GhostScript player) {
		if (player.poss) {
			gameManager.flashText(collectedText);
			gameManager.pickupTotem (transform.name);
			audio.clip = pickupClip;
			audio.Play();
			Destroy (gameObject, audio.clip.length);
		} else {
			gameManager.flashText(lockedText);
			audio.clip = failClip;
			audio.Play();
		}
	}
}
