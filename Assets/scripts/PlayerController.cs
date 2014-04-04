using UnityEngine;
using System.Collections;

//Constrict player's movement to edge of screen
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
	
	// Use this for initialization
	void Start () 
	{
		scoreLabel.text = "Score: " + GlobalFlags.getScore();
		liveLabel.text = "";
		for (int i = 0; i < GlobalFlags.getLives(); i++){
			liveLabel.text = liveLabel.text + "♥";
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		scoreLabel.text = "" + GlobalFlags.getScore();
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
			GlobalFlags.incrementScore(f.getValueCaught());
			Debug.Log("Score: " + GlobalFlags.getScore());
			Destroy(other.gameObject);
		}
		/*
		else if(other.tag == "Player")
		{
			Destroy(gameObject);
		}*/
	}
}
