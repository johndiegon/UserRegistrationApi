using Microsoft.AspNetCore.Mvc;
using Nest;
using UserRegistrationApi.Application.Contract.Request;
using UserRegistrationApi.Application.Contract.Response;
using UserRegistrationApi.Application.Interfaces;
using UserRegistrationApi.Atributes;
using Status = UserRegistrationApi.Application.Contract.Response.Status;

namespace UserRegistrationApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        ///     Action to create a user in database.
        /// </summary>
        /// <param name="user">Model to create a user.</param>
        /// <returns>Returns a user.</returns>
        /// <response code="200">Returned a user.</response>
        /// <response code="400">Returned if the model couldn't be parsed or saved</response>
        /// <response code="422">Returned when the validation failed</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ApiKey]
        [HttpPost]
        public async Task<ActionResult<CommandResponse>> Crete(UserRequest user)
        {
            try
            {
                var response = await _userService.CreateUser(user);
                if ( response.Data.Status == Status.Sucessed)
                {
                    return Ok(response);
                }
                else
                {
                    return UnprocessableEntity(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        ///     Action to update a user in database.
        /// </summary>
        /// <param name="user">Model to updated a user.</param>
        /// <returns>Returns a user.</returns>
        /// <response code="200">Returned a user.</response>
        /// <response code="400">Returned if the model couldn't be parsed or saved</response>
        /// <response code="422">Returned when the validation failed</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ApiKey]
        [HttpPut]
        public async Task<ActionResult<UserResponse>> Update(UserRequest user)
        {
            try
            {
                var response = await _userService.UpdateUser(user);
                if (response.Data.Status == Status.Sucessed)
                {
                    return Ok(response);
                }
                else
                {
                    return UnprocessableEntity(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        ///     Action to delete a user in database.
        /// </summary>
        /// <param name="document">Model to deleted a user.</param>
        /// <returns>Returns a user.</returns>
        /// <response code="200">Returned a user.</response>
        /// <response code="400">Returned if the model couldn't be parsed or saved</response>
        /// <response code="422">Returned when the validation failed</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ApiKey]
        [HttpDelete("{document}")]
        public async Task<ActionResult<UserResponse>> Delete([FromRoute] string document)
        {
            try
            {
                var response = await _userService.DeleteUser(document);
                if (response.Data.Status == Status.Sucessed)
                {
                    return Ok(response);
                }
                else
                {
                    return UnprocessableEntity(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        ///     Action to get a User in the database.
        /// </summary>
        /// <param name="document">Model to get a user.</param>
        /// <returns>Returns a user.</returns>
        /// <response code="200">Returned a user.</response>
        /// <response code="400">Returned if the model couldn't be parsed or saved</response>
        /// <response code="422">Returned when havent a user with document.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ApiKey]
        [HttpGet("{document}")]
        public async Task<ActionResult<UserResponse>> Get([FromRoute] string document)
        {
            try
            {
                var response = await _userService.GetUser(document);
                if (response.User == null)
                {
                    return NoContent();
                }
                else if(response.Data.Status == Status.Sucessed)
                {
                    return Ok(response);
                }
                else
                {
                    return UnprocessableEntity(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}