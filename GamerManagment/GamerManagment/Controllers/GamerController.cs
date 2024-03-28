using GamerManagment.DTO;
using GamerManagment.Manager;
using GamerManagment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamerManagment.Controllers
{
   
    [Route("Gamer")]
    [ApiController]
    public class GamerController : ControllerBase
    {
        private readonly IGamerManager _gamerManager;
        public GamerController(IGamerManager gamerManager)
        {
            _gamerManager = gamerManager;
        }

        [HttpGet("GetAllGamer")]
        public async Task<List<GamerViewModelWithId>> Get()
        {
            return await _gamerManager.GetGamers();

        }
        [HttpGet("GetGamerById{id}")]
        public async Task<GamerViewModelWithId> Get1(int id)
        {
            var result = await _gamerManager.GetGamerWithId(id);
            if(result != null)
            {
                return result;
            }
            return null;
        }

        [HttpPost("AddGamer")]
        public async Task<string> get1(GamerViewModel gamer1)
        {
          
            var data = await _gamerManager.AddGamer(gamer1);
            if (data != null)
            {
                
                return "Added sucessfully";
            }

            return "Id alredy exist!";
       }
        [HttpDelete("DeleteGamer{id}")]
        public async Task<string> delete(int id)
        {
            var result = await _gamerManager.DeleteGamerWithId(id);
            if(result != null)
            {
                string a = "deleted";
                return "Deleted";
            }
            return "Not found";
        }
        [HttpPut("UpdateGamer")]
        public async Task<string> Update(GamerViewModelWithId gamer)
        {
            var result = await _gamerManager.UpdateGamerWithId(gamer);
            if (result != null)
            {
                return "Updated";
            }
            return "Not found";
        }
        [HttpGet("GetWithJoinGamer")]
        public async Task<IActionResult> GetJoinTable()
        {
            return Ok(await _gamerManager.GamerWithGame());
        }
        [HttpGet("PerticularGamerWithJoin{name}")]
        public async Task<JoinViewModel> GetJoinWithName(string name) {
            var result = await _gamerManager.GamerWithGameByName(name);
            if (result != null)
            {
                return result;
            }
            return null;
        }
    }
}
