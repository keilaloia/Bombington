using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenusareWeird : MonoBehaviour {

	// Use this for initialization
	public void Exit()
    {
        Time.timeScale = 1.0f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);

    }

    // Update is called once per frame
    void Update () {
		
	}
}
