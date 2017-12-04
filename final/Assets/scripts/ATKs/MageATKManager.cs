using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageATKManager : MonoBehaviour {

	public Rigidbody m_FireShell;
	public float m_FireSpeed;
	public GameObject m_FireRitual;

	//public Rigidbody m_WindShell;
	public GameObject m_WindRitual;

	public Rigidbody m_IceShell;
	public GameObject m_IceRitual;

	public GameObject m_FlashHead;
	public GameObject m_FlashTail;
	public float m_FlashSpeed;
	public GameObject m_FlashRitual;



	public Transform m_FireFrom;
	public Transform m_Ritual;
	public Transform m_FireRotat;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	//Fire ATK
	public void ATK1 (){
		Rigidbody shellInstance = 
			Instantiate (m_FireShell, m_FireFrom.position, m_FireRotat.rotation);
		GameObject RitualInstance = 
			Instantiate (m_FireRitual, m_Ritual.position, Quaternion.identity);

		shellInstance.velocity = m_FireRotat.forward * m_FireSpeed;
	}
	//Wind ATK
	public void ATK2 (){
		//Rigidbody shellInstance = 
		//	Instantiate (m_ATK2_Shell, m_FireFrom.position, m_FireRotat.rotation);
		GameObject RitualInstance = 
			Instantiate (m_WindRitual,m_Ritual.position, Quaternion.identity);
	}
	//Ice ATK
	public void ATK3 (){
		Rigidbody shellInstance = 
			Instantiate (m_IceShell, m_Ritual.position, Quaternion.identity);
		GameObject RitualInstance = 
			Instantiate (m_IceRitual, m_Ritual.position, Quaternion.identity);
	}
	//Flash ATK
	public void ATK4 (){
		GameObject RitualInstance = 
			Instantiate (m_FlashRitual, m_Ritual.position, Quaternion.identity);
		//Flash1
		GameObject FlashHead = 
			Instantiate (m_FlashHead, m_FireFrom.position, m_FireRotat.rotation);
		Rigidbody shellInstance = FlashHead.GetComponent<Rigidbody> ();
		GameObject FlashTail = 
			Instantiate (m_FlashTail, m_FireFrom.position, m_FireRotat.rotation);
		particleAttractorLinear PAL = FlashTail.GetComponent<particleAttractorLinear> ();
		PAL.target = FlashHead.transform;
		shellInstance.velocity =  m_FireRotat.forward * m_FlashSpeed;
		//Flash2
		GameObject FlashHead2 = 
			Instantiate (m_FlashHead, m_FireFrom.position, m_FireRotat.rotation);
		Rigidbody shellInstance2 = FlashHead.GetComponent<Rigidbody> ();
		GameObject FlashTail2 = 
			Instantiate (m_FlashTail, m_FireFrom.position, m_FireRotat.rotation);
		particleAttractorLinear PAL2 = FlashTail.GetComponent<particleAttractorLinear> ();
		PAL.target = FlashHead.transform;
		shellInstance.velocity =  m_FireRotat.forward * m_FlashSpeed;
		//Flash3
		GameObject FlashHead3 = 
			Instantiate (m_FlashHead, m_FireFrom.position, m_FireRotat.rotation);
		Rigidbody shellInstance3 = FlashHead.GetComponent<Rigidbody> ();
		GameObject FlashTail3 = 
			Instantiate (m_FlashTail, m_FireFrom.position, m_FireRotat.rotation);
		particleAttractorLinear PAL3 = FlashTail.GetComponent<particleAttractorLinear> ();
		PAL.target = FlashHead.transform;
		shellInstance.velocity =  m_FireRotat.forward * m_FlashSpeed;
	
	}
}
