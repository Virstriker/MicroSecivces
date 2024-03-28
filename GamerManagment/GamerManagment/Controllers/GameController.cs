using GamerManagment.DTO;
using GamerManagment.Manager;
using Microsoft.AspNetCore.Mvc;

namespace GamerManagment.Controllers
{
    [Route("Game")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameManager _gameManager;
        public GameController(IGameManager gameManager)
        {
            _gameManager = gameManager;
        }
        [HttpGet("GetAllGameList")]
        public async Task<List<GameViewModel>> GetAllGameList()
        {
            return await _gameManager.GetGames();
        }
        [HttpGet("GameById{name}")]
        public async Task<GameViewModel> GetGameById(string name)
        {
            var result = await _gameManager.GetGameById(name);
            if (result != null)
            {
                return result;
            }
            return null;
        }

        [HttpPost("AddGame")]
        public async Task<IActionResult> AddGame(GameViewModel game)
        {
            var result = await _gameManager.AddGame(game);
            if (result != null)
            {
                return Ok("Game added sucessfully");
            }
            return BadRequest("Game ID alredy exist!");
        }
        [HttpPut("UpdateGame")]
        public async Task<IActionResult> UpdateGame(GameViewModel game)
        {
            var result = await _gameManager.UpdateGame(game);
            if (result != null)
            {
                return Ok("updated");
            }
            return BadRequest("Not found");
        }
        [HttpDelete("DeleteGame{id}")]
        public async Task<IActionResult> DeleteGame(int id)
        {
            var result = await _gameManager.DeleteGame(id);
            if (result != null)
            {
                return Ok("Deleted");
            }
            return BadRequest("Not found");
        }
        [HttpGet("GameWithGamer")]
        public async Task<IEnumerable<object>> GetGameWithGamer()
        {
            return await _gameManager.GameWithGamer();
        }


    }
}
