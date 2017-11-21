using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alphabet : MonoBehaviour {
	public string word;

	private ball_collect_alphabet bca;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter(Collision coll) {
		if (coll.gameObject.name == "Cube") {
			bca = coll.gameObject.GetComponent<ball_collect_alphabet> ();
			bca.SetAlphabetChar(word);
			Destroy (gameObject);
		}
	}
}
