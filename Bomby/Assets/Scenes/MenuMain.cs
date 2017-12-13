using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class MenuMain : MonoBehaviour {

    public GameObject HostMenu;
    public GameObject ClientMenu;

    public Button HostButton;
    public Button JoinButton;
    public Button QuitButton;

    public InputField HostPort;
    public Button HostStart;
    public Button HBack;

    public InputField ClientAddress;
    public InputField ClientPort;
    public Button ClientStart;
    public Button CBack;

    public InputField PlayerName;
    public Dropdown Teams;

    public GameObject ServerAuthoritativePlayer;
    public GameObject ClientAuthoritativePlayer;





    void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}
}
