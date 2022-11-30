using System.Collections.Generic;
using CommandAPI.Models;

namespace CommandAPI.Data;

public class MockCommandAPIRepo : ICommandAPIRepo
{
    public void CreateCommand(Command cmd)
    {
        throw new NotImplementedException();
    }

    public void DeleteCommand(Command cmd)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Command> GetAllCommands()
    {
        var commands = new List<Command>{
            new Command{Id = 0, HowTo = "How To Generate a Migration", CommandLine = "dotnet ef migrations add <Name Of Migration>", Platform = ".Net Core EF"},
            new Command{Id = 1, HowTo = "Run Migrations", CommandLine = "dotnet ef database update", Platform = ".Net Core EF"},
            new Command{Id = 2, HowTo = "List Active Migrations", CommandLine = "dotnet ef migrations list", Platform = ".Net Core EF"}
        };

        return commands;
    }

    public Command GetCommandById(int Id)
    {
        return new Command{Id = 0, HowTo = "How To Generate a Migration", CommandLine = "dotnet ef migrations add <Name Of Migration>", Platform = ".Net Core EF"};
    }

    public bool SaveChanges()
    {
        throw new NotImplementedException();
    }

    public void UpdateCommand(Command cmd)
    {
        throw new NotImplementedException();
    }
}