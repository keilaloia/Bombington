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

    void Start()
    {
        SetupPlayerPrefab();
        SetupMainMenu();
    }


    void SetupPlayerPrefab()
    {
     //   NetworkManager.singleton.playerPrefab = GameSettings.serverAuthoritative ? ServerAuthoritativePlayer : ClientAuthoritativePlayer;
    }

    void SetupMainMenu()
    {
        HostButton.onClick.AddListener(OpenHostWindow);
        HostButton.onClick.AddListener(CloseClientWindow);

        JoinButton.onClick.AddListener(OpenClientWindow);
        JoinButton.onClick.AddListener(CloseHostWindow);

        QuitButton.onClick.AddListener(QuitGame);

        SetupHostMenu();
        SetupClientMenu();
        SetupUserMenu();
    }
    
    void SetupHostMenu()
    {
        HostPort.onEndEdit.AddListener(SetPort);
        HostStart.onClick.AddListener(StartHost);
        HBack.onClick.AddListener(CloseHostWindow);
    }

    void SetupClientMenu()
    {
        ClientAddress.onEndEdit.AddListener(SetAddress);
        ClientPort.onEndEdit.AddListener(SetPort);
        ClientStart.onClick.AddListener(StartClient);
        CBack.onClick.AddListener(CloseClientWindow);
    }

    void SetupUserMenu()
    {
        Teams.onValueChanged.AddListener(SetTeam);
        PlayerName.onValueChanged.AddListener(SetName);
    }
    void OpenHostWindow()
    {
        HostMenu.SetActive(true);
    }
    void OpenClientWindow()
    {
        ClientMenu.SetActive(true);
    }
    void CloseHostWindow()
    {
        HostMenu.SetActive(false);
    }
    void CloseClientWindow()
    {
        ClientMenu.SetActive(false);
    }
    void SetAddress(string address)
    {
        NetworkManager.singleton.networkAddress = address;
    }
    void SetPort(string port)
    {
        NetworkManager.singleton.networkPort = System.Int32.Parse(port);
    }
    void SetTeam(int team)
    {
        UserSettings.team = (Player.Team)team;
    }
    void SetName(string name)
    {
        UserSettings.playerName = name;
    }
    void StartHost()
    {
        NetworkManager.singleton.StartHost();
    }
    void StartClient()
    {
        NetworkManager.singleton.StartClient();
    }
    void QuitGame()
    {
        Application.Quit();
    }





    void Update ()
    {
		
	}
}
