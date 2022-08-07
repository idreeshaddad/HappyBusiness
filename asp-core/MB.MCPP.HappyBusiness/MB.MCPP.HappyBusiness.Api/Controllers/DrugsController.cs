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
                                   .ToListAsync();

            var drugDtos = _mapper.Map<List<DrugListDto>>(drugs);

            return drugDtos;
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        #endregion

        #region Private Methods

        #endregion
    }
}
