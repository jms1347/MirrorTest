using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using Mirror;

public class NetworkController : NetworkBehaviour
{
    public string firstSceneToLoad;

    private string[] sceneToLoad;
    private bool subscenesLoaded;

    private readonly List<Scene> subScene = new List<Scene>();

    private bool isInTransition;
    private bool firstSceneLoaded;

    private void Start()
    {
        int sceneCount = SceneManager.sceneCountInBuildSettings - 2;
        sceneToLoad = new string[sceneCount];

        for (int i = 0; i < sceneCount; i++)
        {

        }
    }
}
