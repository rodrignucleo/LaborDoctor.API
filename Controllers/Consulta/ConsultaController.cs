using LaborDoctor.API.Models;
using LaborDoctor.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaborDoctor.API.Controllers.Consulta
{
    [ApiController]
    [Route("api/consulta")]
    public class ConsultaController : ControllerBase
    {
        private readonly AppDbContext? _context;
        public ConsultaController(AppDbContext context){
            _context = context!;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConsultaModel>>> GetConsulta(int ?id_medico, int ?id_paciente){
            var Consulta = new List<ConsultaModel>();

            if(id_medico == null && id_paciente == null){
                Consulta = await _context!.tb_consulta!
                .Include(x => x.medico)
                .Include(x => x.paciente)
                .Include(x => x.schedule)
                .OrderBy(g => g.schedule!.data)
                // .OrderBy(g => g.schedule!.hora)
                .ToListAsync();
            }
            else{
                Consulta = await _context!.tb_consulta!
                .Where(x => x.id_medico == id_medico || x.id_paciente == id_paciente)
                .Include(x => x.medico)
                .Include(x => x.paciente)
                .Include(x => x.schedule)
                .OrderBy(g => g.schedule!.data)
                // .OrderBy(g => g.schedule!.hora)
                .ToListAsync();
            }

            if(Consulta == null){
                return NotFound();
            }

            return Ok(Consulta);
        }

        [HttpPut("cancelar/{id_consulta}")]
        public ActionResult PutConsulta(int id_consulta)
        {
            var model = _context!.tb_consulta!.FirstOrDefault(x => x.id_consulta == id_consulta);
            var modelSchedule = _context!.tb_schedule!.FirstOrDefault(x => x.id_schedule == model!.id_schedule);
            if (model == null)
            {
                return NotFound();
            }

            modelSchedule!.status = true;
            model.status = false;

            _context.tb_consulta!.Update(model);

            _context.SaveChanges();
            return Ok(model);
        }

        [HttpPut("{id_consulta}")]
        public ActionResult PutConsulta(int id_consulta, ConsultaModel Consulta)
        {
            var modelSchedule = _context!.tb_schedule!
                .FirstOrDefault(x => x.id_schedule == Consulta.id_schedule);

            var modelConsulta = _context!.tb_consulta!
                .Include(x => x.medico)
                .Include(x => x.paciente)
                .Include(x => x.schedule)
                .FirstOrDefault(x => x.id_paciente == Consulta.id_paciente && x.schedule!.data == modelSchedule!.data);
            
            if (modelConsulta != null)
            {
                return BadRequest("Esse paciente já tem esse horário!");
            }
            
            if (id_consulta != Consulta.id_consulta)
            {
                return BadRequest();
            }

            var model = _context!.tb_consulta!
            .Include(x => x.schedule)
            .FirstOrDefault(x => x.id_consulta == id_consulta);

            if (model == null)
            {
                return NotFound();
            }

            modelSchedule!.status = false;
            model.schedule!.status = true;

            model.id_medico = Consulta.id_medico;
            model.id_paciente = Consulta.id_paciente;
            model.id_schedule = Consulta.id_schedule;

            _context.tb_consulta!.Update(model);

            _context.SaveChanges();
            return Ok(model);
            
        }

        [HttpPost]
        public async Task<ActionResult<ConsultaModel>> PostConsulta(ConsultaModel Consulta){

            var modelSchedule = _context!.tb_schedule!
                .FirstOrDefault(x => x.id_schedule == Consulta.id_schedule);

            var modelConsulta = _context!.tb_consulta!
                .Include(x => x.medico)
                .Include(x => x.paciente)
                .Include(x => x.schedule)
                .FirstOrDefault(x => x.id_paciente == Consulta.id_paciente && x.schedule!.data == modelSchedule!.data);
            
            if (modelConsulta != null)
            {
                return NotFound("Esse paciente já tem esse horário!");
            }
            
            modelSchedule!.status = false;
            _context!.tb_consulta!.Add(Consulta);
            await _context.SaveChangesAsync();

            return Ok(Consulta);
        }

        [HttpDelete("{id_consulta}")]
        public async Task<ActionResult> DeleteConsulta(int id_consulta){
            var Consulta = await _context!.tb_consulta!.FindAsync(id_consulta);
            if(Consulta == null){
                return NotFound();
            }

            _context.tb_consulta.Remove(Consulta);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}