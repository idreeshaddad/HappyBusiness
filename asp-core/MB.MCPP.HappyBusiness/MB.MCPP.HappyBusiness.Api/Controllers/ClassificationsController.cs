using AutoMapper;
using MB.MCPP.HappyBusiness.Dtos.Classifications;
using MB.MCPP.HappyBusiness.Entities;
using MB.MCPP.HappyBusiness.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MB.MCPP.HappyBusiness.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClassificationsController : ControllerBase
    {
        #region Data and Constructors

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ClassificationsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #endregion

        #region Services

        [HttpGet]
        public async Task<List<ClassificationDto>> GetClassificationsAsync()
        {
            var classifications = await _context
                                        .Classifications
                                        .ToListAsync();

            var classificationDtos = _mapper.Map<List<ClassificationDto>>(classifications);

            return classificationDtos;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClassificationDto>> GetClassificationById(int id)
        {
            var classification = await _context.Classifications.FindAsync(id);

            if(classification == null)
            {
                return NotFound();
            }

            var classificationDto = _mapper.Map<ClassificationDto>(classification);

             return classificationDto;
        }

        [HttpPost]
        public async Task<int> CreateClassifiaction([FromBody] ClassificationDto classificationDto)
        {
            var classification = _mapper.Map<Classification>(classificationDto);

            _context.Add(classification);
            await _context.SaveChangesAsync();

            return classification.Id;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> EditClassification(int id, [FromBody] ClassificationDto classificationDto)
        {
            if(id != classificationDto.Id)
            {
                return BadRequest();
            }

            var classification = _mapper.Map<Classification>(classificationDto);

            _context.Update(classification);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var classification = await _context.Classifications.FindAsync(id);

            if(classification == null)
            {
                return NotFound();
            }

            _context.Remove(classification);
            await _context.SaveChangesAsync();

            return Ok();
        }

        #endregion

        #region Private Methods

        #endregion
    }
}
