using UnityEngine;
using System.Collections;

//Constrict player's movement to edge of screen
using System.Collections.Generic;


[System.Serializable]
public class LevelBounds
{
	public float xMin, xMax;
}

public class PlayerController : MonoBehaviour 
{
	public float speed;
	public LevelBounds levelBounds;

	public GUIText scoreLabel;
	public GUIText liveLabel;

	public AudioSource soundGood;
	public AudioSource soundBad;

	private float doomTimer = 15;
	private int lives;
		
	// Use this for initialization
	void Start () 
	{
		GlobalFlags.setLives (GlobalFlags.PLAYER_LIVES);
		scoreLabel.text = "Score: " + GlobalFlags.getScore();

		drawHearts();
		soundBad.volume = GlobalFlags.getSoundFXVolume();
		soundGood.volume = GlobalFlags.getSoundFXVolume();
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		scoreLabel.text = "" + GlobalFlags.getScore();
		if (GlobalFlags.getScore() < 0){
			doomTimer -= Time.deltaTime;
			if (doomTimer < 0){
				loseALife();
				GlobalFlags.setScore(0);
			}
		}
		else {
			doomTimer = 15;
		}


	}

	//physics
	void FixedUpdate()
	{
		float horizontalAxis = Input.GetAxis("Horizontal");
		//float verticalAxis = Input.GetAxis("Vertical");

		//move left and right
		Vector2 horizontalMovement = new Vector2 (horizontalAxis * speed, 0.0f);
		rigidbody2D.velocity = horizontalMovement;

		transform.position = new Vector2 (Mathf.Clamp(transform.position.x, levelBounds.xMin, levelBounds.xMax), transform.position.y);
	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.tag == "Food")
		{
			FoodController f = other.GetComponent<FoodController>();

			int value = f.getValueCaught();
			GlobalFlags.incrementScore(value);

			if(value < 0) soundBad.Play();
			else soundGood.Play();

			GlobalFlags.incrementScore(f.getValueCaught());

			GlobalFlags.incrementSpawnDelay(f.getReplenishRate());

			//Debug.Log("Score: " + GlobalFlags.getScore());
			if (f.isDeadly()){
				loseALife();
			}
			Destroy(other.gameObject);
		}
		/*
		else if(other.tag == "Player")
		{
			Destroy(gameObject);
		}*/
	}


	void drawHearts(){
		liveLabel.text = "";
		for (int i = 0; i < GlobalFlags.getLives(); i++){
			liveLabel.text = liveLabel.text + "♥";
		}
	}

	void loseALife(){
		GlobalFlags.loseLife();
		//GlobalFlags.setScore(0);
		doomTimer = 15;
		drawHearts();
	}
}
