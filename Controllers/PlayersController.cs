//using IPLApplication.Models;
//using IPLApplication.DataAccess;
//using Microsoft.AspNetCore.Mvc;
//using System.ComponentModel.Design;

//namespace IPLApplication.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class PlayersController : ControllerBase
//    {
//        private readonly IPlayerRepository _playerRepository;

//        public PlayersController(IPlayerRepository playerRepository)
//        {
//            _playerRepository = playerRepository;
//        }

//        [HttpPost]
//        public IActionResult CreatePlayer([FromBody] Player player)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            _playerRepository.AddPlayer(player);
//            return CreatedAtAction(nameof(CreatePlayer), new { id = player.PlayerId }, player);
//        }

//        [HttpGet("top-players")]
//        public IActionResult GetTopPlayers()
//        {
//            var players = _playerRepository.GetTopPlayers();
//            return Ok(players);
//        }
//    }
//}


////ADO: ActiveDesignerEventArgs Data Objects
////EF Core: Entity Framework Core 