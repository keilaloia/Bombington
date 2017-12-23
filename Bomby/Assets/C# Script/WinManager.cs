using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class WinManager : NetworkBehaviour {

    //private BoxCollider BC;
    public List<Player> players;
    public Player[] findPlayers;

    public Text winner;
    public GameObject menuState;
    private NetworkTimer matchtime;
    // Use  this for initialization

     
    void Awake()
    {
        matchtime = FindObjectOfType<NetworkTimer>();
        gameObject.SetActive(true);
    }
	void Start ()
    {
        players = new List<Player>();

      
    }


    [ServerCallback]
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("we touched something");
        if(other.tag == "Player")
        {
            var playerThatFell = other.GetComponent<Player>();
            players.Remove(playerThatFell);
            Debug.Log("deleted");
            checkwinner();
        }

    }

	// Update is called once per frame
    [ServerCallback]
	void Update ()
    {
        players.Clear();
        findPlayers = FindObjectsOfType<Player>();
        for (int i = 0; i < findPlayers.Length; i++)
        {
            players.Add(findPlayers[i]);
            players[i].gameObject.name = "P" + (i + 1).ToString();
        }

        //winner.text = example;
        //matchtime
        // matchtime = gameObject.GetComponent<NetworkTimer>().matchTime;
        //Debug.Log(matchtime.matchTime);
    }

    void checkwinner()
    {
        if(matchtime.matchTime <= 0 || players.Count == 1)
        {
            RpcDeclareWinner(players[0].GetComponent<Player>().name.ToString() + " Wins!");

            winner.text = players[0].GetComponent<Player>().name.ToString() + " Wins!";
            menuState.SetActive(true);
            Debug.Log("win");
        }
        
    }

    [ClientRpc]
    void RpcDeclareWinner(string msg)
    {
        winner.text = msg;
        menuState.SetActive(true);
        Debug.Log("win");
    }
}
