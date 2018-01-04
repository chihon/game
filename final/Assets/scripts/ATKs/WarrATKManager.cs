using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WarrATKManager : NetworkBehaviour {
	
	//public Rigidbody m_Sword;
	//public Rigidbody m_Rush;
	//public Rigidbody m_Shield;
	//public Rigidbody m_Warwing;
	public GameObject m_SwordRitual;
    public GameObject m_WarwingRitual;
    public GameObject m_RushRitual;
	public GameObject m_ShieldRitual;
	public Transform m_FireFrom;
	public Transform m_Ritual;
	public Transform m_FireRotat;
	// Use this for initialization
	
	//public List<List<string>> abilityList;
    public List<string> abilityList;
    public int maxLength;
	void Start () {
		//abilityList = new List<List<string>>();
        //abilityList.Add(new List<string> { "S", "W", "O", "R", "D" });
        //abilityList.Add(new List<string> { "R", "U", "S", "H" });
        //abilityList.Add(new List<string> { "S", "H", "E", "I", "L", "D" });
        //abilityList.Add(new List<string> { "W", "A", "R", "W", "I", "N", "G" });
        abilityList = new List<string>();

        abilityList.Add("SHEILD");
        abilityList.Add("RUSH");
        abilityList.Add("WARWING");
        abilityList.Add("SWORD");
        maxLength = 7;
	}
	
	// Update is called once per frame
	void Update () {
		
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
