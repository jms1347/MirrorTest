using Mirror;
using TMPro;
using UnityEngine;

public class Connection : MonoBehaviour
{
    public MirrorManager networkManager;
    public TMP_InputField idField;
    public TMP_InputField teamField;


    private void Start()
    {
        //if (!Application.isBatchMode)
        //{
        //    networkManager.StartClient();
        //}
    }

    public void JoinClient()
    {
        networkManager.id = idField.text;
        networkManager.team = teamField.text;

        networkManager.networkAddress = "localhost";
        networkManager.StartClient();
    }

    public void Host()
    {
        networkManager.id = idField.text;
        networkManager.team = teamField.text;
        networkManager.StartHost();
    }
}