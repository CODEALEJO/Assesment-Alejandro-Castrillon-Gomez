using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assesment_Alejandro_Castrillon_Gomez_bernslee.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Assesment_Alejandro_Castrillon_Gomez_bernslee.Controllers.V1.HistoryDatingControllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Tags("HistoryDating")]

    public class HistoryDatingController : ControllerBase
    {
          protected readonly IHistoryDatingInterface _historyDatingInterface;

        // Constructor para inyectar la dependencia
        public HistoryDatingController(IHistoryDatingInterface historyDatingInterface)
        {
            _historyDatingInterface = historyDatingInterface;
        }
    }
}