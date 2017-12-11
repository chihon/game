using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeExplode : MonoBehaviour {

	public float m_Wait4;
	public GameObject m_Explosion;
	void Start()
	{
		StartCoroutine(Explode());
	}

	IEnumerator Explode()
	{
		yield return new WaitForSeconds(m_Wait4);
		GameObject ExplodeInstance = 
			Instantiate (m_Explosion, this.transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
