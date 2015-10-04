using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	private int m_LastIndex;
	public Animation anim; 

	// Use this for initialization
	public void PlayDoorAnim () {
		anim = GetComponent<Animation> ();

		if (m_LastIndex == 0) {
			anim.Play("DoorOpen");
			m_LastIndex = 1;
		} else {
			anim.Play("DoorClose");
			m_LastIndex = 0;
		}

	}
	

}
