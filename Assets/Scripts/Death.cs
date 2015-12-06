using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour {

	void OnTriggerEnter(Collider target)
    {
        if (target.gameObject.tag.Equals("Player"))
        {
            GameObject gm = GameObject.Find("GameManager");
            GameManager game = gm.GetComponent<GameManager>();
            float totalTime = game.totalTime;
            Application.LoadLevel("DeathScreen");
            PlayerPrefs.SetFloat("time", totalTime);
        }
    }
}
