using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerHealth : NetworkBehaviour {
    [SyncVar]
    public int health;

    public GameObject[] players;
    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(health);
        if (!isServer)
        {
            return;
        }
	}
    public void normalAttack()
    {
        
    }
    public void MageATK1()
    {
        Color myColor = this.GetComponent<SetupLocalPlayer>().playerColor;

        // FIRE gain health
        health += 5;
    }
    public void MageATK2()
    {
        health += 10;
    }
    public void MageATK3()
    {
        Color myColor = this.GetComponent<SetupLocalPlayer>().playerColor;
        // ICE: whole game AOE
        players = GameObject.FindGameObjectsWithTag("player");

        //Debug.Log("players.Length = " + players.Length.ToString());
        foreach (GameObject player in players) {
            Color playerColor = player.GetComponent<SetupLocalPlayer>().playerColor;
            //Debug.Log(playerColor); 
            if (playerColor != myColor)
            {
                player.GetComponent<PlayerHealth>().health -= 2;
            }
        }
    }
    public void MageATK4()
    {
        health += 30;
    }
}
