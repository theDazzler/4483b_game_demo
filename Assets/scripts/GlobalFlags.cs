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
}
