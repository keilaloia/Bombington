using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public static class PlayerManager
{
    public static Player localPlayer = null;

    public static List<Player> players = new List<Player>();


    public static List<Player> firstPlayers
    { get { return players.Where(x => x.team == Player.Team.P1).ToList(); } }

    public static List<Player> secondPlayers
    { get { return players.Where(x => x.team == Player.Team.P2).ToList(); } }

    public static List<Player> soloPlayers
    { get { return players.Where(x => x.team == Player.Team.P3).ToList(); } }

}
