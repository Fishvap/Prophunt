using Sandbox;
using System;
using System.Collections.Generic;

namespace PropHunt;

public class Props : BaseTeam
{
    public override string TeamName => "Props";
    public override Color TeamColor => Color.Green;

    public Props()
    {
        // Add the team to the list of registered teams
        Teams.RegisteredTeams.Add(this);
    }
}
    