using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.DTO;
using PlatformService.Models;

namespace PlatformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformController : ControllerBase
    {
        private readonly IPlatformRepository _platformRepository;
        private readonly IMapper _mapper;
        public PlatformController(IPlatformRepository platformRepository, IMapper mapper)
        {
            _platformRepository = platformRepository;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlatformReadDto>>> GetPlatforms()
        {
            IEnumerable<Platform> platforms = await _platformRepository.GetAll();
            IEnumerable<PlatformReadDto> platformReadDtos = _mapper.Map<IEnumerable<PlatformReadDto>>(platforms);

            return Ok(platformReadDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PlatformReadDto>> GetPlatformById(int id)
        {
            Platform platform = await _platformRepository.Get(id);
            PlatformReadDto platformReadDto = _mapper.Map<PlatformReadDto>(platform);

            return platformReadDto is null
                ? Ok(platformReadDto)
                : NotFound();
        }
    }
}
