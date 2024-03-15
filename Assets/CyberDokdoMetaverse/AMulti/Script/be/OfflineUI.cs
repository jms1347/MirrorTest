using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using TMPro;
using UnityEditor.EditorTools;

public class OfflineUI : MonoBehaviour
{
    [Header("ĵ����")]
    public RoomManager roomManager;
    public TMP_InputField nickInputField;
    public TMP_InputField schoolInputField;

    public void CreateRoom()
    {
        var manager = RoomManager.singleton;

        //�� ���� �۾��� �ø�


        roomManager.id =  nickInputField.text;
        roomManager.school = schoolInputField.text;

        manager.StartHost();
    }

    public void JoinRoom()
    {
        var manager = RoomManager.singleton;

        //�� ���� �۾��� �ø�
        roomManager.id = nickInputField.text;
        roomManager.school = schoolInputField.text;

        manager.StartClient();
    }
}


