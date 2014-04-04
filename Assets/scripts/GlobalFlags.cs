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
		if (score < 0){
			score = 0;
		}
	}

	//retreive the player's score
	public static int getScore(){
		return score;
	}

}
