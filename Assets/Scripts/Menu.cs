using UnityEngine;
using System.Collections;
using System.IO;

public class Menu : MonoBehaviour {
	string fileData;
	string[] lines;
	string[] lineData;

	public Ingredient[] ingredientList;
	public Drink[] drinkList;
	// Use this for initialization

	void Start () {
		fileData  = System.IO.File.ReadAllText("Assets\\Scripts\\IngredientList.csv");
		lines = fileData.Split (new char[]{ '\n' });
		ingredientList = new Ingredient[lines.Length];

		for(int i = 0; i < lines.Length-1; i++)
		{
			ingredientList [i] = new Ingredient ();
			lineData = lines[i].Split(',');
			ingredientList [i].model = (GameObject)Resources.Load(lineData [0]);
			ingredientList [i].ingredientName = lineData [1];
			ingredientList [i].color = lineData [2];
			ingredientList [i].code[0] = lineData[3][0];
			ingredientList [i].code [1] = lineData [4][0];
		}

		fileData  = System.IO.File.ReadAllText("Assets\\Scripts\\DrinkList.csv");
		Debug.Log (fileData);
		lines = fileData.Split (new char[]{ '\n' });

		drinkList = new Drink[lines.Length];

		for(int i = 0; i < lines.Length-1; i++)
		{
			drinkList[i] = new Drink();
			lineData = lines[i].Split(',');

			drinkList [i].drinkName = lineData [0];
			drinkList [i].ingredients [0] = FindIngredient(lineData [1]);
			drinkList [i].ingredients [1] = FindIngredient(lineData [2]);
			drinkList [i].ingredients [2] = FindIngredient(lineData [3]);

		}
	}


	public Ingredient FindIngredient(string name)
	{
		Ingredient ingredient = new Ingredient();
		for (int i = 0; i < ingredientList.Length - 1; i++) {
			ingredient = ingredientList [i];
			if (ingredient.ingredientName.Equals (name)) {
				break;
			}
		}
		return ingredient;
	}

	public Drink RandomDrink(){
		return drinkList[Random.Range(0, drinkList.Length - 1)];
	}
}
