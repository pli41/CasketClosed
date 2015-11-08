using UnityEngine;
using System.Collections;

public class CameraOrbit : MonoBehaviour {
    public GameObject target;
    float radius;
	// Use this for initialization
	void Start () {
        transform.LookAt(target.transform);
        radius = 5;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(Mathf.Sin(Time.time/2) * radius, 2, Mathf.Cos(Time.time/2) * radius-2);
        transform.LookAt(target.transform);
	}
}
