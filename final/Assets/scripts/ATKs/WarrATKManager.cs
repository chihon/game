using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarrATKManager : MonoBehaviour {
	
	//public Rigidbody m_Sword;
	//public Rigidbody m_Rush;
	//public Rigidbody m_Shield;
	//public Rigidbody m_Warwing;
	public GameObject m_SwordRitual;
	public GameObject m_RushRitual;
	public GameObject m_ShieldRitual;
	public GameObject m_WarwingRitual;
	public Transform m_FireFrom;
	public Transform m_Ritual;
	public Transform m_FireRotat;
	// Use this for initialization
	// Use this for initialization
	void Start () {
		m_FireRotat = Camera.main.transform;
	}
	
	// Update is called once per frame
	void Update () {
		m_FireRotat = Camera.main.transform;
	}
	//Sword ATK
	public void ATK1 (){
		//Rigidbody shellInstance = 
		//	Instantiate (m_FireShell, m_FireFrom.position, m_FireRotat.rotation);
		GameObject RitualInstance = 
			Instantiate (m_SwordRitual, m_Ritual.position, m_FireRotat.rotation);
	}
	//Rush ATK
	public void ATK2 (){
		//Rigidbody shellInstance = 
		//	Instantiate (m_ATK2_Shell, m_FireFrom.position, m_FireRotat.rotation);
		GameObject RitualInstance = 
			Instantiate (m_RushRitual, m_Ritual.position, m_FireRotat.rotation);
	}
	//Shield ATK
	public void ATK3 (){
		//Rigidbody shellInstance = 
		//	Instantiate (m_IceShell, m_FireFrom.position, m_FireRotat.rotation);
		GameObject RitualInstance = 
			Instantiate (m_ShieldRitual, m_FireFrom.position, m_FireRotat.rotation);
	}
	//Warwing ATK
	public void ATK4 (){
		//Rigidbody shellInstance = 
		//	Instantiate (m_FlashShell, m_FireFrom.position, m_FireRotat.rotation);
		GameObject RitualInstance = 
			Instantiate (m_WarwingRitual, m_Ritual.position, Quaternion.identity);
	}
}
