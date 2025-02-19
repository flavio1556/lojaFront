using Lojaback.Domain.Interfaces.Entities;
using Lojaback.Domain.Interfaces.Services;
using Lojaback.Domain.Interfaces.UseCases;
using LojaBack.Application.Interfaces.Dto;
using LojaBack.Application.Interfaces.Mapper;
using Microsoft.AspNetCore.Mvc;

namespace LojaBack.WebUI.Controllers.BaseController
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseCrudController<TDto, TModel> : Controller
        where TModel : class, IModel
        where TDto : class, IDto
    {
        private readonly IServiceBase<TModel> _service;
        private readonly IMapperService _mapperService;

        public BaseCrudController(IServiceBase<TModel> service, IMapperService mapperService)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _mapperService = mapperService ?? throw new ArgumentNullException(nameof(mapperService));
        }
        [HttpPost]
        public async Task<ActionResult<TDto>> CreateAsync([FromBody] TDto dto)
        {
            var request = _mapperService.MapToModel<TDto, TModel>(dto);
            var result = await _service.AddAsync(request);
            return await GetByIdAsync(result.Id);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<TDto>> UpdateAsync(Guid id, [FromBody] TDto dto)
        {
            var request = _mapperService.MapToModel<TDto, TModel>(dto);
            var result = await _service.UpdateAsync(request);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(long id)
        {
            var result = await _service.DeleteAsync(id);
            return result ? NoContent() : NotFound();
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<TDto>> GetByIdAsync(long id)
        {
            var model = await _service.GetByIdAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            var response = _mapperService.MapToDto<TModel, TDto>(model);
            return Ok(response);
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<TDto>>> GetAllAsync()
        {
            var models = await _service.GetAllAsync();
            var responses = models.Select(model => _mapperService.MapToDto<TModel, TDto>(model));
            return Ok(responses);
        }


    }
}
