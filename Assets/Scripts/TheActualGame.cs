using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TheActualGame : MonoBehaviour {
	public float timer;
	public Text guiText;
	public Text endText;
	public GameObject endPanel;
	bool gamestarted;
	public int score;
	public int drinkNo;
	public int successes;
	// Use this for initialization
	void Start () {
		gamestarted = false;
		guiText.text = "";
		endPanel.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space)) {
			gamestarted = true;
		}
		if (gamestarted) {
			timer -= Time.deltaTime;
			guiText.text = "TIME LEFT: " + Mathf.RoundToInt (timer).ToString ();
		}

		if (timer <= 0f) {
			endText.text = "TOTAL DRINKS MADE: " + drinkNo + "\n" +
			"SUCCESSFUL ORDERS: " + successes + "\n" +
			"TOTAL SCORE: " + drinkNo * successes + "\n";
			endPanel.SetActive (true);
		}
	}
		
}
