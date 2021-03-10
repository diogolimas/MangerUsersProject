using Microsoft.AspNetCore.Mvc;
using System;
using Manager.API.ViewModels;
using System.Threading.Tasks;
using Manager.Core.Exceptions;
using Manager.Services.Interfaces;
using AutoMapper;
using Manager.Services.DTO;
using Manager.API.Utilities;



namespace Manager.API.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        
        [HttpPost]
        [Route("/api/v1/users/create")]
        //métodos de controllers são chamados de ACTIONS
        public async Task<IActionResult> Create([FromBody] CreateUserViewModel userViewModel)
        {
            try
            {
                // validação para api preciccsa ser rápida
                var userDTO = _mapper.Map<UserDTO>(userViewModel);
                
                var userCreated = _userService.Create(userDTO);

                return Ok(new ResultViewModel{
                    Message = "Usuário criado com sucesso!",
                    Success = true,
                    Data = userCreated
                });
            }
        
      catch (DomainException ex)
            {

                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            } 
   
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }
    }
}