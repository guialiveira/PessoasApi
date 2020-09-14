using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GlobalPessoas.Data;
using GlobalPessoas.Models;
using Microsoft.AspNetCore.Authorization;

namespace GlobalPessoas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PessoasController : ControllerBase
    {
        private readonly GlobalPessoasContext _context;

        public PessoasController(GlobalPessoasContext context)
        {
            _context = context;
        }

        // GET: api/Pessoas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pessoa>>> GetPessoa()
        {
            return await _context.Pessoa.ToListAsync();
        }

        // GET: api/Pessoas/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Pessoa>> GetPessoa(int id)
        {
            var pessoa = await _context.Pessoa.FindAsync(id);

            if (pessoa == null)
            {
                return NotFound("A pessoa não foi encontrada");
            }

            return pessoa;
        }

        // GET: api/Pessoas/ByUf?uf=GO
        [HttpGet("{ByUf}")]
        public async Task<ActionResult<IEnumerable<Pessoa>>> GetByUf(string uf) 
        {
            var result = from obj in _context.Pessoa select obj;
            result = result.Where(o => o.UF == uf);
            return await result.ToListAsync();
        }

        // PUT: api/Pessoas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<Pessoa>> PutPessoa(int id, Pessoa pessoa)
        {
            if (id != pessoa.Id)
            {
                return BadRequest("O Id passado não é o mesmo Id do objeto passado");
            }

            _context.Entry(pessoa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return pessoa;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PessoaExists(id))
                {
                    return NotFound("Essa pessoa não existe");
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/Pessoas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Pessoa>> PostPessoa(Pessoa pessoa)
        {
            _context.Pessoa.Add(pessoa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPessoa", new { id = pessoa.Id }, pessoa);
        }

        // DELETE: api/Pessoas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Pessoa>> DeletePessoa(int id)
        {
            var pessoa = await _context.Pessoa.FindAsync(id);
            if (pessoa == null)
            {
                return NotFound("Essa pessoa já não existe");
            }

            _context.Pessoa.Remove(pessoa);
            await _context.SaveChangesAsync();

            return pessoa;
        }

        private bool PessoaExists(int id)
        {
            return _context.Pessoa.Any(e => e.Id == id);
        }
    }
}
