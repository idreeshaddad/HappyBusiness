using AutoMapper;
using MB.MCPP.HappyBusiness.Dtos.Drugs;
using MB.MCPP.HappyBusiness.Entities;
using MB.MCPP.HappyBusiness.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MB.MCPP.HappyBusiness.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DrugsController : ControllerBase
    {
        #region Data and Constructor

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public DrugsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #endregion

        #region Services

        [HttpGet]
        public async Task<List<DrugListDto>> GetDrugList()
        {
            var drugs = await _context
                                   .Drugs
                                   .Include(d => d.Classification)
                                   .ToListAsync();

            var drugDtos = _mapper.Map<List<DrugListDto>>(drugs);

            return drugDtos;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DrugDetailsDto>> GetDrugById(int id)
        {
            var drug = await _context
                                .Drugs
                                .Include(d => d.Classification)
                                .SingleOrDefaultAsync(d => d.Id == id);

            if(drug == null)
            {
                return NotFound();
            }

            var drugdetailsDto = _mapper.Map<DrugDetailsDto>(drug);

            return drugdetailsDto;
        }

        [HttpPost]
        public async Task<int> CreateDrug([FromBody] DrugDto drugDto)
        {
            var drug = _mapper.Map<Drug>(drugDto);

            await _context.AddAsync(drug);
            await _context.SaveChangesAsync();

            return drug.Id;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> EditDrug(int id, [FromBody] DrugDto drugDto)
        {
            if(id != drugDto.Id)
            {
                return BadRequest();
            }

            var drug = _mapper.Map<Drug>(drugDto);

            try
            {
                _context.Update(drug);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new DbUpdateException($"Couldn't update Drug with ID=[{id}]", ex);
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDrugById(int id)
        {
            var drug = await _context.Drugs.FindAsync(id);

            if (drug == null)
            {
                return NotFound();
            }

            _context.Remove(drug);
            await _context.SaveChangesAsync();

            return Ok();
        }

        #endregion

        #region Private Methods

        #endregion
    }
}
