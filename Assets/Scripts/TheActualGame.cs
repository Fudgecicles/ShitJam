using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TheActualGame : MonoBehaviour {
	public float timer;
	public Text guitext;
	bool gamestarted;
	// Use this for initialization
	void Start () {
		gamestarted = false;
		guitext.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space)) {
			gamestarted = true;
		}
		if (gamestarted) {
			timer -= Time.deltaTime;
			guitext.text = "Time Left: " + Mathf.RoundToInt (timer).ToString ();
		}
	}
		
}
