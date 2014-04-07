using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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

	/** sound **/

	
	private static string MUSIC_VOLUME_KEY = "MUSIC_VOLUME_KEY";
	private static string SOUNDFX_VOLUME_KEY = "SOUNDFX_VOLUME_KEY";
	private static float musicVolume = -1;
	private static float soundFXVolume = -1;

	//returns the current music volume of the game
	public static float getMusicVolume() {
		return musicVolume == -1
			? PlayerPrefs.GetFloat(MUSIC_VOLUME_KEY, -1) == -1 ? 0.5f : PlayerPrefs.GetFloat(MUSIC_VOLUME_KEY)
			: musicVolume
			;
	}

	//set the music volume of the game
	public static void setMusicVolume(float volume) {
		musicVolume = volume;
		PlayerPrefs.SetFloat(MUSIC_VOLUME_KEY, musicVolume);
	}

	//returns the current FX volume of the game
	public static float getSoundFXVolume() {
		return soundFXVolume == -1
			? PlayerPrefs.GetFloat(SOUNDFX_VOLUME_KEY, -1) == -1 ? 0.5f : PlayerPrefs.GetFloat(SOUNDFX_VOLUME_KEY)
			: soundFXVolume
			;
	}
	
	//set the FX volume of the game
	public static void setSoundFXVolume(float volume) {
		soundFXVolume = volume;
		PlayerPrefs.SetFloat(SOUNDFX_VOLUME_KEY, soundFXVolume);
	}

	/** highscores **/
	public class Highscore
	{
		public string Name { get; set; }
		public int Score { get; set; }
		public Highscore(string name, int score)
		{
			Name = name;
			Score = score;
		}
	}

	//all the recorded highscores of the game
	private static List<Highscore> highscores = null;

	public static List<Highscore> getHighscores() {
		highscores = highscores == null ? initHighscores() : highscores;
		return highscores;
	}

	public static void addHighscore(string name, int score) {
		Highscore currentScore = highscore(name);

		if(currentScore != null && currentScore.Score < score) {
			currentScore.Score = score;
			highscores = highscores.OrderByDescending(o=>o.Score).ToList(); 
		} else if(currentScore == null) {
			highscores.Add(new Highscore(name, score));
			highscores = highscores.OrderByDescending(o=>o.Score).ToList(); 
		}
	}

	private static Highscore highscore(string name) {
		foreach(Highscore hs in highscores) {
			if(hs.Name.Equals(name)) return hs;
		}
		return null;
	}

	//initializes highscores with saved highscore data. Just dummy method for now
	private static List<Highscore> initHighscores() {
		List<Highscore> hs = new List<Highscore>();
		hs.Add(new Highscore("Marge", 700));
		hs.Add(new Highscore("Bob", 300));
		hs.Add(new Highscore("Cindy", 400));
		hs.Add(new Highscore("Joe", 500));
		hs.Add(new Highscore("Eugene", 600));
		return hs.OrderByDescending(o=>o.Score).ToList();
	}
}
