// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using DreamWeddsManager.Application.Interfaces.Services.Identity;

namespace SmartAdmin.WebUI.EndPoints
{
    [ApiController]
    [Route("api/identity/token")]
    public class IdentityEndpoint : ControllerBase
    {
        private readonly ITokenService _identityService;

        public IdentityEndpoint(
            ITokenService identityService
            )
        {
            _identityService = identityService;
        }
        /// <summary>
        /// Get Token (Email, Password)
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Status 200 OK</returns>
        //[HttpPost]
        //public async Task<ActionResult> Login([FromBody]TokenRequestDto model)
        //{
        //    var response = await _identityService.LoginAsync(model);
        //    return Ok(response);
        //}
        ///// <summary>
        ///// Refresh Token
        ///// </summary>
        ///// <param name="model"></param>
        ///// <returns>Status 200 OK</returns>
        //[HttpPost("refresh")]
        //public async Task<ActionResult> Refresh([FromBody] RefreshTokenRequestDto model)
        //{
        //    var response = await _identityService.RefreshTokenAsync(model);
        //    return Ok(response);
        //}

    }
}
