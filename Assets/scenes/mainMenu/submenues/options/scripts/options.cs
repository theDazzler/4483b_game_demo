using UnityEngine;
using System.Collections;

public class options : MonoBehaviour {
	public Texture backgroundTexture;
	
	void OnGUI(){
		//display background texture
		GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height), backgroundTexture);
		
		//displays our buttons
		if(GUI.Button(GlobalFlags.itemRect(1), "Back to main menu")) {
			Application.LoadLevel(0);
		}
	}
}
