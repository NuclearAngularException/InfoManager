using AutoMapper;
using RestAPI.Controllers.RestAPI.Controllers;
using RestAPI.Models.DTOs;
using RestAPI.Models.Entity;
using RestAPI.Repository.IRepository;

namespace RestAPI.Controllers
{
    public class ProyectoController : BaseController<ProyectoEntity, ProyectoDTO,CreateProyectoDTO>
    {
        public ProyectoController(IProyectoRepository proyectoRepository,
            IMapper mapper, ILogger<ProyectoController> logger)
            : base(proyectoRepository, mapper, logger)
        {

        }
    }
}
