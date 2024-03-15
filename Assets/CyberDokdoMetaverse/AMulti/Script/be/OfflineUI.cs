using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using TMPro;
using UnityEditor.EditorTools;

public class OfflineUI : MonoBehaviour
{
    [Header("캔버스")]
    public RoomManager roomManager;
    public TMP_InputField nickInputField;
    public TMP_InputField schoolInputField;

    public void CreateRoom()
    {
        var manager = RoomManager.singleton;

        //방 설정 작업ㅊ ㅓ리


        roomManager.id =  nickInputField.text;
        roomManager.school = schoolInputField.text;

        manager.StartHost();
    }

    public void JoinRoom()
    {
        var manager = RoomManager.singleton;

        //방 설정 작업ㅊ ㅓ리
        roomManager.id = nickInputField.text;
        roomManager.school = schoolInputField.text;

        manager.StartClient();
    }
}


