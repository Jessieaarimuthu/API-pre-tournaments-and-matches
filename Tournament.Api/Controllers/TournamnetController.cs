using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tournament.Data.Data;
using Tournament.Core.Entities;
using Tournament.Core.Repositories;

namespace Tournament.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamnetController : ControllerBase
    {
        //private readonly TournamentApiContext _context;

        //public TournamnetController(TournamentApiContext context)
        //{
        //    _context = context;
        //}
        public IUoW _unitOfWork;

        public TournamnetController(IUoW unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Tournamnetmainmodels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tournamnetmainmodel>>> GetTournamnetmainmodel()
        {
            var tournamentall= await _unitOfWork.TournamentRepository.GetAllAsync();
            return Ok(tournamentall);
        }

        // GET: api/Tournamnetmainmodels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tournamnetmainmodel>> GetTournamnetmainmodel(int id)
        {
            var tournamnetmainmodel = await _unitOfWork.TournamentRepository.GetAsync(id);

            if (tournamnetmainmodel == null)
            {
                return NotFound();
            }

            return tournamnetmainmodel;
        }

        // PUT: api/Tournamnetmainmodels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTournamnetmainmodel(int id, Tournamnetmainmodel tournamnetmainmodel)
        {
            if (id != tournamnetmainmodel.ID)
            {
                return BadRequest();
            }

            _unitOfWork.TournamentRepository.EntityStateModified(tournamnetmainmodel);

            try
            {
                await _unitOfWork.CompleteAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (! await TournamnetmainmodelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Tournamnetmainmodels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tournamnetmainmodel>> PostTournamnetmainmodel(Tournamnetmainmodel tournamnetmainmodel)
        {
            _unitOfWork.TournamentRepository.Add(tournamnetmainmodel);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction("GetTournamnetmainmodel", new { id = tournamnetmainmodel.ID }, tournamnetmainmodel);
        }

        // DELETE: api/Tournamnetmainmodels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTournamnetmainmodel(int id)
        {
            var tournamnetmainmodel = await _unitOfWork.TournamentRepository.GetAsync(id);
            if (tournamnetmainmodel == null)
            {
                return NotFound();
            }

            _unitOfWork.TournamentRepository.Remove(tournamnetmainmodel);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        private async Task<bool> TournamnetmainmodelExists(int id)
        {
            return await _unitOfWork.TournamentRepository.AnyAsync(id);
        }
    }
}
