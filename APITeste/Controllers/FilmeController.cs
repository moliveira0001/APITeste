using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Service;

namespace APITeste.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmeController : BaseController<Filme, FilmeValidator>
    {
        public FilmeController(IConfiguration configuration_) : base(configuration_)
        {
            _service = new FilmeDAL<Filme>(configuration_);
            base._service = this._service;
        }

    }
}