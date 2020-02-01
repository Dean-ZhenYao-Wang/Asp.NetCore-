using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using StalerWaldorfCorp.TeamService.Controllers;
using StalerWaldorfCorp.TeamService.Models;
using StalerWaldorfCorp.TeamService.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StalerWaldorCorp.TeamService.Tests
{
    public class TeamsControllerTest
    {
        [Test]
        public async Task QueryTeamListReturnsCorrectTeams()
        {
            TeamsController controller = new TeamsController(new MemoryTeamRepository());
            var teams = (IEnumerable<Team>)
                (await controller.GetAllTeams() as ObjectResult).Value;
            Assert.AreEqual(teams.Count(), 0);
        }

        [Test]
        public async Task CreateTeamAddsTeamToList()
        {
            MemoryTeamRepository repository = new MemoryTeamRepository();
            TeamsController controller = new TeamsController(repository);
            var teams = (IEnumerable<Team>)
                (await controller.GetAllTeams() as ObjectResult).Value;
            List<Team> original = new List<Team>(teams);

            Team t = new Team("sample");
            var result = await controller.CreateTeam(t);

            var newTeamsRaw = (IEnumerable<Team>)
                (await controller.GetAllTeams() as ObjectResult).Value;
            List<Team> newTeams = new List<Team>(newTeamsRaw);

            Assert.AreEqual(newTeams.Count, original.Count + 1);

            var sampleTeam = newTeams.FirstOrDefault(target => target.Name == "sample");

            Assert.NotNull(sampleTeam);
            repository.Clear();
        }

    }
}
