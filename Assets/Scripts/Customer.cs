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
	GameObject ingredientMod1;
	GameObject ingredientMod2;
	GameObject ingredientMod3;
	public Transform cup;
	public GameObject cupModel;
	GameObject cupPrefab;
	public GameObject ingredient;
	public Drink customerDrink;
	int winLose;
	public Text ingredientOneName;
	public Text ingredientTwoName;
	public Text ingredientThreeName;

	Vector3 ingredientPosition;
	System.Collections.Generic.List<GameObject> stuffToThrow;

	// Use this for initialization
	void Start () {
		ingredientPosition = new Vector3 (29.41386f, 9.313f, 30.484f);
		stuffToThrow = new System.Collections.Generic.List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {


		if (Input.GetKeyDown (KeyCode.Space)) {
			NewCustomer ();
			TextChange ();
			codes = new char[6];
			letter = 0;
		} else {
			

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

					if (ingredientOne != "") {
						ingredientMod1=(GameObject)Instantiate (GetComponent<Menu>().FindIngredient(ingredientOne).model, ingredientPosition, Quaternion.identity);
						stuffToThrow.Add (ingredientMod1);
						}
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

					if (ingredientTwo != "") {
						ingredientMod2=(GameObject)Instantiate (GetComponent<Menu>().FindIngredient(ingredientTwo).model, ingredientPosition, Quaternion.identity);
						stuffToThrow.Add (ingredientMod2);
					}
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
				
							
						
					if (ingredientThree != "") {
						ingredientMod3= (GameObject)Instantiate (GetComponent<Menu>().FindIngredient(ingredientThree).model, ingredientPosition, Quaternion.identity);
						stuffToThrow.Add (ingredientMod3);

					}

					Destroy (cubemanInstance);
					StartCoroutine(throwCoroutine ());
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
		cupPrefab = (GameObject)Instantiate (cupModel, cup.transform.position, Quaternion.identity);
		stuffToThrow.Add (cupPrefab);

		//stuffToThrow.Add((GameObject)Instantiate (cupModel, cup.position, Quaternion.identity));


		//stuffToThrow.Add((GameObject)Instantiate (cupModel, cup.position, Quaternion.identity));

		for (int i = 0; i < codeArray.Length; i++) {
			codeArray [i].text = " ";
		}
		ingredientThreeName.text = " ";
		ingredientTwoName.text = " ";
		ingredientOneName.text = " ";

	}

	void TextChange() {
		//GetComponent <Menu> ().drinkList[0].drinkName;
		customerDrink = GetComponent <Menu> ().RandomDrink();
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





		winLose = 1;
		StartCoroutine(throwCoroutine ());

	}

	void Lose() {
		dialogue.text = "This is not what I wanted. Fuck you.";
		GetComponent<TheActualGame> ().drinkNo++;
		GameObject.Find ("Main Camera").GetComponent<Bloom> ().settings.intensity += 1f;
		winLose = -1;
		StartCoroutine(throwCoroutine ());
	}

	void Throw()
	{
		foreach (var g in stuffToThrow) {
			GameObject.Destroy (g);
		}
		stuffToThrow.Clear ();
	}

	void ActuallyThrow(){
		foreach (var g in stuffToThrow) {
			g.GetComponent<Rigidbody> ().AddForce (transform.forward*250*winLose);
		}
	}

	IEnumerator throwCoroutine(){
		ActuallyThrow ();
		yield return new WaitForSeconds(0.5f);
		Throw ();
	}

}
