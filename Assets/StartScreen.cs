using UnityEngine;
using System.Collections;

public class StartScreen : MonoBehaviour {

    public bool canStart = false;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (canStart)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Application.LoadLevel(1);
            }
        }
	}
}
