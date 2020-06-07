using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlyCreator.DataLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlyCreator.Controllers
{
    [Route("api/flyClassifications")]
    [ApiController]
    public class FlyClassificationsController : ControllerBase
    {
        private readonly FlyDbContext _context;

        public FlyClassificationsController(FlyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFlyClassifications()
        {
            return Ok(await _context.FlyClassifications.ToListAsync());
        }
    }
}