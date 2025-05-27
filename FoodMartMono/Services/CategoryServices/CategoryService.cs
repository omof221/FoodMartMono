using AutoMapper;
using FoodMartMono.Dtos.CategoryDtos;
using FoodMartMono.Entities;
using FoodMartMono.Settings;
using MongoDB.Driver;
using System.Reflection.Metadata.Ecma335;

namespace FoodMartMono.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    { private readonly IMongoCollection<Category> _categoryCollection;  
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper,IDatabaseSettings _databaseSettings)
        { var client= new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            var value = _mapper.Map<Category>(createCategoryDto);
            await _categoryCollection.InsertOneAsync(value);    
        }

        public async Task DeleteCategoryAsync(string id)
        {
            await _categoryCollection.DeleteOneAsync(x => x.CategoryId==id);
        }

        public async Task<List<ResultCategoryDto>> GetCategoryAsync()
        {
            var values = await _categoryCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultCategoryDto>>(values);
        }

        public async Task<GetCategorybyIdDto> GetCategoryByIdAsync(string id)
        {
            var value = await _categoryCollection.Find(x => x.CategoryId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetCategorybyIdDto>(value);
        }

        public Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
           var value = _mapper.Map<Category>(updateCategoryDto);
            return _categoryCollection.FindOneAndReplaceAsync(x => x.CategoryId == updateCategoryDto.CategoryId, value);
        }
    }
}
