using _03_WebApi_With_MongoDB.Models;
using _03_WebApi_With_MongoDB.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _03_WebApi_With_MongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatesController : ControllerBase
    {
        private readonly CandidatesService _candidatesService;
     

        public CandidatesController(CandidatesService candidatesService) =>
            _candidatesService = candidatesService;

        [HttpGet]
        public async Task<List<Candidate>> Get() =>
            await _candidatesService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Candidate>> Get(string id)
        {
            var candidate = await _candidatesService.GetAsync(id);

            if (candidate is null)
            {
                return NotFound();
            }
            Logger.WriteLog("called HttpGet for candidate " + candidate.Id);
            return candidate;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Candidate newcandidate)
        {
            await _candidatesService.CreateAsync(newcandidate);

            Logger.WriteLog("called HttpPost for candidate " + newcandidate.Id);


            return CreatedAtAction(nameof(Get), new { id = newcandidate.Id }, newcandidate);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Candidate updatedcandidate)
        {
            var candidate = await _candidatesService.GetAsync(id);

            if (candidate is null)
            {
                return NotFound();
            }

            updatedcandidate.Id = candidate.Id;

            Logger.WriteLog("called HttpPut for candidate " + updatedcandidate.Id);


            await _candidatesService.UpdateAsync(id, updatedcandidate);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var candidate = await _candidatesService.GetAsync(id);

            if (candidate is null)
            {
                return NotFound();
            }
            Logger.WriteLog("called HttpDelete for candidate " + candidate.Id);

            await _candidatesService.RemoveAsync(id);

            return NoContent();
        }
    }
}
