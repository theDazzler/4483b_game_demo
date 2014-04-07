using UnityEngine;
using System.Collections;

public class DestroyFoodOnEnter : MonoBehaviour
{

	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.tag == "Food")
		{
			FoodController f = other.GetComponent<FoodController>();
			GlobalFlags.incrementScore(f.getValueMissed());
			//Debug.Log("Score: " + GlobalFlags.getScore());
			Destroy(other.gameObject);
		}
		/*
		else if(other.tag == "Player")
		{
			Destroy(gameObject);
		}*/
	}

}
