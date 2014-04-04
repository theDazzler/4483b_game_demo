		using UnityEngine;
		using System.Collections;

		public class GameController : MonoBehaviour 
		{
			public Vector2 spawnRangeX;
			public Vector2 spawnRangeY;
			public GameObject food;
			public int foodCount;
			public float spawnDelay;
			public float levelWait;
			public bool isPaused = false;
			public GUISkin pauseBack;

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
					isPaused = !isPaused;
					if(isPaused){
						Time.timeScale = 0;
									
					}
					else {
						Time.timeScale = 1;

					}
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

			}
			
			Rect buttonRect(int buttonNumber){
				return new Rect(Screen.width * 0.25f, top(buttonNumber), Screen.width * 0.5f, Screen.height * 0.1f);
			}
			
			float top(int buttonNumber){
				float buttonPlacementY = 0.2f;
				float buttonOffsetY = 0.125f;
				
				return Screen.height * (buttonPlacementY + buttonOffsetY * buttonNumber);
			}

			//spawn food using timer
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
			if (spawnDelay < 0.1f ){
				spawnDelay = 0.1f ;
			}
			yield return new WaitForSeconds(spawnDelay);
			}
		}
}
