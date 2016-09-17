using UnityEngine;
using System.Collections;
using System.IO;

public class Menu : MonoBehaviour {
	string fileData;
	string[] lines;
	string[] lineData;

	Drink[] drinkList;
	// Use this for initialization

	void Start () {
		//fileData  = System.IO.File.ReadAllText("IngredientList.csv");
//		lines = fileData.Split("/n");
		//lineData = (lines[0].Trim()).Split(","[0]);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
