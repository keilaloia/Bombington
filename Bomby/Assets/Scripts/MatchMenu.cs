using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MatchMenu : MonoBehaviour {





	// Use this for initialization
	void Start ()
    {
        
	}
	
    void SetAddress(string address)
    {
        NetworkManager.singleton.networkAddress = address;
        
    }
    void Update ()
    {
		
	}
}
