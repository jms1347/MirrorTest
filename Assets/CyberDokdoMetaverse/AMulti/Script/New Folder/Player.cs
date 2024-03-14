using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.SceneManagement;

namespace multiTest
{
    public class Player : NetworkBehaviour
    {
        public bool hasAuthority = true;
        bool facingRight = true;
        public static Player localPlayer;
        [SyncVar] public string matchID;

        private NetworkMatch networkMatch;

        private void Start()
        {
            networkMatch = GetComponent<NetworkMatch>();

            if (isLocalPlayer)
            {
                localPlayer = this;
            }
            else
            {
                MainMenu.instance.SpawnPlayerUIPrefab(this);
            }
        }

        public void HostGame()
        {
            string ID = MainMenu.GetRandomID();
            CmdHostGame(ID);
        }

        [Command]
        public void CmdHostGame(string ID)
        {
            matchID = ID;
            if (MainMenu.instance.HostGame(ID, gameObject))
            {
                Debug.Log("Cmd Host Game Suc");
                networkMatch.matchId = ID.ToGuid();
                TargetHostGame(true, ID);
            }
            else
            {
                Debug.Log("Cmd Host Game Fail");
                TargetHostGame(false, ID);
            }
        }

        [TargetRpc]
        void TargetHostGame(bool success, string ID)
        {
            matchID = ID;
            Debug.Log($"ID {matchID} == {ID}");
            MainMenu.instance.HostSuccess(success, ID);
        }

        public void JoinGame(string inputID)
        {
            CmdJoinGame(inputID);
        }

        [Command]
        public void CmdJoinGame(string ID)
        {
            matchID = ID;
            if (MainMenu.instance.JoinGame(ID, gameObject))
            {
                Debug.Log("Cmd Join Game Suc");
                networkMatch.matchId = ID.ToGuid();
                TargetJoinGame(true, ID);
            }
            else
            {
                Debug.Log("Cmd Join Game Fail");
                TargetJoinGame(false, ID);
            }
        }

        [TargetRpc]
        void TargetJoinGame(bool success, string ID)
        {
            matchID = ID;
            Debug.Log($"ID {matchID} == {ID}");
            MainMenu.instance.JoinSuccess(success, ID);
        }

        public void BeginGame()
        {
            CmdBeginGame();
        }

        [Command]
        public void CmdBeginGame()
        {
            MainMenu.instance.BeginGame(matchID);
            Debug.Log("Cmd Begin Game");
        }

        public void StartGame()
        {
            TargetBeginGame();
        }

        [TargetRpc]
        void TargetBeginGame()
        {
            Debug.Log($"ID {matchID} | Target Begin");
            DontDestroyOnLoad(gameObject);
            MainMenu.instance.inGame = true;
            transform.localScale = new Vector3(0.41664f, 0.41664f, 0.41664f); //¬²¬Ñ¬Ù¬Þ¬Ö¬â ¬Ó¬Ñ¬ê¬Ö¬Ô¬à ¬Ú¬Ô¬â¬à¬Ü¬Ñ (x, y, z)
            facingRight = true;
            SceneManager.LoadScene("MGame", LoadSceneMode.Additive);
        }

        private void Update()
        {
            if (hasAuthority)
            {
                Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
                float speed = 6f * Time.deltaTime;
                transform.Translate(new Vector2(input.x * speed, input.y * speed));
            }
        }
    }
}
