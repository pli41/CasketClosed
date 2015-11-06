using UnityEngine;
using System.Collections;

public class SpiderPositionPrediction : MonoBehaviour {
	GameObject spider;
	// Use this for initialization
	void Start () {
		spider = GameObject.Find("spider");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 addVector = spider.transform.forward;
		Vector3 predictedPosition = spider.transform.position + addVector * 3;
		gameObject.transform.position = predictedPosition;
	}
}
