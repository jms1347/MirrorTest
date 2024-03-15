using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GamePlayer : NetworkBehaviour
{
    public TextMesh nameText;

    public void SetName(string pName)
    {
        nameText.text = pName;  
    }
}
