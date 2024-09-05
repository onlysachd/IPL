//using IPLApplication.Models;
//using IPLApplication.DataAccess;
//using Microsoft.AspNetCore.Mvc;


//namespace IPLApplication.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class TeamsController : ControllerBase
//    {
//        private readonly ITeamRepository _teamRepository;

//        public TeamsController(ITeamRepository teamRepository)
//        {
//            _teamRepository = teamRepository;
//        }

//        [HttpGet]
//        public IActionResult GetTeams()
//        {
//            var teams = _teamRepository.GetTeams();
//            return Ok(teams);
//        }
//    }
//}