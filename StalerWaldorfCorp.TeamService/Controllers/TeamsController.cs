using Microsoft.AspNetCore.Mvc;
using StalerWaldorfCorp.TeamService.Models;
using StalerWaldorfCorp.TeamService.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StalerWaldorfCorp.TeamService.Controllers
{
    public class TeamsController:Controller
    {
        ITeamRepository repository;
        public TeamsController(ITeamRepository repo)
        {
            repository = repo;
        }
        [HttpGet]
        public async virtual Task<IActionResult> GetAllTeams()
        {
            return  this.Ok(repository.GetTeams());
        }
        [HttpPost]
        public async virtual Task<IActionResult> CreateTeam(Team t)
        {
            repository.AddTeam(t);
            return this.Ok();
        }
    }
}
