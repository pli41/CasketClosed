using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    ArrayList objectives;
    private Text objectiveText;
    private int currentObjective;
	public enum MODE{text, image};
	GameObject[] furniture;
	public Text timerUI;
	public Image blinkUI;
	public MODE mode;
    private float totalTime;
	private float currentPosTime;
	public float posessionTime;
	public float outOfBodyTime;
	public GameObject player;
	GhostScript ghost;
	private float timer;
	private bool blinkRecover;
	public float flashSpeed;
	private float blinkTimer;
	private float resetTimer;
	bool wasPossessing;
 
	// Use this for initialization
	void Start () {
       
        objectiveText = GameObject.Find("ObjectiveText").GetComponent<Text>();
        objectives = new ArrayList();
		ghost = player.GetComponent<GhostScript> ();
      
		wasPossessing = false;
		currentPosTime = outOfBodyTime;
		blinkTimer = 0;
        totalTime = 0;
		furniture = GameObject.FindGameObjectsWithTag ("Chair");
        makeObjectives();
        currentObjective = 1;
		
	}
	private void makeObjectives()
    {
        Objective one = new ObjectivePosition("Go To the coffin", GameObject.Find("Coffin"));
        objectiveText.text = one.getText();
        objectives.Add(one);
        Objective two = new ObjectivePosssession("Possess the man in the purple shirt", "Man");
        objectives.Add(two);
        Objective three = new ObjectivePosition("Go to the woman in the red shirt", GameObject.Find("femaleNPC 1"));
        objectives.Add(three);
        Objective four = new ObjectivePosssession("Possess the woman in the red shirt", "femaleNPC 1");
        objectives.Add(four);
    }
	// Update is called once per frame
	void Update () {
        totalTime += Time.deltaTime;
        checkObjective();
		if(Input.GetKeyDown(KeyCode.Alpha1)){
			mode = MODE.text;
		}
		else if(Input.GetKeyDown(KeyCode.Alpha2)){
			mode = MODE.image;
		}
		if (!wasPossessing && ghost.poss) {
			wasPossessing = ghost.poss;
			currentPosTime = posessionTime;
			blinkTimer = 0;

		} else if (wasPossessing && !ghost.poss) {
			wasPossessing = ghost.poss;
			currentPosTime = outOfBodyTime;
			blinkTimer = 0;
	
		}
		if(currentPosTime > 0){
			resetTimer = 0;

			currentPosTime -= Time.deltaTime;
			if(mode == MODE.text){
				timerUI.enabled = true;
				blinkUI.enabled = false;
				timerUI.text = "Time: " + currentPosTime.ToString("F2");
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

    void checkObjective()
    {
        if (currentObjective <= objectives.Count)
        {
            Objective current = (Objective)objectives[currentObjective - 1];
            objectiveText.text = current.getText();
            current.Checked();
            if (current.isAccomplished())
            {
                currentObjective += 1;
                currentPosTime += current.bonus();
            }
        } else {
            objectiveText.text = "No More Objectives";
        }
    }

	void Reset(){
		Debug.Log ("Resetting");
		timerUI.text = "Time: 0";
		if (ghost.poss) {
			ghost.npc.GetComponent<Possessible> ().dePossess ();
		} else {
			Application.LoadLevel ("DeathScreen");
            PlayerPrefs.SetFloat("time", totalTime);
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
