using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace multiTest
{
    public class TurnManager : MonoBehaviour
    {
        private List<Player> players = new List<Player>();

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }
    }
}

