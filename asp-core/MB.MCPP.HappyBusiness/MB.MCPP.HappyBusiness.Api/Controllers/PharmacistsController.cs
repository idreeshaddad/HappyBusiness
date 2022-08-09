using AutoMapper;
using MB.MCPP.HappyBusiness.Dtos.Pharmacists;
using MB.MCPP.HappyBusiness.Entities;
using MB.MCPP.HappyBusiness.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MB.MCPP.HappyBusiness.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PharmacistsController : ControllerBase
    {
        #region Data And Constructors

        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        public PharmacistsController(ApplicationDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        #endregion

        #region Services

        [HttpGet]
        public async Task<List<PharmacistListDto>> GetPharmacistsList()
        {
            var pharmacists = await _context
                                    .Pharmacists
                                    .ToListAsync();

            var pharmacistDtos = _mapper.Map<List<PharmacistListDto>>(pharmacists);
            return pharmacistDtos;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PharmacistDetailsDto>> GetPharmacistById(int id)
        {
            var pharmacist = await _context.Pharmacists.FindAsync(id);

            if(pharmacist == null)
            {
                return NotFound();
            }

            var pharmacistDto = _mapper.Map<PharmacistDetailsDto>(pharmacist);

            return pharmacistDto;
        }

        [HttpPost]
        public async Task<int> CreatePharmacist([FromBody] PharmacistDto pharmacistDto)
        {
            var pharmacist = _mapper.Map<Pharmacist>(pharmacistDto);

            _context.Add(pharmacist);
            await _context.SaveChangesAsync();

            return pharmacist.Id;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> EditPharmacist(int id, [FromBody] PharmacistDto pharmacistDto)
        {
            if(id != pharmacistDto.Id)
            {
                return BadRequest();
            }

            var pharmacist = _mapper.Map<Pharmacist>(pharmacistDto);

            try
            {
                _context.Update(pharmacist);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            { 
                throw new DbUpdateException($"Couldn't update Pharmacist Id=[{id}]", ex);
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePharmacistById(int id)
        {
            var pharmacist = await _context.Pharmacists.FindAsync(id);

            if (pharmacist == null)
            {
                return NotFound();
            }

            _context.Remove(pharmacist);
            await _context.SaveChangesAsync();

            return Ok();
        }
        #endregion    

        #region Private Methods

        #endregion
    }
}
