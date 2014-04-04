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


			// Use this for initialization
			void Start () 
			{
				Time.timeScale = 1;
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
			IEnumerator spawnFood()
			{
				yield return new WaitForSeconds(levelWait);

				for (int i = 0; i < foodCount; i++)
				{
					Vector2 spawnPosition = new Vector2 (Random.Range (spawnRangeX.x, spawnRangeX.y), Random.Range (spawnRangeY.x, spawnRangeY.y));
					Quaternion spawnRotation = Quaternion.identity;
					Instantiate(food, spawnPosition, spawnRotation);
					yield return new WaitForSeconds(spawnDelay);
				}
			}
		}
