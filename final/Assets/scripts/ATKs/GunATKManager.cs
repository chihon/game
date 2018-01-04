using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GunATKManager : NetworkBehaviour {

	public Rigidbody m_GunShell;
	public float m_GunSpeed;
	//public GameObject m_GunRitual;

	public Rigidbody m_PistolShell;
	public float m_PistolSpeed;
	public GameObject m_PistolRitual;

	public Rigidbody m_GrenadeShell;
	public float m_GrenadeSpeed;
	public GameObject m_GrenadeRitual;

	public Rigidbody m_SatelliteShell;
	public float m_SatelliteSpeed;
	public float m_SatelliteHeight;
	public GameObject m_SatelliteRitual;

	public Transform m_FireFrom;
	public Transform m_Ritual;
	public Transform m_FireRotat;

	//public List<List<string>> abilityList;
    public List<string> abilityList;

    public int maxLength;
	// Use this for initialization
	void Start () {
        //abilityList = new List<List<string>>();
        //abilityList.Add(new List<string> { "G","U","N" });
        //abilityList.Add(new List<string> { "P","I","S","T","O","L" });
        //abilityList.Add(new List<string> { "G","R","E","N","A","D","E" });
        //abilityList.Add(new List<string> { "S","A","T","E","L","L","I","T","E" });
        abilityList = new List<string>();
        
        abilityList.Add("SATELLITE");
        abilityList.Add("GRENADE");
        abilityList.Add("PISTOL");
        abilityList.Add("GUN");
        maxLength = 9;
	}

	// Update is called once per frame
	void Update () {

	}
	//Gun ATK
	public void ATK1 (){
		Rigidbody shellInstance = 
			Instantiate (m_GunShell, m_FireFrom.position, m_FireRotat.rotation);
		//GameObject RitualInstance = 
		//	Instantiate (m_GunRitual, m_Ritual.position, Quaternion.identity);
		shellInstance.transform.Rotate(90, 0, 0);
		shellInstance.velocity = m_FireRotat.forward * m_GunSpeed;
	}
	//Pistol ATK
	public void ATK2 (){
		Rigidbody shellInstance = 
			Instantiate (m_PistolShell, m_FireFrom.position, m_FireRotat.rotation);
		Vector3 newPlace = m_Ritual.position;
		newPlace.y += 1;
		GameObject RitualInstance = 
			Instantiate (m_PistolRitual, newPlace, m_FireRotat.rotation);
		shellInstance.transform.Rotate(90, 0, 0);
		shellInstance.velocity = m_FireRotat.forward * m_PistolSpeed;
		RitualInstance.transform.Rotate (90, 0, 0);
	}
	//Grenade ATK
	public void ATK3 (){
		Rigidbody shellInstance = 
			Instantiate (m_GrenadeShell, m_FireFrom.position, m_FireRotat.rotation);
		GameObject RitualInstance = 
			Instantiate (m_GrenadeRitual, m_Ritual.position, m_FireRotat.rotation);
		shellInstance.velocity = m_FireRotat.forward * m_GrenadeSpeed;
	}
	//Satellite ATK
	public void ATK4 (){
		Vector3 newPlace = m_FireFrom.position;
		newPlace.y += m_SatelliteHeight;
		Rigidbody shellInstance = 
			Instantiate (m_SatelliteShell, newPlace, Quaternion.identity);
		GameObject RitualInstance = 
			Instantiate (m_SatelliteRitual, m_Ritual.position, m_FireRotat.rotation);
		shellInstance.velocity = m_FireRotat.forward * m_SatelliteSpeed;
	}
    [ClientRpc]
    public void RpcATK4()
    {
        ATK4();
    }
    [ClientRpc]
    public void RpcATK3()
    {
        ATK3();
    }
    [ClientRpc]
    public void RpcATK2()
    {
        ATK2();
    }
    [ClientRpc]
    public void RpcATK1()
    {
        ATK1();
    }
}
