//using IPLApplication.Models;
//using IPLApplication.DataAccess;
//using Microsoft.AspNetCore.Mvc;

//namespace IPLApplication.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class MatchesController : ControllerBase
//    {
//        private readonly IMatchRepository _matchRepository;

//        public MatchesController(IMatchRepository matchRepository)
//        {
//            _matchRepository = matchRepository;
//        }

//        [HttpGet("date-range")]
//        public IActionResult GetMatchesByDateRange(DateTime startDate, DateTime endDate)
//        {
//            var matches = _matchRepository.GetMatchesByDateRange(startDate, endDate);
//            return Ok(matches);
//        }

//        [HttpGet("details")]
//        public IActionResult GetMatchDetails()
//        {
//            var matches = _matchRepository.GetMatchDetails();
//            return Ok(matches);
//        }
//    }
//}
