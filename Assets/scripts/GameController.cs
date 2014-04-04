using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{
	public Vector2 spawnRangeX;
	public Vector2 spawnRangeY;
	public int foodCount;
	public float spawnDelay;
	public float levelWait;
	
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
	
	// Use this for initialization
	void Start () 
	{
		StartCoroutine(spawnFood());
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown ("space") || Input.GetKeyDown ("p")) {
			Application.LoadLevel(6);
		}
	}
	
	//spawn food using timer
	IEnumerator spawnFood()
	{
		yield return new WaitForSeconds(levelWait);
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
			if (spawnDelay < 0.1 ){
				spawnDelay = 0.1f;
			}
			yield return new WaitForSeconds(spawnDelay);
		}
	}
}
