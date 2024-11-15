using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assesment_Alejandro_Castrillon_Gomez_bernslee.Interface;
using Microsoft.AspNetCore.Mvc;

namespace RepasoC_.Controllers.V1.UserController
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
         private readonly IUserInterface _userinterface;
            public UserController(IUserInterface userinterface)
        {
            _userinterface = userinterface;
        }
    }
}