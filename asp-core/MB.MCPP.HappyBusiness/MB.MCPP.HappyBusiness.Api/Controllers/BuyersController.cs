using AutoMapper;
using MB.MCPP.HappyBusiness.Dtos.Buyers;
using MB.MCPP.HappyBusiness.Entities;
using MB.MCPP.HappyBusiness.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MB.MCPP.HappyBusiness.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BuyersController : ControllerBase
    {
        #region Data and Constructors

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public BuyersController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #endregion

        #region Services

        [HttpGet]
        public async Task<List<BuyerListDto>> GetBuyersList()
        {
            var buyers = await _context
                            .Buyers
                            .ToListAsync();

            var buyerDtos = _mapper.Map<List<BuyerListDto>>(buyers);

            return buyerDtos;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BuyerDetailsDto>> GetBuyerDetailsByIdAsync(int id)
        {
            var buyer = await _context
                            .Buyers
                            .FindAsync(id);

            if(buyer == null)
            {
                return NotFound();
            }

            var buyerDto = _mapper.Map<BuyerDetailsDto>(buyer);

            return buyerDto;
        }

        [HttpPost]
        public async Task<int> CreateBuyerAsync([FromBody] BuyerDto buyerDto)
        {
            var buyer = _mapper.Map<Buyer>(buyerDto);

            await _context.AddAsync(buyer);
            await _context.SaveChangesAsync();

            return buyer.Id;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> EditBuyer(int id, [FromBody] BuyerDto buyerDto)
        {
            if(id != buyerDto.Id)
            {
                return BadRequest();
            }

            var buyer = _mapper.Map<Buyer>(buyerDto);

            try
            {
                _context.Update(buyer);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new DbUpdateException($"Couldn't update Buyer ID=[{id}]", ex);
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var buyer = await _context.Buyers.FindAsync(id);

            if(buyer == null)
            {
                return NotFound();
            }

            _context.Remove(buyer);
            await _context.SaveChangesAsync();

            return Ok();
        }

        #endregion

        #region Private Methods

        #endregion
    }
}
