using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assesment_Alejandro_Castrillon_Gomez_bernslee.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Assesment_Alejandro_Castrillon_Gomez_bernslee.Controllers.V1.DoctorControllers
{
    [ApiController]
    [Route("api/[controller]")]
        [Tags("Doctor")]

    public class DoctorController : ControllerBase
    {
         protected readonly IDoctorInterface _doctorInterface;

        // Constructor para inyectar la dependencia
        public DoctorController(IDoctorInterface doctorInterface)
        {
            _doctorInterface = doctorInterface;
        }
    }
}