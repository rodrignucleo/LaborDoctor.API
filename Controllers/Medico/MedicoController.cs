using LaborDoctor.API.Models;
using LaborDoctor.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaborDoctor.API.Controllers.Medico
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicoController : ControllerBase
    {
        private readonly AppDbContext? _context;
        public MedicoController(AppDbContext context){
            _context = context!;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedicoModel>>> GetMedico(){
            return await _context!.tb_medico!.OrderBy(g => g.nome).ToListAsync();
        }

        [HttpGet("{id_medico}")]
        public async Task<ActionResult<MedicoModel>> GetMedico(int id_medico){
            var Medico = await _context!.tb_medico!.FindAsync(id_medico);
            
            if(Medico == null){
                return NotFound();
            }
            return Medico;
        }

        [HttpPut("{id_medico}")]
        public ActionResult PutMedico(int id_medico, MedicoModel Medico)
        {
            if (id_medico != Medico.id_medico)
            {
                return BadRequest();
            }

            var model = _context!.tb_medico!.FirstOrDefault(x => x.id_medico == id_medico);

            if (model == null)
            {
                return NotFound();
            }

            model.nome = Medico.nome;
            model.cpf = Medico.cpf;
            model.telefone = Medico.cpf;
            model.email = Medico.email;

            _context.tb_medico!.Update(model);

            _context.SaveChanges();
            return Ok(model);
            
        }

        [HttpPost]
        public async Task<ActionResult<MedicoModel>> PostMedico(MedicoModel Medico){
            var modelMedico = _context!.tb_medico!.FirstOrDefault(x => x.email == Medico.email);
            
            if (Medico.email == "")
            {
                return NotFound("Email não digitado");
            }
            if (modelMedico != null)
            {
                return NotFound("Esse email já esta cadastrado!");
            }
            
            _context!.tb_medico!.Add(Medico);
            await _context.SaveChangesAsync();

            // return CreatedAtAction("GetMedico", new{id = Medico.id_medico}, Medico);
            return Ok(Medico);
        }

        [HttpDelete("{id_medico}")]
        public async Task<ActionResult> DeleteMedico(int id_medico){
            var Medico = await _context!.tb_medico!.FindAsync(id_medico);
            if(Medico == null){
                return NotFound();
            }

            _context.tb_medico.Remove(Medico);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}