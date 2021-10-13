using CartasWeb.Data;
using CartasWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartasWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomController : ControllerBase
    {
        private readonly AppDbContext _context;
        public RandomController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<Carta>> GetDato()
        {
            var list = await _context.Cartas.ToListAsync();
            var max = list.Count;
            int index = new Random().Next(0, max);
            var dato = list[index];
            if (dato == null)
            {
                return NoContent();
            }
            return dato;
        }
    }
}
