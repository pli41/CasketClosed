using UnityEngine;
using System.Collections;

public class tempController : MonoBehaviour {
	private bool poss;
	GameObject npc;
	// Use this for initialization
	void Start () {
		poss = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(!poss && Input.GetAxisRaw("Horizontal") != 0){
			gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(Input.GetAxisRaw("Horizontal")*30,0,0));
		} 
		if(!poss && Input.GetAxisRaw("Vertical") != 0){
			gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0,0,Input.GetAxisRaw("Vertical")*30));
		}

		if (Input.GetKey (KeyCode.Space)) {

			Debug.Log ("trying to possess");
			possess ();
		}

	}

	void OnTriggerEnter(Collider target){
		if (target.tag.Equals ("NPC")) {
			npc = target.gameObject;
		}
	}

	void OnTriggerExit(){
		npc = null;
	}

	void possess(){
		if (poss && npc) {
			npc.GetComponent<Possessible> ().dePossess ();
		
			poss = !poss;
		} else if (!poss && npc) {
			Debug.Log("ask NPC to possess");
			npc.GetComponent<Possessible> ().possess ();

			poss = !poss;
		}
	}
	IEnumerator Example() {
		yield return new WaitForSeconds(2);
	}
}
