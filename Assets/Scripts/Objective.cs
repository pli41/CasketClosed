using UnityEngine;
using System.Collections;

public class Objective{
    protected float timeBonus = 15;
    protected string objectiveText;
	protected bool accomplished;

    public bool isAccomplished()
    {

        return accomplished;
    }

    public float bonus()
    {
        return timeBonus;
    }

    public string getText()
    {
        return objectiveText;
    }
    public virtual void Checked() { }
}
