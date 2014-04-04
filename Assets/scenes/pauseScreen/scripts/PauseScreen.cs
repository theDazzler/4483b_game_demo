using UnityEngine;
using System.Collections;

public class PauseScreen : MonoBehaviour {

	public Texture backgroundTexture;

	void OnGUI(){
		//Display background
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), backgroundTexture);

		//Display buttons

		if(GUI.Button (buttonRect (1), "Resume")){
			Application.LoadLevel(1);
		}
		if(GUI.Button(buttonRect(2), "Options")) {
			Application.LoadLevel(2);
		}
		
		if(GUI.Button(buttonRect(3), "High Scores")) {
			Application.LoadLevel (3);
		}
		
		if(GUI.Button(buttonRect(4), "Help")) {
			Application.LoadLevel (4);
		}
		
		if(GUI.Button(buttonRect(5), "Exit")) {
			Application.LoadLevel (0);
		}
		

	}
	
	Rect buttonRect(int buttonNumber){
		return new Rect(Screen.width * 0.25f, top(buttonNumber), Screen.width * 0.5f, Screen.height * 0.1f);
	}
	
	float top(int buttonNumber){
		float buttonPlacementY = 0.2f;
		float buttonOffsetY = 0.125f;
		
		return Screen.height * (buttonPlacementY + buttonOffsetY * buttonNumber);
	}
	
}