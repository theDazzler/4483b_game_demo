﻿using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public Texture backgroundTexture;
	public Texture logo;
	public Texture facebook;

	void OnGUI(){
		//display background texture and logo and title
		GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height), backgroundTexture);
		MenuUtils.drawMenuLabel("Main Menu", logo);

		//displays our buttons
		if(GUI.Button(MenuUtils.itemRect(1), "Play Game")) {
			Application.LoadLevel(1);
		}

		if(GUI.Button(MenuUtils.itemRect(2), "Options")) {
			Application.LoadLevel(2);
		}
		
		if(GUI.Button(MenuUtils.itemRect(3), "Highscores")) {
			Application.LoadLevel(3);
		}
		
		if(GUI.Button(MenuUtils.itemRect(4), "Help")) {
			Application.LoadLevel(4);
		}
		
		if(GUI.Button(MenuUtils.itemRect(5), "Exit")) {
			Application.Quit();
		}

		/*if(GUI.Button(new Rect(0,0,100,30), "delete data")) {
			PlayerPrefs.DeleteAll();
		}*/
	}	
}
