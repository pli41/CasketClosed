using UnityEngine;
using System.Collections;

public class ObjectivePosition : Objective {
    private GameObject target;
    
    public ObjectivePosition(string text, GameObject lookfor)
    {
        target = lookfor;
        objectiveText = text;
    }
	
	// Update is called once per frame
	void Update () {
        float dist = (target.transform.position - transform.position).magnitude;
        if (dist < 1.5f) {
            accomplished = true;
        }
	}

    
}
