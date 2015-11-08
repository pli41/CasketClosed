using UnityEngine;
using System.Collections;

public class ObjectivePosssession : Objective {
    private GameObject target;
    private string name;
    private GameObject[] targets;
	private enum MODE {ALLNPC, ONETARGET, ONETYPEOFTARGET};
    private MODE mode;
    public ObjectivePosssession(string text)
    {
        objectiveText = text;
        targets = GameObject.FindGameObjectsWithTag("NPC");
        mode = MODE.ALLNPC;
    }

    public ObjectivePosssession(string text, string name)
    {
        objectiveText = text;
        target = GameObject.Find(name);
        mode = MODE.ONETARGET;
    }

    public ObjectivePosssession(string text, GameObject[] targets)
    {
        this.targets = targets;
        objectiveText = text;
        mode = MODE.ONETYPEOFTARGET;
    }
	// Update is called once per frame
	public override void Checked(){
        Possessible script;
        switch (mode)
        {
            case MODE.ALLNPC:
                foreach(GameObject obj in targets)
                {
                    script = obj.GetComponent<Possessible>();
                    if (script.isPossessed)
                    {
                        accomplished = true;
                    }
                }
                break;
            case MODE.ONETARGET:
                script = target.GetComponent<Possessible>();
                if (script.isPossessed)
                {
                    accomplished = true;
                }
                break;
            case MODE.ONETYPEOFTARGET:
                foreach (GameObject obj in targets)
                {
                    script = obj.GetComponent<Possessible>();
                    if (script.isPossessed)
                    {
                        accomplished = true;
                    }
                }
                break;
        }
	}
}
