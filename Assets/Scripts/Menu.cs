using UnityEngine;
using System.Collections;
using System.IO;

public class Menu : MonoBehaviour {
	string fileData;
	string[] lines;
	string[] lineData;

	Ingredient[] ingredientList;
	// Use this for initialization

	void Start () {
		fileData  = System.IO.File.ReadAllText("Assets\\Scripts\\IngredientList.csv");
		lines = fileData.Split (new char[]{ '\n' });
		Debug.Log (fileData);
		ingredientList = new Ingredient[lines.Length];

		for(int i = 0; i < lines.Length-1; i++)
		{
			ingredientList [i] = new Ingredient ();
			lineData = lines[i].Split(',');
			//ingredientList [i].model = lineData [0];
			ingredientList [i].ingredientName = lineData [1];
			ingredientList [i].color = lineData [2];
			ingredientList [i].code[0] =(KeyCode) System.Enum.Parse(typeof(KeyCode), lineData[3]) ;
			ingredientList [i].code[0] =(KeyCode) System.Enum.Parse(typeof(KeyCode), lineData[4]) ;

			Debug.Log (ingredientList [i].ingredientName);

		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
