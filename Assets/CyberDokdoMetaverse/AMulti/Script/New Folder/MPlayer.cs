using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPlayer : NetworkBehaviour
{
    public static MPlayer localPlayer;

    NetworkMatch networkMatch;

    void Start()
    {
        if (isLocalPlayer)
        {
            localPlayer = this;
        }

        networkMatch = this.GetComponent<NetworkMatch>();
    }

    //공개 무효 호스트 게임
    public void HostGame()
    {
        //string matchID = MatchMaker.GetRandomMatchID();
        //CmdHostGame(matchID);
    }

    [Command]
    void CmdHostGame(string _matchID)
    {
        //if (MatchMaker.instance.HostGame(_matchID, gameObject))
        //{
        //    Debug.Log($"<color = green>Game hosted successfully</color>");
        //    //networkMatch.matchId = _matchID.ToGuid();
        //}
        //else
        //{
        //    Debug.Log($"<color = red>Game hosted failed</color>");
        //}
    }
}
