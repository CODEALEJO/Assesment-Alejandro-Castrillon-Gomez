using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assesment_Alejandro_Castrillon_Gomez_bernslee.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Assesment_Alejandro_Castrillon_Gomez_bernslee.Controllers.V1.AppointmentControllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Tags("Appointment")]
    public class AppointmentController : ControllerBase
    {
         protected readonly IAppointmentInterface _appointmentInterface;

        // Constructor para inyectar la dependencia
        public AppointmentController(IAppointmentInterface appointmentInterface)
        {
            _appointmentInterface = appointmentInterface;
        }
    }
}