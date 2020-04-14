using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sustainable_food_api.Models;

namespace sustainable_food_api.Controllers
{

    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DatabaseContext _dbContext;

        public UsersController(DatabaseContext context)
        {
            _dbContext = context;
        }

        // api/users    
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<User>> GetUser(string id)
        {
            User user = await _dbContext.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // post: api/users/ 
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<User>> CreateUser([FromBody] User user)
        {
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<User>> UpdateUser(string id, User user)
        {
            // check if the id is the same as the user
            if (id != user.Id)
            {
                return BadRequest();
            }
            _dbContext.Entry(user).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                bool userExists = _dbContext.Users.Any(e => e.Id == user.Id);

                if (!userExists)
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

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<User>> DeleteUser(string id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();


            return user;
        }


    }
}
