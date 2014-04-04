using UnityEngine;
using System.Collections;

public class FoodController : MonoBehaviour 
{
	public float speed;

	public int pointValueCaught;

	public int pointValueMissed;

	public bool deadly;

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

	public bool isDeadly(){
		return deadly;
	}

	public void setDeadly(bool d){
		deadly = d;
	}

	public int getValueCaught(){
		return pointValueCaught;
	}

	public int getValueMissed(){
		return pointValueMissed;
	}

}
