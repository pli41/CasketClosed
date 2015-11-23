using UnityEngine;
using System.Collections;

public class CreditExit : MonoBehaviour {

	
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.LoadLevel("StartScreen");
        }
	}

    public void Exit()
    {
        Application.LoadLevel("StartScreen");
    }
}
