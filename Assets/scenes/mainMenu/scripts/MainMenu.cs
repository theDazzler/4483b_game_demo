﻿using UnityEngine;
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
			print("Clicked options");
		}
		
		if(GUI.Button(buttonRect(3), "Highscores")) {
			print("Clicked highscores");
		}
		
		if(GUI.Button(buttonRect(4), "Help")) {
			print("Clicked help");
		}
		
		if(GUI.Button(buttonRect(5), "Exit")) {
			Application.Quit();
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
