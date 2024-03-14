using Mirror;
using Mirror.Examples.MultipleMatch;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class MirrorManager : NetworkManager
{
    public string id;
    public string team;

    public override void OnStartServer()
    {
        Debug.Log("OnStartServer");
    }

    public override void OnStopServer()
    {
        Debug.Log("OnStopServer");
    }

    public override void OnStartClient()
    {
        Debug.Log("OnStartClient");
        Debug.Log("로그인 사용자 ID : " + id + "// 소속팀 : " + team);
        
    }

    public override void OnStopClient()
    {
        Debug.Log("OnStopClient");
    }

    public override void OnStartHost()
    {
        Debug.Log("OnStartHost");
    }

    public override void OnStopHost()
    {
        Debug.Log("OnStopHost");
    }
}
