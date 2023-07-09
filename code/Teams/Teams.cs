using System;
using System.Collections.Generic;
using System.Linq;

namespace PropHunt;

public class Teams
{
    public static List<BaseTeam> RegisteredTeams = new();


    /// Method for getting a generic variable type of a BaseTeam.
    public static T Get<T>() where T : BaseTeam
    {
        if (RegisteredTeams.OfType<T>().Any())
        {
            return RegisteredTeams.OfType<T>().First();
        }

        return TypeLibrary.GetType<T>().Create<T>();
    }

    public static BaseTeam GetByName(string name)
    {
        if (RegisteredTeams.OfType<BaseTeam>().Where(x => x.TeamName == name).Any())
        {
            return RegisteredTeams.OfType<BaseTeam>().Where(x => x.TeamName == name).First();
        }
        return null;
    }

    public static void InitializeTeams()
    {
        // Get all the derived classes of BaseTeam
        var teamTypes = TypeLibrary.GetTypes<BaseTeam>().Where(type => type.TargetType.IsSubclassOf(typeof(BaseTeam))).ToList();

        if (teamTypes.Count() == 0)
        {
            throw new Exception("No team classes were initialized. Check the log for more information.");
        }

        foreach (var team in teamTypes)
        {
            if (RegisteredTeams.Where(x => x.GetType() == team.TargetType).Any())
                continue;
            
            team.Create<BaseTeam>();
        }
    }
}