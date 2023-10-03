using LaborDoctor.API.Models;
using LaborDoctor.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaborDoctor.API.Controllers.Paciente
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacienteController : ControllerBase
    {
        private readonly AppDbContext? _context;
        public PacienteController(AppDbContext context){
            _context = context!;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PacienteModel>>> GetPaciente(){
            return await _context!.tb_paciente!.OrderBy(g => g.nome).ToListAsync();
        }

        [HttpGet("{id_paciente}")]
        public async Task<ActionResult<PacienteModel>> GetPaciente(int id_paciente){
            var Paciente = await _context!.tb_paciente!.FindAsync(id_paciente);
            
            if(Paciente == null){
                return NotFound();
            }
            return Paciente;
        }

        [HttpPut("{id_paciente}")]
        public ActionResult PutPaciente(int id_paciente, PacienteModel Paciente)
        {
            if (id_paciente != Paciente.id_paciente)
            {
                return BadRequest();
            }

            var model = _context!.tb_paciente!.FirstOrDefault(x => x.id_paciente == id_paciente);

            if (model == null)
            {
                return NotFound();
            }

            if (BCrypt.Net.BCrypt.Verify(Paciente.senha, model!.senha))
            {
                model.nome = Paciente.nome;
                model.cpf = Paciente.cpf;
                model.telefone = Paciente.telefone;
                model.email = Paciente.email;

                _context.tb_paciente!.Update(model);

                _context.SaveChanges();
                return Ok(model);
            }
            else
            {
                Console.WriteLine("Senha Nao esta igual!");
                return BadRequest();
            }
            
        }

        [HttpGet("edit/password/{id_paciente}")]
        public ActionResult PutPacienteSenha(int id_paciente, string senha_antiga, string senha_nova)
        {
            var model = _context!.tb_paciente!.FirstOrDefault(x => x.id_paciente == id_paciente);

            if (model == null)
            {
                return NotFound();
            }

            // paciente.senha_antiga = BCrypt.Net.BCrypt.HashPassword(paciente.senha_antiga);
            Console.WriteLine("Senha Nova: " + senha_nova);
            Console.WriteLine("Senha Antiga: " + senha_antiga);

            if (BCrypt.Net.BCrypt.Verify(senha_antiga, model!.senha))
            {
                model.senha = BCrypt.Net.BCrypt.HashPassword(senha_nova);
                
                _context.tb_paciente!.Update(model);

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
        public async Task<ActionResult<PacienteModel>> PostPaciente(PacienteModel Paciente){
            var modelPaciente = _context!.tb_paciente!.FirstOrDefault(x => x.email == Paciente.email);
            
            if (Paciente.email == "")
            {
                return NotFound("Email não digitado");
            }
            if (modelPaciente != null)
            {
                return NotFound("Esse email já esta cadastrado!");
            }
            
            _context!.tb_paciente!.Add(Paciente);
            await _context.SaveChangesAsync();

            // return CreatedAtAction("GetPaciente", new{id = Paciente.id_paciente}, Paciente);
            return Ok(Paciente);
        }

        [HttpDelete("{id_paciente}")]
        public async Task<ActionResult> DeletePaciente(int id_paciente){
            var Paciente = await _context!.tb_paciente!.FindAsync(id_paciente);
            if(Paciente == null){
                return NotFound();
            }

            _context.tb_paciente.Remove(Paciente);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}