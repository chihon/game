﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectTime : MonoBehaviour {
	public float BulletLifeTime;
	//Flag for Destroy the object or not on Collision 
	private bool D;
	// Use this for initialization
	void Start () {
		Destroy (gameObject, BulletLifeTime);
		D = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void DestroyByCollision(bool Des)	{
		D = Des;
	}

	void OnCollisionEnter(Collision Other){
		if (D) {
			Destroy(gameObject);
		}
	}
}
