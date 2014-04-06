using UnityEngine;
using System.Collections;

public class options : MonoBehaviour {
	public Texture backgroundTexture;
	public Texture logo;
	
	void OnGUI(){
		//display background texture
		GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height), backgroundTexture);
		GlobalFlags.drawMenuLabel("Options", logo);
		
		//displays our buttons
		if(GUI.Button(GlobalFlags.itemRect(1), "Back to main menu")) {
			Application.LoadLevel(0);
		}
	}
}
