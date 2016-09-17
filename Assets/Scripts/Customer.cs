using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.CinematicEffects;

public class Customer : MonoBehaviour {
	public GameObject cubeman;
	private GameObject cubemanInstance;
	public Text dialogue;
	public Text []codeArray;
	public char []codes;
	int letter;
	public string ingredientOne;
	public string ingredientTwo;
	public string ingredientThree;
	public Transform cup;
	public GameObject ingredient;
	public Drink customerDrink;

	public Text ingredientOneName;
	public Text ingredientTwoName;
	public Text ingredientThreeName;

	Vector3 ingredientPosition;

	// Use this for initialization
	void Start () {
		ingredientPosition = new Vector3 (29.41386f, 9.313f, 30.484f);
	
	}
	
	// Update is called once per frame
	void Update () {


		if (Input.GetKeyDown (KeyCode.Space)) {
			NewCustomer ();
			TextChange ();
			codes = new char[6];
			letter = 0;
		} else {

			if (cubemanInstance != null) {
				cubemanInstance.transform.position += new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
			}

			foreach (char currentKey in Input.inputString) {
				codes [letter] = currentKey;
				codeArray [letter].text = currentKey.ToString ();
				letter += 1;
				if (letter == 2) {
					foreach (Ingredient i in GetComponent<Menu> ().ingredientList) {
						if (i == null || i.code == null) {
							continue;
						}
						if (i.code [0] == codes [0]) {
							if (i.code [1] == codes [1]) {
								ingredientOne = i.ingredientName;
								ingredientOneName.text = ingredientOne;
								Debug.Log (i.ingredientName);
							}
						}
					}
					Instantiate (GetComponent<Menu>().FindIngredient(ingredientOne).model, ingredientPosition, Quaternion.identity);
				}

				if (letter == 4) {
					foreach (Ingredient i in GetComponent<Menu> ().ingredientList) {
						if (i == null || i.code == null) {
							continue;
						}
						if (i.code [0] == codes [2]) {
							if (i.code [1] == codes [3]) {
								ingredientTwo = i.ingredientName;
								ingredientTwoName.text = ingredientTwo;

								Debug.Log (i.ingredientName);
							}
						}
					}
					Instantiate (GetComponent<Menu>().FindIngredient(ingredientTwo).model, ingredientPosition, Quaternion.identity);
				}

				if (letter == 6) {
					foreach (Ingredient i in GetComponent<Menu> ().ingredientList) {
						if (i == null || i.code == null) {
							continue;
						}
						if (i.code [0] == codes [4]) {
							if (i.code [1] == codes [5]) {
								ingredientThree = i.ingredientName;
								ingredientThreeName.text = ingredientThree;
							}
						}
					}

					Debug.Log (ingredientThree);

					bool drinkCorrect = false;
					if (ingredientOne == customerDrink.ingredients [0].ingredientName ||
					    ingredientOne == customerDrink.ingredients [1].ingredientName ||
					    ingredientOne == customerDrink.ingredients [2].ingredientName) {
						Debug.Log ("one down");

						if (ingredientTwo == customerDrink.ingredients [0].ingredientName ||
						    ingredientTwo == customerDrink.ingredients [1].ingredientName ||
						    ingredientTwo == customerDrink.ingredients [2].ingredientName) {
							Debug.Log ("two down");

							if (ingredientThree == customerDrink.ingredients [0].ingredientName ||
							   ingredientThree == customerDrink.ingredients [1].ingredientName ||
							   ingredientThree == customerDrink.ingredients [2].ingredientName) {
								Debug.Log ("fuck yeah");
								drinkCorrect = true;
							}
						}
					} 
					if (drinkCorrect) {
						Win();
					} else {
						Lose ();
					}

					Instantiate (ingredient);
				
							
						

					Instantiate (GetComponent<Menu>().FindIngredient(ingredientThree).model, ingredientPosition, Quaternion.identity);
					letter = 0;

				}

			}
			//end of the entire loop

		}
		//above is the end of the else block
	}

	void NewCustomer() {
		cubemanInstance = Instantiate (cubeman);
		cubemanInstance.transform.position = this.transform.position;

	}

	void TextChange() {
		//GetComponent <Menu> ().drinkList[0].drinkName;
		customerDrink = GetComponent <Menu> ().drinkList [0];
		Debug.Log (customerDrink.ingredients [0].ingredientName);
		Debug.Log (customerDrink.ingredients [1].ingredientName);
		Debug.Log (customerDrink.ingredients [2].ingredientName);
		dialogue.text = "Hello, I would like a "+ customerDrink.drinkName +".";

	}




	void Win() {

		dialogue.text = "Thank you. Goodbye. Forever.";
		Destroy (cubemanInstance);

		GetComponent<TheActualGame> ().successes++;
		GetComponent<TheActualGame> ().drinkNo++;

	}

	void Lose() {
		GetComponent<TheActualGame> ().drinkNo++;
		GameObject.Find ("Main Camera").GetComponent<Bloom> ().settings.intensity += 1f;
	}

}
