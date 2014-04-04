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
	public GameObject cottonCandy;
	
	//bad foods
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
		
		//for (int i = 0; i < foodCount; i++)
		while (true)
		{
			Vector2 spawnPosition = new Vector2 (Random.Range (spawnRangeX.x, spawnRangeX.y), Random.Range (spawnRangeY.x, spawnRangeY.y));
			Quaternion spawnRotation = Quaternion.identity;
			Instantiate(apple, spawnPosition, spawnRotation);
			yield return new WaitForSeconds(spawnDelay);
		}
	}
}
