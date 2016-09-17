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

	// Use this for initialization
	void Start () {
		
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.R)) {
			NewCustomer ();
			TextChange ();
			codes = new char[6];
			letter = 0;
		}

		if (cubemanInstance != null) {
			cubemanInstance.transform.position += new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
		}

		foreach(char currentKey in Input.inputString){
			codes [letter] = currentKey;
			codeArray[letter].text = currentKey.ToString();
			letter += 1;
			if (letter == 6) {
				//CheckIngredients();
				letter = 0;
				Destroy (cubemanInstance);
			}

		}

		Debug.Log (codes);

	}

	void NewCustomer() {
		cubemanInstance = Instantiate (cubeman);
	}

	void TextChange() {
		//GetComponent <Menu> ().drinkList[0].drinkName;
		dialogue.text = "Hello, I would like a "+ GetComponent <Menu> ().drinkList[0].drinkName +".";
	}

	void CheckIngredients(){


	}

}
