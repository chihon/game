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

    private TextMesh textmesh;
    void Start () {

        //MageModel.SetActive(true);
        //GunnModel.SetActive(true);
        //WarrModel.SetActive(true);

        if (career == "Mage")
        {
            MageModel.SetActive(true);
            MageModel.transform.SetAsFirstSibling();
        } else if (career == "Gunn")
        {
            GunnModel.SetActive(true);
            GunnModel.transform.SetAsFirstSibling();
        }
        else if (career == "Warr")
        {
            WarrModel.SetActive(true);
            WarrModel.transform.SetAsFirstSibling();
        }

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
