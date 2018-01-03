using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SetupLocalPlayer : NetworkBehaviour {

    public GameObject MageModel;
    public GameObject GunnModel;
    public GameObject WarrModel;

    [SyncVar]
    public string pname = "player";

    [SyncVar]
    public Color playerColor = Color.white; // color as unique identifier

    [SyncVar]
    public string career = "career";

    static Color[] Colors = new Color[] { Color.magenta, Color.red, Color.cyan, Color.blue, Color.green, Color.yellow }; // from LobbyPlayer.cs


    // Use this for initialization


    //public RuntimeAnimatorController anictrl; // 2L2H
    private TextMesh textmesh;
    void Start () {
        
        if (career == "Mage")
        {
            MageModel.SetActive(true);
            MageModel.name = "Body";
        } else if (career == "Gunn")
        {
            GunnModel.SetActive(true);
            GunnModel.name = "Body";
        }
        else if (career == "Warr")
        {
            WarrModel.SetActive(true);
            WarrModel.name = "Body";
        }
        
        Animator ani = this.GetComponent<Animator>();
        //ani.runtimeAnimatorController = anictrl;
        ani.Rebind();

        //ani.enable = true;
        //ani.play

        if (!isLocalPlayer)
        {
            textmesh = this.GetComponentInChildren<TextMesh>();
            textmesh.color = playerColor;
            textmesh.text = pname + "\n\n\n";
            textmesh.anchor = TextAnchor.UpperCenter;
            textmesh.characterSize = 0.4f;
            textmesh.lineSpacing = 1.1f;
        } else
        {
            textmesh = this.GetComponentInChildren<TextMesh>();
            textmesh.text = "";
        }
    }
	
	// Update is called once per frame
	void Update () {

    }
}
