using LaborDoctor.API.Models;
using LaborDoctor.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaborDoctor.API.Controllers.Schedule
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScheduleController : ControllerBase
    {
        private readonly AppDbContext? _context;
        public ScheduleController(AppDbContext context){
            _context = context!;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ScheduleModel>>> GetSchedule(int id_medico){
            var Schedule = await _context!.tb_schedule!
                .Where(x => x.id_medico == id_medico)
                .OrderBy(g => g.data)
                // .ThenBy(g => g.hora)
                .ToListAsync();
            
            if(Schedule == null){
                return NotFound();
            }

            return Ok(Schedule);
        }

        [HttpPut("{id_schedule}")]
        public ActionResult PutSchedule(int id_schedule, ScheduleModel Schedule)
        {
            if (id_schedule != Schedule.id_schedule)
            {
                return BadRequest();
            }

            var model = _context!.tb_schedule!.FirstOrDefault(x => x.id_schedule == id_schedule);

            if (model == null)
            {
                return NotFound();
            }

            model.data = Schedule.data;
            // model.hora = Schedule.hora;
            model.status = Schedule.status;

            _context.tb_schedule!.Update(model);

            _context.SaveChanges();
            return Ok(model);
            
        }

        [HttpPost]
        public async Task<ActionResult<ScheduleModel>> PostSchedule(ScheduleModel Schedule){
            var modelSchedule = _context!.tb_schedule!
                .FirstOrDefault(x => x.data == Schedule.data && x.id_medico == Schedule.id_medico);
            
            if (Schedule.data == null)
            {
                return NotFound("Hora não digitada");
            }
            if (modelSchedule != null)
            {
                return NotFound("Esse médico já tem esse horário!");
            }
            
            _context!.tb_schedule!.Add(Schedule);
            await _context.SaveChangesAsync();

            return Ok(Schedule);
        }

        [HttpDelete("{id_schedule}")]
        public async Task<ActionResult> DeleteSchedule(int id_schedule){
            var Schedule = await _context!.tb_schedule!.FindAsync(id_schedule);
            if(Schedule == null){
                return NotFound();
            }

            _context.tb_schedule.Remove(Schedule);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}