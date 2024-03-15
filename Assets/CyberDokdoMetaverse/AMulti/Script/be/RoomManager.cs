using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using multiTest;
using TMPro;

public class RoomManager : NetworkRoomManager
{
    public string id, school;

    public Transform slotPool;
    public List<string> idList = new List<string>();
    public List<string> schoolList = new List<string>();

    public override void OnRoomServerConnect(NetworkConnectionToClient conn)
    {
        base.OnRoomServerConnect(conn);


    }
    public override void OnRoomClientConnect()
    {
        base.OnRoomClientConnect();

        SetParameter(id, school);
        SetProfile();
    }

    [Client]
    public void SetParameter(string pId, string pSchool)
    {
        idList.Add(pId);
        schoolList.Add(pSchool);
    }

    public void SetProfile()
    {
        slotPool = GameObject.Find("Content").transform;

        for (int i = 0; i < idList.Count; i++)
        {
            GameObject player = Instantiate(spawnPrefabs[1], slotPool);
            player.GetComponent<PlayerInfoUI>().SetPlayer(idList[i], schoolList[i]);
            NetworkServer.Spawn(player);

        }
    }
}
