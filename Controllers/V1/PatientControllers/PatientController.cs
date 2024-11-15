using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assesment_Alejandro_Castrillon_Gomez_bernslee.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Assesment_Alejandro_Castrillon_Gomez_bernslee.Controllers.V1.PatientControllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Tags("Patient")]

    public class PatientController : ControllerBase
    {

        protected readonly IPatientInterface _patientInterface;

        // Constructor para inyectar la dependencia
        public PatientController(IPatientInterface patientInterface)
        {
            _patientInterface = patientInterface;
        }
    }
}