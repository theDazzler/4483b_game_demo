using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class highscores : MonoBehaviour {

	public Texture backgroundTexture;
	public Texture logo;
	
	void OnGUI(){
		//display background texture
		GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height), backgroundTexture);
		MenuUtils.drawMenuLabel("Highscores", logo);
		MenuUtils.drawBackToMainMenuButton();

		List<GlobalFlags.Highscore> highscores = GlobalFlags.getHighscores();
		GlobalFlags.Highscore hs = null;

		int max = highscores.Count > 4 ? 5 : highscores.Count;

		//display the top 5 scores
		for(int i = 0; i < max; i++) {
			hs = highscores[i];
			GUI.Label(MenuUtils.itemRect(i + 1), hs.Name + ": " + hs.Score, MenuUtils.menuItemLabelStyle());
		}

		/* for manually adding highscores
		if(GUI.Button(new Rect(0,0,20,60), "woot")) {
			GlobalFlags.addHighscore("Ali", 999);
		}*/
	}
}
