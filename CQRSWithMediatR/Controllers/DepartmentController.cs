using CQRSWithMediatR.DTOs.DepartmentDTOs;
using CQRSWithMediatR.Features.Department.Commands.Models;
using CQRSWithMediatR.Features.Department.Queries.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRSWithMediatR.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DepartmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public ActionResult<DepartmentReadDTO> GetDepartment(int id)=>
             Ok(_mediator.Send(new GetDepartmentQuery() { Id=id}));

        [HttpGet]
        public ActionResult<IQueryable<DepartmentReadDTO>> ListDepartments()=> 
            Ok(_mediator.Send(new ListDepartmentQuery()));

        [HttpGet]
        public ActionResult<IQueryable<DepartmentReadDTO>> FindDepartmentsByName(string name) =>
            Ok(_mediator.Send(new FindDepartmentByNameQuery() { Name = name}));
        
        [HttpPost]
        public ActionResult<DepartmentCreateDTO> CreateDepartment(DepartmentCreateDTO departmentCreateDTO)
        {
            if (departmentCreateDTO is null)
                return BadRequest();

            var command = new CreateDepartmentCommand { Name = departmentCreateDTO.Name, Code = departmentCreateDTO.Code };
            var department = _mediator.Send(command);
            return Ok(department);
        }

        [HttpPut]
        public ActionResult<DepartmentReadDTO> UpdateDepartment(int id, DepartmentUpdateDTO departmentUpdateDTO)
        {
            if (departmentUpdateDTO is null)
                return BadRequest();
            var command = new UpdateDepartmnetCommand
            {Id = id, Name = departmentUpdateDTO.Name, Code = departmentUpdateDTO.Code };

            var department = _mediator.Send(command);
            return Ok(department);
        }

        [HttpDelete]    
     
        [HttpDelete]
        public IActionResult DeleteDepartment(int id)
        {
            var command = new DeleteDepartmentCommand { Id = id };
            var deleteResult = _mediator.Send(command);

            if (deleteResult.IsCompletedSuccessfully)
                return Ok("Delete Successfully");

            return BadRequest(new { Message = "Delete Failed", Errors = deleteResult.Exception?.Message });
        }


    }
}
