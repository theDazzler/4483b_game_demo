using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public Texture backgroundTexture;

	void OnGUI(){
		//display background texture
		GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height), backgroundTexture);

		//displays our buttons
		if(GUI.Button(GlobalFlags.itemRect(1), "Play Game")) {
			Application.LoadLevel(1);
		}

		if(GUI.Button(GlobalFlags.itemRect(2), "Options")) {
			Application.LoadLevel(2);
		}
		
		if(GUI.Button(GlobalFlags.itemRect(3), "Highscores")) {
			Application.LoadLevel(3);
		}
		
		if(GUI.Button(GlobalFlags.itemRect(4), "Help")) {
			Application.LoadLevel(4);
		}
		
		if(GUI.Button(GlobalFlags.itemRect(5), "Exit")) {
			Application.Quit();
		}

		if(GUI.Button(GlobalFlags.itemRect(6), "Facebook")) {
			Application.LoadLevel(5);
		}
	}
}
