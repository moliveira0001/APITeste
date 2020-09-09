using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Service;

namespace APITeste.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocacoesController : BaseController<Locacoes, LocacoesValidator>
    {
        public LocacoesController(IConfiguration configuration_) : base(configuration_)
        {
            _service = new LocacoesDAL<Locacoes>(configuration_);
            base._service = this._service;
        }

    }
}