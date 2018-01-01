using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Prototype.NetworkLobby;
// https://www.youtube.com/watch?v=-t9kzrLkF10
public class NetworkLobbyHook : LobbyHook {

    static Color[] Colors = new Color[] { Color.magenta, Color.red, Color.cyan, Color.blue, Color.green, Color.yellow }; // from LobbyPlayer.cs
    static string[] careers = new string[] { "Mage", "Gunn", "Warr" };
    public override void OnLobbyServerSceneLoadedForPlayer(NetworkManager manager,
                                                           GameObject lobbyPlayer, GameObject gamePlayer)
    {
        LobbyPlayer lobby = lobbyPlayer.GetComponent<LobbyPlayer>();
        SetupLocalPlayer localPlayer = gamePlayer.GetComponent<SetupLocalPlayer>();
        PlayerHealth myHealth = gamePlayer.GetComponent<PlayerHealth>();

        localPlayer.pname = lobby.playerName;
        localPlayer.playerColor = lobby.playerColor;
        localPlayer.career = getCareerByColor(lobby.playerColor);
        myHealth.health = 20;
    }

    string getCareerByColor(Color c)
    {
        if (c == Color.red)
        {
            return careers[0];
        } else if (c == Color.cyan)
        {
            return careers[1];
        } else if (c == Color.blue)
        {
            return careers[2];
        }
        return careers[Random.Range(0, careers.Length)]; // random
    }
}
