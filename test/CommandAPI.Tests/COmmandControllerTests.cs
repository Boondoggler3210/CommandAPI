using System;
using System.Collections.Generic;
using Moq;
using AutoMapper;
using CommandAPI.Models;
using CommandAPI.Data;
using Xunit;
using CommandAPI.Controllers;
using CommandAPI.Profiles;
using Microsoft.AspNetCore.Mvc;


namespace CommandAPI.Tests;

public class CommandControllerTests
{
    [Fact]
    public void GetCommandItems_Returns200OK_WhenDBIsEmpty()
    {
        //Arrange
        var mockRepo = new Mock<ICommandAPIRepo>();
        mockRepo.Setup(repo => repo.GetAllCommands()).Returns(GetCommands(0));

        var realProfile = new CommandsProfile();
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(realProfile));
        IMapper mapper = new Mapper(configuration);


        var controller = new CommandsController(mockRepo.Object, mapper); 
        //We need to creat an instance of our command controller class
    }

    private List<Command> GetCommands(int num)
    {
        var commands = new List<Command>();
        if(num > 0)
        {
            commands.Add(new Command{
                Id = 0,
                HowTo = "How To Generate a Migration",
                CommandLine = "dotnet ef migrations add <name of Migration>",
                Platform = ".Net Core EF"
            });
        }
        return commands;
    }
}