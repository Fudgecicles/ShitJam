using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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
	// Use this for initialization
	void Start () {
		
	
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
							}
						}
					}
					Instantiate (ingredient);
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
							}
						}
					}
					Instantiate (ingredient);
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

					bool drinkCorrect = false;
					if (ingredientOne == customerDrink.ingredients [0].ingredientName ||
					    ingredientOne == customerDrink.ingredients [1].ingredientName ||
					    ingredientOne == customerDrink.ingredients [2].ingredientName) {

						if (ingredientTwo == customerDrink.ingredients [0].ingredientName ||
						    ingredientTwo == customerDrink.ingredients [1].ingredientName ||
						    ingredientTwo == customerDrink.ingredients [2].ingredientName) {

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
		dialogue.text = "Hello, I would like a "+ customerDrink.drinkName +".";

	}




	void Win() {
		dialogue.text = "Thank you. Goodbye. Forever.";
		Destroy (cubemanInstance);
	}

	void Lose() {
	}

}
