using UnityEngine;
using System.Collections;

public class GlobalFlags : MonoBehaviour {

	private static int score = 0; //the player's score in a single game

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

}
