﻿using Microsoft.AspNetCore.Mvc;


namespace TAI_Projekt.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "It's working - USERS";
        }
    }
}