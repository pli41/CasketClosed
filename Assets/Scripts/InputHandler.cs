using UnityEngine;
using System.Collections;

public class InputHandler : MonoBehaviour {
	
	void Update(){

//		for anything we click on in the future to be returned with it's tag for processing.
		if(Input.GetMouseButton(0)){

			GameObject clickedGmObj = null;
			if(Input.GetMouseButtonDown(0)){

				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;
				// Casts the ray and get the first game object hit
				if (Physics.Raycast (ray.origin, ray.direction, out hit, Mathf.Infinity)) {
					if(hit.transform.gameObject.tag == "Door"){
						Debug.Log("Clicked on door");
						Door door = hit.transform.GetComponent<Door>();
						if(door){
							Debug.Log("Playing animation to open door");
							door.PlayDoorAnim();
						}
					}
				}



//				clickedGmObj = GetClickedGameObject();
//				if(clickedGmObj != null && clickedGmObj.tag=="Door"){
//
//					Door door = clickedGmObj.GetComponent<Door>();
//

//					Door door = clickedGmObj.GetComponent<Door>();

//				}
			}
			
		}
		
	}
	
	GameObject GetClickedGameObject(){
		// Builds a ray from camera point of view to the mouse position
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		// Casts the ray and get the first game object hit
		if (Physics.Raycast (ray.origin, ray.direction, out hit, Mathf.Infinity)) {
			return hit.transform.gameObject;
		} else {
			return null;
		}
	}
}
