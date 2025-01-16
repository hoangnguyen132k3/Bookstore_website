using BookStore.BLL.Services.ViewModels;
using BookStore.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class InformationTypesController : ControllerBase
    {
        private readonly IInformationTypeService _informationTypeService;

        public InformationTypesController(IInformationTypeService informationTypeService)
        {
            _informationTypeService = informationTypeService;
        }

        [HttpGet("get-all-informationtypes")]
        public async Task<ActionResult<IEnumerable<InformationTypeVm>>> GetInformationTypes()
        {
            var result = await _informationTypeService.GetAllInformationTypeAsync();

            return Ok(result); 
        }

        [HttpGet("get-informationtype-by-id/{id}")]
        public async Task<ActionResult<InformationTypeVm>> GetInformationType(int id)
        {
            var result = await _informationTypeService.GetByInformationTypeIdAsync(id);

            if (result == null)
            {
                return NotFound(new { Message = $"Thông tin với ID {id} không tìm thấy." });
            }

            return Ok(result); 
        }

        [HttpPost("add-new-informationtype")]
        public async Task<ActionResult<InformationTypeVm>> PostInformationType(InputInformationTypeVm informationTypeVm)
        {
            var result = await _informationTypeService.AddInformationTypeAsync(informationTypeVm);

            if (result == null)
            {
                return BadRequest(new { Message = "Không tạo được thông tin." });
            }

            return CreatedAtAction(nameof(GetInformationType), new { id = result.InformationTypeId }, result);
        }

        [HttpPut("update-informationType/{id}")]
        public async Task<IActionResult> PutInformationType(int id, InputInformationTypeVm informationTypeVm)
        {
            var result = await _informationTypeService.UpdateInformationTypeAsync(id, informationTypeVm);
            if (result == null)
            {
                return NotFound(new { Message = $"Thông tin với ID {id} không tìm thấy." });
            }

            return Ok(result);
        }

        [HttpDelete("delete-informationType-by-id/{id}")]
        public async Task<IActionResult> DeleteInformationType(int id)
        {
            var result = await _informationTypeService.DeleteInformationTypeAsync(id);
            if (result == null)
            {
                return NotFound(new { Message = $"Thông tin với ID  {id}  không tìm thấy." });
            }

            return NoContent();
        }
    }
}
