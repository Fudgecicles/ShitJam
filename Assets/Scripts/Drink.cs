using UnityEngine;
using System.Collections;

public class Drink : MonoBehaviour {
	Ingredient[] ingredients;
	// Use this for initialization
	void Start () {
	
	}

	class Ingredient : MonoBehaviour {
		GameObject model;
		string name;
		Color color;
		KeyCode[] code;
	}
}
