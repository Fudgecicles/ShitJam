using UnityEngine;
using System.Collections;
using UnityStandardAssets.CinematicEffects;

public class JitterTonemapping : MonoBehaviour {

    TonemappingColorGrading tonemapping;
    float initialWhiteIn;
    public float jitterMax;

	// Use this for initialization
	void Start () {
        tonemapping = GetComponent<TonemappingColorGrading>();
        initialWhiteIn = tonemapping.tonemapping.neutralWhiteIn;
    }
	
	// Update is called once per frame
	void Update () {
        TonemappingColorGrading.TonemappingSettings settings = tonemapping.tonemapping;
        settings.neutralWhiteIn = initialWhiteIn + Random.Range(-jitterMax, jitterMax);
        tonemapping.tonemapping = settings;
	}
}
