using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectTime : MonoBehaviour {
	public float BulletLifeTime;
	// Use this for initialization
	void Start () {
		Destroy (gameObject, BulletLifeTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
