using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour 
{
	private const float LETHAL_FOOD_CHANGE_TIMER = 20;

	public Vector2 spawnRangeX;
	public Vector2 spawnRangeY;
	public GameObject food;
	public int foodCount;
	public float spawnDelay;
	public float levelWait;
	public bool isPaused = false;
	public GUISkin pauseBack;

	public GUIText messageLabel;
	public GUIText timerLabel;

	public GUITexture lethalFoodTexture;

	private List<GameObject> lethalFoods;
	private GameObject currentLethalFood;

	//good foods 
	public GameObject apple;
	public GameObject brussel;
	public GameObject roastChicken;
	public GameObject water;

	//bad foods
	public GameObject cottonCandy;
	public GameObject donut;
	public GameObject friedChicken;
	public GameObject cake;
	public GameObject chips;

	private bool gameOver;

	private float lethalFoodChangeTimer = LETHAL_FOOD_CHANGE_TIMER;


	// Use this for initialization
	void Start () 
	{
		GlobalFlags.setScore (0);
		GlobalFlags.setLives (GlobalFlags.PLAYER_LIVES);
		gameOver = false;

		this.messageLabel.enabled = false;

		lethalFoods = new List<GameObject> ();

		lethalFoods.Add (cottonCandy);
		lethalFoods.Add (donut);
		lethalFoods.Add (friedChicken);
		lethalFoods.Add (cake);
		lethalFoods.Add (chips);

		setLethalFood ();

		Time.timeScale = 1;
		StartCoroutine(spawnFood());
	}
	
	// Update is called once per frame
	void Update () 
	{
		Debug.Log (lethalFoodChangeTimer);

		if (Input.GetKeyDown ("space") || Input.GetKeyDown ("p")) {
			isPaused = !isPaused;
			if(isPaused){
				Time.timeScale = 0;
							
			}
			else {
				Time.timeScale = 1;

			}
		}

		lethalFoodChangeTimer -= Time.deltaTime;
		if(lethalFoodChangeTimer < 0)
		{
			setLethalFood();
			lethalFoodChangeTimer = LETHAL_FOOD_CHANGE_TIMER;
			
		}

		if (GlobalFlags.getLives() == 0) 
		{
			//player loses
			messageLabel.text = "Game Over";
			messageLabel.enabled = true;
			Time.timeScale = 0;
			gameOver = true;
			//this.isPaused = true;


		}



	}
	void OnGUI(){
		if (isPaused) {
						//Display background
			GUI.skin = pauseBack;
						GUI.Box (new Rect (0, 0, Screen.width, Screen.height),"");

						//Display buttons
		
						if (GUI.Button (buttonRect (1), "Resume")) {
							isPaused = !isPaused;
							Time.timeScale = 1;
						}
						if (GUI.Button (buttonRect (2), "Options")) {
								Application.LoadLevel (2);
						}
		
						if (GUI.Button (buttonRect (3), "High Scores")) {
								Application.LoadLevel (3);
						}
		
						if (GUI.Button (buttonRect (4), "Help")) {
								Application.LoadLevel (4);
						}
		
						if (GUI.Button (buttonRect (5), "Exit")) {
								Application.LoadLevel (0);
						}
		
				}




		if (gameOver) 
		{
			if (GUI.Button (buttonRect (4), "High Scores")) {
				Application.LoadLevel (3);
			}
			
			if (GUI.Button (buttonRect (5), "Exit")) {
				Application.LoadLevel (0);
			}	
		
		}


	}
	
	Rect buttonRect(int buttonNumber){
		return new Rect(Screen.width * 0.25f, top(buttonNumber), Screen.width * 0.5f, Screen.height * 0.1f);
	}
	
	float top(int buttonNumber){
		float buttonPlacementY = 0.2f;
		float buttonOffsetY = 0.125f;
		
		return Screen.height * (buttonPlacementY + buttonOffsetY * buttonNumber);
	}

	void setLethalFood()
	{
		if (this.currentLethalFood != null) 
		{
			FoodController f = this.currentLethalFood.GetComponent<FoodController>();

			f.setDeadly (false);
		}

		int foodIndex = UnityEngine.Random.Range(0, this.lethalFoods.Count);
		this.currentLethalFood = this.lethalFoods [foodIndex];
		Texture lethalTexture = this.currentLethalFood.GetComponent<SpriteRenderer> ().sprite.texture;

		lethalFoodTexture.texture = lethalTexture;

		FoodController foodCont = this.currentLethalFood.GetComponent<FoodController>();
		foodCont.setDeadly (true);

	}

	//spawn food using timer
//spawn food using timer
IEnumerator spawnFood()
{
		while (levelWait >= 0)
		{
			yield return new WaitForSeconds(1);

			timerLabel.enabled = true;
			timerLabel.text = "" + levelWait;
			levelWait--;

		}

		timerLabel.enabled = false;
	

	float rand;
	//for (int i = 0; i < foodCount; i++)
	while (true)
	{
		Vector2 spawnPosition = new Vector2 (Random.Range (spawnRangeX.x, spawnRangeX.y), Random.Range (spawnRangeY.x, spawnRangeY.y));
		Quaternion spawnRotation = Quaternion.identity;
		rand = Random.Range(0.0f, 100.0f);
		if (rand < 10){
			Instantiate(apple, spawnPosition, spawnRotation);
		}
		else if(rand < 20){
			Instantiate(brussel, spawnPosition, spawnRotation);
		}
		else if(rand < 30){
			Instantiate(roastChicken, spawnPosition, spawnRotation);
		}
		else if(rand < 40){
			Instantiate(water, spawnPosition, spawnRotation);
		}
		else if(rand < 50){
			Instantiate(cottonCandy, spawnPosition, spawnRotation);
		}
		else if(rand < 60){
			Instantiate(donut, spawnPosition, spawnRotation);
		}
		else if(rand < 70){
			Instantiate(friedChicken, spawnPosition, spawnRotation);
		}
		else if(rand < 80){
			Instantiate(cake, spawnPosition, spawnRotation);
		}
		else if(rand < 90){
			Instantiate(chips, spawnPosition, spawnRotation);
		}
		else{
			Instantiate(apple, spawnPosition, spawnRotation);
		}
		spawnDelay -= 0.01f;
		if (spawnDelay < 0.1f ){
			spawnDelay = 0.1f ;
		}
		yield return new WaitForSeconds(spawnDelay);
		}
	}
}
