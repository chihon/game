using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolBulletEff : MonoBehaviour {
	public float BulletLifeTime;
	//Flag for Destroy the object or not on Collision 
	public GameObject m_BulletExplode;
	// Use this for initialization
	void Start () {
		Destroy (gameObject, BulletLifeTime);
	}

	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter(Collision Other){
		GameObject ExplodeInstance = 
			Instantiate (m_BulletExplode, this.transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
