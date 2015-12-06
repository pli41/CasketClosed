using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Death : MonoBehaviour {
	public AudioClip caughtByDeath;
	GameManager game;
	AudioSource audio;

	void Start() {
		GameObject gm = GameObject.Find("GameManager");
		game = gm.GetComponent<GameManager>();
		audio = GetComponent<AudioSource>();
	}

	void OnTriggerEnter(Collider target)
    {
        if (target.gameObject.tag.Equals("Player"))
        {
			CameraFollow camera = GameObject.Find("Main Camera").GetComponent<CameraFollow>();
			camera.player = transform;

			game.flashText("You've been caught by death. ", 2000);

			game.PauseGame();

			PlaySoundWithCallback(caughtByDeath, Die);
        }
    }

	public delegate void AudioCallback();

	void Die() {
		game.UnpauseGame();
		float totalTime = game.totalTime;
		Application.LoadLevel("DeathScreen");
		PlayerPrefs.SetFloat("time", totalTime);
	}

	public void PlaySoundWithCallback(AudioClip clip, AudioCallback callback)
	{
		audio.PlayOneShot(clip);
		StartCoroutine(DelayedCallback(clip.length, callback));
	}

	private IEnumerator DelayedCallback(float time, AudioCallback callback)
	{
		yield return new WaitForSeconds(time);
		callback();
	}
}
