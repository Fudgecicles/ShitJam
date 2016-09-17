using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TheActualGame : MonoBehaviour {
	public float timer;
	public Text guiText;
	public Text endText;
	bool gamestarted;
	public int score;
	public int drinkNo;
	public int successes;
	// Use this for initialization
	void Start () {
		gamestarted = false;
		guiText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space)) {
			gamestarted = true;
		}
		if (gamestarted) {
			timer -= Time.deltaTime;
			guiText.text = "Time Left: " + Mathf.RoundToInt (timer).ToString ();
		}

		if (timer <= 0f) {
			endText.text = "total drinks made: " + drinkNo + "\n" +
			"successful orders: " + successes + "\n" +
			"Total Score: " + drinkNo * successes + "\n";
		}
	}
		
}
