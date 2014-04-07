using UnityEngine;
using System.Collections;

public class facebook : MonoBehaviour {

	public Texture backgroundTexture;
	public Texture logo;

	void OnGUI(){
		//display background texture
		GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height), backgroundTexture);
		MenuUtils.drawMenuLabel("Facebook", logo);
		
		//displays our buttons
		if(GUI.Button(MenuUtils.itemRect(1), "Back to main menu")) {
			Application.LoadLevel(0);
		}
	}
}
