using Mirror;
using multiTest;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lobby : NetworkBehaviour
{
    public GameObject playerInfoUIPrefab;
    public Transform content;

    public MirrorManager mirrorManager;

    private static Dictionary<NetworkConnection, Player> players = new Dictionary<NetworkConnection, Player>();
    private List<PlayerInfoUI> playerInfoUIList = new List<PlayerInfoUI>();

    private void Start()
    {
        //mirrorManager = GameObject.Find("MirrorManager").GetComponent<MirrorManager>();
    }
    public static void AddPlayer(NetworkConnection conn, Player player)
    {
        players[conn] = player;
    }

    public static void RemovePlayer(NetworkConnection conn)
    {
        players.Remove(conn);
    }
    
    [Server]
    public override void OnStartServer()
    {
        AddPlayer(connectionToClient, Player.localPlayer);
        GameObject temp = Instantiate(playerInfoUIPrefab, content);
        temp.GetComponent<PlayerInfoUI>().SetPlayer(Player.localPlayer, mirrorManager.id, mirrorManager.team);

        playerInfoUIList.Add(temp.GetComponent<PlayerInfoUI>());
    }

    [Server]
    public override void OnStopServer()
    {
        RemovePlayer(connectionToClient);

    }

}

