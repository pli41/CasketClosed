using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DeathShowTime : MonoBehaviour {

	// Use this for initialization
	void Start () {
        float time = PlayerPrefs.GetFloat("time");
        
        GetComponent<Text>().text = time + " seconds";
	}
	

}
