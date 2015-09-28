using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public enum MODE{text, image};

	public Text timerUI;
	public Image blinkUI;
	public MODE mode;
	public float currentPosTime;

	private float timer;
	private bool blinkRecover;
	public float flashSpeed;
	private float blinkTimer;
	private float resetTimer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Alpha1)){
			mode = MODE.text;
		}
		else if(Input.GetKeyDown(KeyCode.Alpha2)){
			mode = MODE.image;
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
				timerUI.enabled = false;
				blinkUI.enabled = true;
				if(!blinkRecover){
					Blink();
				}
				else{
					EndBlink();
				}

			}
		}
		else{
			Reset();
		}



	}

	void Reset(){
		Debug.Log ("Resetting");
		timerUI.text = "Time: 0";
		resetTimer += flashSpeed * Time.deltaTime;
		blinkUI.color = Color.Lerp(Color.red, Color.clear, resetTimer);
	}

	void Blink(){
		blinkUI.color = Color.red;
		blinkRecover = true;
		blinkTimer = 0;
	}

	void EndBlink(){
		blinkTimer += Time.deltaTime;
		flashSpeed = 3f - currentPosTime / 10f;
		blinkUI.color = Color.Lerp(Color.red, Color.clear, flashSpeed * blinkTimer);
		if(blinkUI.color == Color.clear){
			blinkRecover = false;
		}
	}
	
}
