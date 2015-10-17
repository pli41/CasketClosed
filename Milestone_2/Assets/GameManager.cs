using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public enum MODE{text, image};
	GameObject[] furniture;
	public Text timerUI;
	public Image blinkUI;
	public MODE mode;
	private float currentPosTime;
	public float posessionTime;
	public float outOfBodyTime;
	public GameObject player;
    public string[] scenes = new string[5];
	GhostScript ghost;
	private float timer;
	private bool blinkRecover;
	public float flashSpeed;
	private float blinkTimer;
	private float resetTimer;
	private string scene;
	bool wasPossessing;
	// Use this for initialization
	void Start () {
		ghost = player.GetComponent<GhostScript> ();
		wasPossessing = false;
		currentPosTime = outOfBodyTime;
		blinkTimer = 0;
		furniture = GameObject.FindGameObjectsWithTag ("Chair");
		disablePhysics ();

		scene = scenes [0];
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Alpha1)){
			mode = MODE.text;
		}
		else if(Input.GetKeyDown(KeyCode.Alpha2)){
			mode = MODE.image;
		}
		if(Input.GetKey("1") || Input.GetKey("2") || Input.GetKey("3") || Input.GetKey("4") || Input.GetKey("5") || Input.GetKey("6"))
        {
            if (Input.GetKey("1"))
            {
                 scene = scenes[0];
            }
            if (Input.GetKey("2"))
            {
                scene = scenes[1];
            }
            if (Input.GetKey("3"))
            {
                scene = scenes[2];
            }
            if (Input.GetKey("4"))
            {
                scene = scenes[3];
            }
            if (Input.GetKey("5"))
            {
                scene = scenes[4];
            }
			if (Input.GetKey("6"))
			{
				scene = scenes[5];
			}
            Application.LoadLevel(scene);
        }
		if (!wasPossessing && ghost.poss) {
			wasPossessing = ghost.poss;
			currentPosTime = posessionTime;
			blinkTimer = 0;
			activatePhysics();
		} else if (wasPossessing && !ghost.poss) {
			wasPossessing = ghost.poss;
			currentPosTime = outOfBodyTime;
			blinkTimer = 0;
			disablePhysics();
		}
		if(currentPosTime > 0){
			resetTimer = 0;

			currentPosTime -= Time.deltaTime;
			if(mode == MODE.text){
				timerUI.enabled = true;
				blinkUI.enabled = false;
				timerUI.text = "Time: " + currentPosTime;
			}
			else if(mode == MODE.image){
				timerUI.text = "";
				blinkUI.color = new Vector4(1,1,1, Mathf.Min(.7f,((blinkTimer*.5f) / currentPosTime)*.2f));
			}
		}
		else{
			Reset();
		}

		blinkTimer += Time.deltaTime;
	}

	void Reset(){
		Debug.Log ("Resetting");
		timerUI.text = "Time: 0";
		if (ghost.poss) {
			ghost.npc.GetComponent<Possessible> ().dePossess ();
		} else {
			Application.LoadLevel (scene);
		}
	}
	void activatePhysics(){
		foreach (GameObject chair in furniture) {
			chair.GetComponent<Rigidbody> ().isKinematic = false;
			chair.GetComponent<Collider> ().enabled = true;
		}
	}

	void disablePhysics(){
		foreach (GameObject chair in furniture) {
			chair.GetComponent<Rigidbody> ().isKinematic = true;
			chair.GetComponent<Collider> ().enabled = false;
		}
	}

	void Blink(){
		blinkUI.color = new Vector4(1,1,1,.5f);
		blinkRecover = true;
		blinkTimer = 0;
	}

	void EndBlink(){
		blinkTimer += Time.deltaTime;
		flashSpeed = 3f - currentPosTime / 10f;
		blinkUI.color = Color.Lerp( new Vector4(1,1,1,.5f), Color.clear, flashSpeed * blinkTimer);
		if(blinkUI.color == Color.clear){
			blinkRecover = false;
		}
	}
	
}
