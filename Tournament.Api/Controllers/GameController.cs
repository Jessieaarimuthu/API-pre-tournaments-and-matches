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
using Microsoft.AspNetCore.Http.HttpResults;

namespace Tournament.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        //private readonly TournamentApiContext _context;

        //public GameController(TournamentApiContext context)
        //{
        //    _context = context;
        //}

        public IUoW _unitOfWork;

        public GameController(IUoW unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Gamemodels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gamemodel>>> GetGamemodel()
        {
            //return await _unitOfWork.GameRepository.GetAllAsync();
            //Task<IEnumerable<Gamemodel>> GetAllAsync();
           var gamegetall= await _unitOfWork.GameRepository.GetAllAsync();
            return Ok(gamegetall);
        }

        // GET: api/Gamemodels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Gamemodel>> GetGamemodel(int id)
        {
            var gamemodel = await _unitOfWork.GameRepository.GetAsync(id);

            if (gamemodel == null)
            {
                return NotFound();
            }

            return gamemodel;
        }

        // PUT: api/Gamemodels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGamemodel(int id, Gamemodel gamemodel)
        {
            if (id != gamemodel.ID)
            {
                return BadRequest();
            }

            _unitOfWork.GameRepository.EntityStateModified(gamemodel);

            try
            {
                await _unitOfWork.CompleteAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await GamemodelExists(id))
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

        // POST: api/Gamemodels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Gamemodel>> PostGamemodel(Gamemodel gamemodel)
        {
            _unitOfWork.GameRepository.Add(gamemodel);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction("GetGamemodel", new { id = gamemodel.ID }, gamemodel);
        }

        // DELETE: api/Gamemodels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGamemodel(int id)
        {
            var gamemodel = await _unitOfWork.GameRepository.GetAsync(id);
            if (gamemodel == null)
            {
                return NotFound();
            }

            _unitOfWork.GameRepository.Remove(gamemodel);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        private async Task<bool> GamemodelExists(int id)
        {
            return await _unitOfWork.GameRepository.AnyAsync(id);
        }
    } 
}
