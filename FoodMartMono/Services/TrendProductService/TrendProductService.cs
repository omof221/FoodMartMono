using AutoMapper;
using FoodMartMono.Dtos.TrendProductDto;
using FoodMartMono.Entities;
using FoodMartMono.Settings;
using MongoDB.Driver;

namespace FoodMartMono.Services.TrendProductService
{
    public class TrendProductService : ITrendProductService
    { private readonly IMongoCollection<TrendProduct> _trendProductCollection;
        private readonly IMapper _mapper;

        public TrendProductService(IMapper mapper,IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _trendProductCollection = database.GetCollection<TrendProduct>(_databaseSettings.TrendProductCollectionName);   
            _mapper = mapper;
        }

        public async Task CreateTrendProductAsync(CreateTrendProductDto createTrendProductDto)
        {
            var value = _mapper.Map<TrendProduct>(createTrendProductDto);
            await _trendProductCollection.InsertOneAsync(value);   
        }

        public async Task DeleteTrendProductAsync(string id)
        { await _trendProductCollection.DeleteOneAsync(x => x.TrendProductId == id);    

        }

        public async Task<GetTrendProductByIdDto> GetTrendProductByIdAsync(string id)
        {
          var value = await _trendProductCollection.Find(x => x.TrendProductId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetTrendProductByIdDto>(value);  
        }

        public async Task<List<ResultTrendProductDto>> GetTrendProductsAsync()
        {
            var values = await _trendProductCollection.Find(x => true).ToListAsync(); 
            return _mapper.Map<List<ResultTrendProductDto>>(values);
        }

        public  Task UpdateTrendProductAsync(UpdateTrendProductDto updateTrendProductDto)
        {
            var value = _mapper.Map<TrendProduct>(updateTrendProductDto);
            return _trendProductCollection.FindOneAndReplaceAsync(x => x.TrendProductId == updateTrendProductDto.TrendProductId, value);    
        }
    }
}
