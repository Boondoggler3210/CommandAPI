using System;
using CommandAPI.Models;
using System.Collections.Generic;

namespace CommandAPI.Data;

public class SqlCommandAPIRepo : ICommandAPIRepo
{
    private readonly CommandContext _context;

    public SqlCommandAPIRepo(CommandContext context)
    {
        _context = context;
    }

    public void CreateCommand(Command cmd)
    {
        if(cmd == null)
        {
            throw new ArgumentNullException(nameof(cmd));
        }

        _context.CommandItems.Add(cmd);
    }

    public void DeleteCommand(Command cmd)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Command> GetAllCommands()
    {
        return _context.CommandItems.ToList();
    }

    public Command GetCommandById(int Id)
    {
        return _context.CommandItems.FirstOrDefault(p => p.Id == Id);
    }

    public bool SaveChanges()
    {
        return(_context.SaveChanges() >= 0);
    }

    public void UpdateCommand(Command cmd)
    {
        // Nothing to do here
    }
}