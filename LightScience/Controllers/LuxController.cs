using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LightScience.Context;
using LightScience.Models;
using Microsoft.AspNetCore.SignalR;
using LightScience.Hubs;

namespace LightScience.Controllers
{
    public class LuxController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IHubContext<DataHub> _hubContext;

        public LuxController(AppDbContext context, IHubContext<DataHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }

        [HttpPost("ldr")]
        [HttpGet("ldr")]
        public async Task <IActionResult> ReceiveLdrValue([FromQuery] List <int> values)
        {
            if (values == null || values.Count == 0)
            {
                return BadRequest("No values provided");
            }
            var luxs = new List<Lux>(); 
            foreach (var value in values)
            {
                var lux = new Lux
                {
                    QuantidadeLux = value,
                    DataLeitura = DateTime.Now,
                };
                _context.Luxs.Add(lux);
                luxs.Add(lux);
                await _hubContext.Clients.All.SendAsync("ReceiveData", lux);
            }
            await _context.SaveChangesAsync();
            return Ok(luxs);
        }

    }
}
