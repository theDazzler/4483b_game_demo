using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public Texture backgroundTexture;

	void OnGUI(){
		//display background texture
		GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height), backgroundTexture);

		//displays our buttons
		if(GUI.Button(buttonRect(1), "Play Game")) {
			Application.LoadLevel(1);
		}

		if(GUI.Button(buttonRect(2), "Options")) {
			Application.LoadLevel(2);
		}
		
		if(GUI.Button(buttonRect(3), "Highscores")) {
			Application.LoadLevel(3);
		}
		
		if(GUI.Button(buttonRect(4), "Help")) {
			Application.LoadLevel(4);
		}
		
		if(GUI.Button(buttonRect(5), "Exit")) {
			Application.Quit();
		}

		if(GUI.Button(buttonRect(6), "Facebook")) {
			print("facebook");
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
