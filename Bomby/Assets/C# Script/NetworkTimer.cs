using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class NetworkTimer : NetworkBehaviour {

    
    public Text timerText;

    [HideInInspector]
    [SyncVar]
    public float matchTime = 120;

    private float minutesPassed
    {
        get
        {
            return ((int)matchTime / 60);
        }
    }

    private float secondsPassed
    {
        get
        {
            return ((int)matchTime % 60);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        UpdateDisplay();
        updateTimer();
	}

    

    void UpdateDisplay()
    {
        string minuteDisplay = (minutesPassed < 10 ? "0" : "") + minutesPassed.ToString();

        string secondDisplay = (secondsPassed < 10 ? "0" : "") + secondsPassed.ToString();

        timerText.text = minuteDisplay + ":" + secondDisplay;
    }
    void updateTimer()
    {
        //(



        //Manager.localPlayer.isServer)
        if (PlayerManager.players.Count > 1)
        {
            matchTime -= Time.deltaTime;
        }
    }
}
