using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Service;

namespace APITeste.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : BaseController<Cliente, ClienteValidator>
    {
        public ClienteController(IConfiguration configuration_) : base(configuration_)
        {
            _service = new ClienteDAL<Cliente>(configuration_);
            base._service = this._service;
        }

    }
}
