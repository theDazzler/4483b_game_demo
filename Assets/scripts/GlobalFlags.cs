using UnityEngine;
using System.Collections;

public class GlobalFlags : MonoBehaviour {

	private static int score = 0; //the player's score in a single game
	private static int lives = 3; //the player's lives

	//set the players score
	public static void setScore(int s){
		score = s;
	}

	//increments the player's score, also can decremenent if passed
	//a negative number.
	//if score is less then 0, set it to 0. There shouldn't be a negative score.
	public static void incrementScore(int add){
		score += add;
		/*if (score < 0){
			score = 0;
		}*/
	}

	//retreive the player's score
	public static int getScore(){
		return score;
	}

	//sets the number of lives
	public static void setLives (int l){
		lives = l;
	}

	//removes 1 from the player's total lives
	public static void loseLife(){
		lives--;
		if (lives < 0){
			lives = 0;
		}
	}

	//returns the number of lives
	public static int getLives(){
		return lives;
	}

	//Main Menu utils
	//itemRect - used to return a positioned rectangle (for a menu button) based on menu item number
	//use itemRect(itemNumber) for default starting position
	//use itemRect(int itemNumber, float startingPlacement, float startingOffset) for custom
	public static Rect itemRect(int itemNumber){
		return itemRect(itemNumber, -1, -1);
	}
	public static Rect itemRect(int itemNumber, float startingPlacement, float startingOffset){
		return new Rect(Screen.width * 0.25f, top(
					itemNumber
				, 	startingPlacement==-1 ? 0.2f : startingPlacement
				,	startingOffset==-1 ? 0.125f : startingOffset 
			), Screen.width * 0.5f, Screen.height * 0.1f);
	}
	public static float top(int itemNumber, float itemPlacementY, float itemOffsetY){
		return Screen.height * (itemPlacementY + itemOffsetY * itemNumber);
	}
	public static GUIStyle menuTitleStyle() {
		GUIStyle style = new GUIStyle();
		style.fontSize = 20;
		style.normal.textColor = Color.white;
		style.alignment = TextAnchor.MiddleCenter;
		return style;
	}
	public static void drawMenuLabel(string title, Texture logo) {
		GUI.DrawTexture(new Rect(20.0f,30.0f,75.0f,75.0f), logo);
		GUI.Label(new Rect(180.0f, 55.0f, 50.0f, 20.0f), title, GlobalFlags.menuTitleStyle());
	}
}
