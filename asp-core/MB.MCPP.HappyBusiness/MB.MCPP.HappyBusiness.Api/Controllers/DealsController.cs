using AutoMapper;
using MB.MCPP.HappyBusiness.Dtos.Deals;
using MB.MCPP.HappyBusiness.Entities;
using MB.MCPP.HappyBusiness.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MB.MCPP.HappyBusiness.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DealsController : ControllerBase
    {
        #region Data and Const

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public DealsController(ApplicationDbContext context, IMapper mapper)
        {
           _context = context;
           _mapper = mapper;
        }

        #endregion

        #region Services

        [HttpGet]
        public async Task<ActionResult<List<DealListDto>>> GetDealsList()
        {
            var deals = await _context
                                    .Deals
                                    .Include(d => d.Buyer)
                                    .Include(d => d.Pharmacist)
                                    .ToListAsync();

            var dealDtos = _mapper.Map<List<DealListDto>>(deals);

            return dealDtos;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DealDetailsDto>> GetDealById(int id)
        {
            var deal = await _context
                                .Deals
                                .Include(d => d.Buyer)
                                .Include(d => d.Pharmacist)
                                .SingleOrDefaultAsync(d => d.Id == id);

            if(deal == null)
            {
                return NotFound();
            }

            var dealDto = _mapper.Map<DealDetailsDto>(deal);

            return dealDto;
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateDeal([FromBody] DealDto dealDto)
        {
            var deal = _mapper.Map<Deal>(dealDto);

            deal.TransactionCode = Guid.NewGuid();
            deal.DealTime = DateTime.Now;
            deal.LastModifiedTime = deal.DealTime;

            await _context.AddAsync(deal);
            await _context.SaveChangesAsync();

            return deal.Id;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> EditDeal(int id, [FromBody] DealDto dealDto)
        {
            if(id != dealDto.Id)
            {
                return BadRequest();
            }

            var deal = await _context.Deals.FindAsync(id);
            _mapper.Map(dealDto, deal);
            deal.LastModifiedTime = DateTime.Now;

            // TODO
            // CalculateTotalPrice(deal)

            try
            {
                _context.Update(deal);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw new DbUpdateException($"Couldn't update deal ID=[{id}]", ex);
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDealById(int id)
        {
            var deal = await _context
                                .Deals
                                .FindAsync(id);

            if(deal == null)
            {
                return NotFound();
            }

            _context.Remove(deal);
            await _context.SaveChangesAsync();

            return Ok();
        }

        #endregion

        #region Private Methods

        #endregion
    }
}
