using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System.Security.Cryptography;
using System.Text;
using System;
using Random = UnityEngine.Random;

[System.Serializable]
public class Match
{
    public string matchID;

    public List<GameObject> players = new List<GameObject>();

    public Match(string matchID, GameObject player)
    {
        this.matchID = matchID;
        players.Add(player);
    }

    public Match() { }  //빈생성자
}


//매치 중매 클래스
public class MatchMaker : NetworkBehaviour
{    
    public static MatchMaker instance;

    public readonly SyncList<Match> matches = new SyncList<Match>();
    public readonly SyncList<string> matchIDs = new SyncList<string>();


    private void Awake()
    {
        instance = this;
    }
    public bool HostGame(string _matchID, GameObject _player)
    {        
        //검증
        if (matchIDs.Contains(_matchID))
        {
            matchIDs.Add(_matchID);
            matches.Add(new Match(_matchID, _player));
            Debug.Log($"Match generated");
            return true;    
        }
        else
        {
            Debug.Log($"Match Id already exists");
            return false;
        }
    }

    //무작위 ID 생성
    public static string GetRandomMatchID()
    {
        string _id = string.Empty;
        for (int i = 0; i < 5; i++)
        {
            int random = Random.Range(0, 36);
            if(random < 26)
            {
                _id += (char)(random + 65);
            }
            else
            {
                _id += (random - 26).ToString();
            }
        }
        Debug.Log($"Random Match ID : {_id}");
        return _id;
    }

    //public static class MatchExtensions
    //{
    //    public static Guid ToGuid(this string id)
    //    {
    //        MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider(); 
    //        byte[] inputBytes = Encoding.Default.GetBytes(id);
    //        byte[] hashBytes = provider.ComputeHash(inputBytes);

    //        return new Guid(hashBytes);

    //    }
    //}
    
}
