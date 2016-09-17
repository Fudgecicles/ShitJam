﻿using UnityEngine;
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
	public GameObject ingredient;
	public Drink customerDrink;
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
								Debug.Log (i.ingredientName);
							}
						}
					}
					ingredientMod1=(GameObject)Instantiate (GetComponent<Menu>().FindIngredient(ingredientOne).model, ingredientPosition, Quaternion.identity);
					stuffToThrow.Add (ingredientMod1);
				}

				if (letter == 4) {
					foreach (Ingredient i in GetComponent<Menu> ().ingredientList) {
						if (i == null || i.code == null) {
							continue;
						}
						if (i.code [0] == codes [2]) {
							if (i.code [1] == codes [3]) {
								ingredientTwo = i.ingredientName;
								Debug.Log (i.ingredientName);
							}
						}
					}
					ingredientMod2=(GameObject)Instantiate (GetComponent<Menu>().FindIngredient(ingredientTwo).model, ingredientPosition, Quaternion.identity);
					stuffToThrow.Add (ingredientMod2);
				}

				if (letter == 6) {
					foreach (Ingredient i in GetComponent<Menu> ().ingredientList) {
						if (i == null || i.code == null) {
							continue;
						}
						if (i.code [0] == codes [4]) {
							if (i.code [1] == codes [5]) {
								ingredientThree = i.ingredientName;
								Debug.Log (i.ingredientName);
							}
						}
					}
					ingredientMod3= (GameObject)Instantiate (GetComponent<Menu>().FindIngredient(ingredientThree).model, ingredientPosition, Quaternion.identity);
					stuffToThrow.Add (ingredientMod3);
					letter = 0;
					Destroy (cubemanInstance);
					StartCoroutine(throwCoroutine ());
				}

			}
			//end of the entire loop

		}
		//above is the end of the else block
	}

	void NewCustomer() {
		cubemanInstance = Instantiate (cubeman);
		cubemanInstance.transform.position = this.transform.position;
		//stuffToThrow.Add((GameObject)Instantiate (cupModel, cup.position, Quaternion.identity));

	}

	void TextChange() {
		//GetComponent <Menu> ().drinkList[0].drinkName;
		customerDrink = GetComponent <Menu> ().drinkList [0];
		dialogue.text = "Hello, I would like a "+ customerDrink.drinkName +".";
	
	}




	void Win() {
		GetComponent<TheActualGame> ().successes++;
		GetComponent<TheActualGame> ().drinkNo++;
		StartCoroutine(throwCoroutine ());
	}

	void Lose() {
		GetComponent<TheActualGame> ().drinkNo++;
		GameObject.Find ("Main Camera").GetComponent<Bloom> ().settings.intensity += 1f;
		StartCoroutine(throwCoroutine ());
	}

	void Throw()
	{
		foreach (var g in stuffToThrow) {
			GameObject.Destroy (g);
		}
	}

	IEnumerator throwCoroutine(){
		yield return new WaitForSeconds(0.5f);
		Throw ();
	}

}
