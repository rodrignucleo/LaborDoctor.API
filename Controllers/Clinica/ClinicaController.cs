using LaborDoctor.API.Models;
using LaborDoctor.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaborDoctor.API.Controllers.Clinica
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClinicaController : ControllerBase
    {
        private readonly AppDbContext? _context;
        public ClinicaController(AppDbContext context){
            _context = context!;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClinicaModel>>> GetClinica(){
            return await _context!.tb_clinica!.OrderBy(g => g.nome).ToListAsync();
        }

        [HttpGet("{id_clinica}")]
        public async Task<ActionResult<ClinicaModel>> GetClinica(int id_clinica){
            var Clinica = await _context!.tb_clinica!.FindAsync(id_clinica);
            
            if(Clinica == null){
                return NotFound();
            }
            return Clinica;
        }

        [HttpPut("{id_clinica}")]
        public ActionResult PutClinica(int id_clinica, ClinicaModel Clinica)
        {
            if (id_clinica != Clinica.id_clinica)
            {
                return BadRequest();
            }

            var model = _context!.tb_clinica!.FirstOrDefault(x => x.id_clinica == id_clinica);

            if (model == null)
            {
                return NotFound();
            }

            if (BCrypt.Net.BCrypt.Verify(Clinica.senha, model!.senha))
            {
                model.nome = Clinica.nome;
                model.nome_fantasia = Clinica.nome_fantasia;
                model.cnpj = Clinica.cnpj;
                model.telefone = Clinica.telefone;
                model.email = Clinica.email;

                _context.tb_clinica!.Update(model);

                _context.SaveChanges();
                return Ok(model);
            }
            else
            {
                Console.WriteLine("Senha Nao esta igual!");
                return BadRequest();
            }
        }

        [HttpGet("edit/password/{id_clinica}")]
        public ActionResult PutClinicaSenha(int id_clinica, string senha_antiga, string senha_nova)
        {
            var model = _context!.tb_clinica!.FirstOrDefault(x => x.id_clinica == id_clinica);

            if (model == null)
            {
                return NotFound();
            }

            // clinica.senha_antiga = BCrypt.Net.BCrypt.HashPassword(clinica.senha_antiga);
            Console.WriteLine("Senha Nova: " + senha_nova);
            Console.WriteLine("Senha Antiga: " + senha_antiga);

            if (BCrypt.Net.BCrypt.Verify(senha_antiga, model!.senha))
            {
                model.senha = BCrypt.Net.BCrypt.HashPassword(senha_nova);
                
                _context.tb_clinica!.Update(model);

                _context.SaveChanges();
                return Ok(model);
            }
            else
            {
                Console.WriteLine("A senha não esta igual!");
                return NotFound("A senha não esta igual!");
            }
        }

        [HttpPost]
        public async Task<ActionResult<ClinicaModel>> PostClinica(ClinicaModel Clinica){
            var modelClinica = _context!.tb_clinica!.FirstOrDefault(x => x.email == Clinica.email);
            
            if (Clinica.email == "")
            {
                return NotFound("Email não digitado");
            }
            if (modelClinica != null)
            {
                return NotFound("Esse email já esta cadastrado!");
            }
            
            _context!.tb_clinica!.Add(Clinica);
            await _context.SaveChangesAsync();

            // return CreatedAtAction("GetClinica", new{id = Clinica.id_clinica}, Clinica);
            return Ok(Clinica);
        }

        [HttpDelete("{id_clinica}")]
        public async Task<ActionResult> DeleteClinica(int id_clinica){
            var Clinica = await _context!.tb_clinica!.FindAsync(id_clinica);
            if(Clinica == null){
                return NotFound();
            }

            _context.tb_clinica.Remove(Clinica);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}