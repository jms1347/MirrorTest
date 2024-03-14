using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;
using TMPro;

public class LobbyManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField joinMatchInput;
    [SerializeField] private Button joinBtn;
    [SerializeField] private Button hostBtn;


    public void Host()
    {
        joinMatchInput.interactable = false;
        joinBtn.interactable = false;
        hostBtn.interactable = false;

        MPlayer.localPlayer.HostGame(); //로컬 플레이어가 누구든 어디에서나 액세스 할 수 있으므로 이제 UI 플레이어에 연결
    }

    public void Join()
    {
        joinMatchInput.interactable = false;
        joinBtn.interactable = false;
        hostBtn.interactable = false;
    }
}
