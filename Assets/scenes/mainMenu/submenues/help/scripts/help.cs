using UnityEngine;
using System.Collections;

public class help : MonoBehaviour {

	public Texture backgroundTexture;
	public Texture logo;

	void OnGUI(){
		//display background texture
		GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height), backgroundTexture);
		MenuUtils.drawMenuLabel("Help", logo);

		GUI.Label(MenuUtils.itemRect(1), instructions(), MenuUtils.menuParagraphStyle());
		
		MenuUtils.drawBackToMainMenuButton();
	}

	private static string instructions(){
		return 
			"Avoid the unhealthy foods or else you will lose points"
		+	"\n\nCatch the healthy foods to gain points" 
		+	"\n\nCertain foods will give you a power-up" 
		+	"\n\nYou start with 3 lives and lose one for each special unhealthy food you eat, indicated by the image of the food in the top left of the screen" 
		+ 	"\n\nIf you lose all of your lives, you lose"
		;
	}
}
