using AutoMapper;
using FoodMartMono.Dtos.DiscountsDto;
using FoodMartMono.Entities;
using FoodMartMono.Settings;
using MongoDB.Driver;

namespace FoodMartMono.Services.DiscountService
{
    public class DiscountService : IDiscountService
    {
        private readonly IMongoCollection<Discount> _discountcollection;
        private readonly IMapper _mapper;

        public DiscountService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _discountcollection = database.GetCollection<Discount>(_databaseSettings.DiscountCollectionName);
            _mapper = mapper;
        }

        public async Task CreateDiscountAsync(CreateDiscountDto createDiscountDto)
        {
           
            var value = _mapper.Map<Discount>(createDiscountDto);
            await _discountcollection.InsertOneAsync(value);
        }

        public async Task DeleteDiscountAsync(string discountId)
        {
            await _discountcollection.DeleteOneAsync(x => x.DiscountId == discountId);

        }

        public  async Task<GetDiscountByIdDto> GetDiscountByIdAsync(string discountId)
        {
            var value= _discountcollection.Find(x => x.DiscountId == discountId).FirstOrDefaultAsync();
            return _mapper.Map<GetDiscountByIdDto>(value);
        }

        public async Task<List<ResultDiscountDto>> GetResultDiscountAsync()
        {
            var values = await _discountcollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultDiscountDto>>(values);    

        }

        public async Task UpdateDiscountAsync(UpdateDiscountDto updateDiscountDto)
        {
           var value = _mapper.Map<Discount>(updateDiscountDto);
            await _discountcollection.FindOneAndReplaceAsync(x => x.DiscountId == updateDiscountDto.DiscountId, value); 
        }
    }
}
