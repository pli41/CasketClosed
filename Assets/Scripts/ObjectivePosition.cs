using UnityEngine;
using System.Collections;

public class ObjectivePosition : Objective {
    private GameObject target;
    private GameObject player;
    public ObjectivePosition(string text, GameObject lookfor)
    {
        target = lookfor;
        player = GameObject.FindGameObjectWithTag("Player");
        objectiveText = text;
    }
	

	public override void Checked() {
        float dist = (target.transform.position - player.transform.position).magnitude;
        if (dist < 3f) {
            accomplished = true;
        }
	}

    
}
