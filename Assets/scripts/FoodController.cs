using UnityEngine;
using System.Collections;

public class FoodController : MonoBehaviour 
{
	public float speed;

	public int pointValue;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate()
	{
		Vector2 verticalMovement = new Vector2 (0.0f, -speed);
		rigidbody2D.velocity = verticalMovement;

	}

	public int getValue(){
		return pointValue;
	}

}
