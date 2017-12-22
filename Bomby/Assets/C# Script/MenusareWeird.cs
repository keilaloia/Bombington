using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MenusareWeird : MonoBehaviour {

	// Use this for initialization
	public void Exit()
    {
        if (Network.isServer)
            NetworkServer.DisconnectAll();
        else
            NetworkClient.ShutdownAll();

        //Network.Disconnect(100);

        Time.timeScale = 1.0f;

        UnityEngine.SceneManagement.SceneManager.LoadScene(0);

    }

    // Update is called once per frame
    void Update () {
		
	}
}
