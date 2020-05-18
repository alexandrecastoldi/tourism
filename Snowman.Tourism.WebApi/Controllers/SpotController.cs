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
    public class SpotController : ControllerBase
    {
        private readonly ITourismRepository _repo;
        private readonly IMapper _mapper;

        public SpotController(ITourismRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        #region GET

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            try
            {
                var spots = await _repo.GetAllSpotsAsync();
                var results = _mapper.Map<IEnumerable<SpotDto>>(spots);

                return Ok(results);

            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Internal error 500");
            }
        }

        [HttpGet("{spotId}")]
        public async Task<IActionResult> Get(int spotId)
        {
            try
            {
                var spots = await _repo.GetSpotAsyncById(spotId, true);
                var results = _mapper.Map<SpotDto>(spots);

                return Ok(results);

            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Internal error 500");
            }
        }

        [HttpGet("getByName/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            try
            {
                var spots = await _repo.GetAllSpotsAsyncByName(name, false);
                var results = _mapper.Map<IEnumerable<SpotDto>>(spots);

                return Ok(results);

            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Internal error 500");
            }
        }

        [HttpGet("getByUser/{userId}")]
        public async Task<IActionResult> GetByUser(int userId)
        {
            try
            {
                var spots = await _repo.GetSpotAsyncByUserRegistered(userId);
                var results = _mapper.Map<IEnumerable<SpotDto>>(spots);

                return Ok(results);

            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Internal error 500");
            }
        }
        #endregion

        [HttpPost]
        public async Task<IActionResult> Post(SpotDto model)
        {
            try
            {
                var spot = _mapper.Map<Spot>(model);
                _repo.Add(spot);

                if (await _repo.SaveChangesAsync())
                {
                    return Created("/api/spot/{model.Id}", _mapper.Map<SpotDto>(spot));
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