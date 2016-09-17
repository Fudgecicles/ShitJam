using UnityEngine;
using System.Collections;

public class LoadGameScene : MonoBehaviour {

    public void LoadGame()
    {
        Debug.Log("called");
        Application.LoadLevel(2);
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
