using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

namespace multiTest
{
    public class PlayerUI : MonoBehaviour
    {
        public TextMeshProUGUI PlayerText;
        private Player player;

        public void SetPlayer(Player player1)
        {
            this.player = player1;
            PlayerText.text = "HAJO";
        }

        public void SetPlayer(Player player, string pName)
        {
            this.player = player;
            PlayerText.text = pName;
        }

    }
}
