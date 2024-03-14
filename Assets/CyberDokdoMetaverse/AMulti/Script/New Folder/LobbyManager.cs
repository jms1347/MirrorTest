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

        MPlayer.localPlayer.HostGame(); //���� �÷��̾ ������ ��𿡼��� �׼��� �� �� �����Ƿ� ���� UI �÷��̾ ����
    }

    public void Join()
    {
        joinMatchInput.interactable = false;
        joinBtn.interactable = false;
        hostBtn.interactable = false;
    }
}
