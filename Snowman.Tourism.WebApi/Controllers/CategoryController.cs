using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Snowman.Tourism.Domain;
using Snowman.Tourism.Repository;
using Snowman.Tourism.WebApi.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Snowman.Tourism.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ITourismRepository _repo;
        private readonly IMapper _mapper;

        public CategoryController(ITourismRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            try
            {
                var categories = await _repo.GetAllCategoriesAsync();
                var results = _mapper.Map<IEnumerable<CategoryDto>>(categories);

                return Ok(results);

            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Internal error 500");
            }
        }

        [HttpGet("{categoryId}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(int categoryId)
        {
            try
            {
                var category = await _repo.GetCategoryAsyncById(categoryId);
                var results = _mapper.Map<CategoryDto>(category);
                return Ok(results);

            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Internal error 500");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(CategoryDto model)
        {
            try
            {
                var category = _mapper.Map<Category>(model);
                _repo.Add(category);

                if (await _repo.SaveChangesAsync())
                {
                    return Created("/api/category/{model.Id}", _mapper.Map<CategoryDto>(category));
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Internal error 500");
            }

            return BadRequest();
        }
    }
}
