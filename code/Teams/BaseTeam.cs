using Sandbox;
using System;
using System.Collections.Generic;

//
// You don't need to put things in a namespace, but it doesn't hurt.
//
namespace PropHunt;

/// <summary>
/// The teams are defined here and then their names will be defined afterwards.
/// </summary>

public abstract class BaseTeam {
    public abstract string TeamName { get; }
    public abstract Color TeamColor { get; }
    public IList<Player> Players { get; } = new List<Player>();

    protected BaseTeam()
    {

    }

    public virtual void AddPlayer(Player player)
    {
        Players.Add(player);
        player.Team = this;
    }

    public virtual void RemovePlayer(Player player)
    {
        Players.Remove(player);
        player.Team = null;
    }

    public virtual void Reset()
    {
        foreach (var player in Players)
        {
            player.Team = null;
        }

        Players.Clear();
    }
}