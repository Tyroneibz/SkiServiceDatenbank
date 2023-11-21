using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkiServiceDatenbank.data;
using SkiServiceDatenbank.models;
using SkiServiceDatenbank.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace SkiServiceDatenbank.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SkiServiceController : ControllerBase
    {
        private readonly DatenbankSkiServiceContext _context;

        public SkiServiceController(DatenbankSkiServiceContext context)
        {
            _context = context;
        }

        // GET: api/SkiService
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetSkiServices()
        {
            var services = await _context.SkiServices
                                         .Select(s => new ServiceSendDto
                                         {
                                             Id = s.Id,
                                             Kundenname = s.Kundenname,
                                             Email = s.Email,
                                             Telefon = s.Telefon,
                                             Priorität = s.Priorität,
                                             Dienstleistung = s.Dienstleistung
                                         })
                                         .ToListAsync();
            return Ok(services);
        }

        // GET: api/SkiService/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetSkiService(int id)
        {
            var skiServiceDto = await _context.SkiServices
                                              .Where(s => s.Id == id)
                                              .Select(s => new ServiceSendDto
                                              {
                                                  Id = s.Id,
                                                  Kundenname = s.Kundenname,
                                                  Email = s.Email,
                                                  Telefon = s.Telefon,
                                                  Priorität = s.Priorität,
                                                  Dienstleistung = s.Dienstleistung
                                              })
                                              .FirstOrDefaultAsync();

            if (skiServiceDto == null)
            {
                return NotFound();
            }

            return Ok(skiServiceDto);
        }

        // POST: api/SkiService
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PostSkiService([FromBody] ServiceSendDto serviceSendDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var skiService = new SkiService
            {
                Kundenname = serviceSendDto.Kundenname,
                Email = serviceSendDto.Email,
                Telefon = serviceSendDto.Telefon,
                Priorität = serviceSendDto.Priorität,
                Dienstleistung = serviceSendDto.Dienstleistung
            };

            _context.SkiServices.Add(skiService);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSkiService), new { id = skiService.Id }, skiService);
        }

        // PUT: api/SkiService/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutSkiService(int id, [FromBody] ServiceSendDto serviceSendDto)
        {
            if (id <= 0 || serviceSendDto == null || id != serviceSendDto.Id)
            {
                return BadRequest();
            }

            var skiService = await _context.SkiServices.FindAsync(id);
            if (skiService == null)
            {
                return NotFound();
            }

            skiService.Kundenname = serviceSendDto.Kundenname;
            skiService.Email = serviceSendDto.Email;
            skiService.Telefon = serviceSendDto.Telefon;
            skiService.Priorität = serviceSendDto.Priorität;
            skiService.Dienstleistung = serviceSendDto.Dienstleistung;

            _context.Entry(skiService).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/SkiService/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteSkiService(int id)
        {
            var skiService = await _context.SkiServices.FindAsync(id);
            if (skiService == null)
            {
                return NotFound();
            }

            _context.SkiServices.Remove(skiService);
            await _context.SaveChangesAsync();

            return Ok(skiService);
        }
    }
}
