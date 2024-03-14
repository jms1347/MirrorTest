using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Mirror;
namespace multiTest
{
    [SerializeField]
    public class PlayerInfo
    {
        public string playerName;
        public string playerTeamName;
        public Player player;

        public void SetPlayer(Player pPlayer, string pName, string pTeamName)
        {
            player = pPlayer;
            playerName = pName;
            playerTeamName = pTeamName;
        }
    }
    public class PlayerInfoUI : NetworkRoomPlayer
    {
        public TextMeshProUGUI PlayerNameText;
        public TextMeshProUGUI PlayerTeamNameText;
        public PlayerInfo playerInfo;

        public void SetPlayer(Player player, string pName, string pTeamName)
        {
            playerInfo.SetPlayer(player, pName, pTeamName);
        }

        public void SetPlayer(PlayerInfo pInfo)
        {
            playerInfo.SetPlayer(pInfo.player, pInfo.playerName, pInfo.playerTeamName);
        }
    }
}