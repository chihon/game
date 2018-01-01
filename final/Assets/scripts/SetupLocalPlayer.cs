using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SetupLocalPlayer : NetworkBehaviour {
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
        if (!isLocalPlayer)
        {
            textmesh = this.GetComponentInChildren<TextMesh>();
            textmesh.color = playerColor;
            textmesh.text = pname + "\n\n\n";
            textmesh.anchor = TextAnchor.MiddleCenter;
            textmesh.characterSize = 0.7f;
            textmesh.lineSpacing = 1.1f;
        }
    }
	
	// Update is called once per frame
	void Update () {

    }
}
