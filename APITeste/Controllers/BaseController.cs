﻿using Domain;
using FluentValidation;
using Infrastructure.AcessoDados;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace APITeste.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<TEntity, TValidator> : ControllerBase where TEntity : BaseEntity
        where TValidator : AbstractValidator<TEntity>
    {

        private IConfiguration configuration_;
        protected IService<TEntity> _service;

        public BaseController(IConfiguration configuration_)
        {
            this.configuration_ = configuration_;
        }

        [HttpPost]
        public virtual TEntity Post([FromBody] TEntity entityBase)
        {
            try
            {

                Validate(entityBase, Activator.CreateInstance<TValidator>());

                entityBase = _service.Criar(entityBase);

                entityBase.BadRequest = false;

                return entityBase;
            }
            catch (Exception _objException)
            {
                entityBase.BadRequest = true;
                entityBase.MensagemExeption = _objException.Message;

                return entityBase;
            }
        }


        [HttpPut]
        public virtual TEntity Put([FromBody] TEntity entityBase)
        {
            try
            {

                entityBase = _service.Atualizar(entityBase);

                entityBase.BadRequest = false;

                return entityBase;
            }
            catch (Exception _objException)
            {
                entityBase.BadRequest = true;
                entityBase.MensagemExeption = _objException.Message;

                return entityBase;
            }
        }


      
        [HttpGet("{id}")]
        public virtual List<TEntity> Get(int? id)
        {
            List<TEntity> entityBase = new List<TEntity>();
            try
            {
                entityBase = _service.Listar(id);

                entityBase.Where(c=>c.BadRequest=false);

                return entityBase;
            }
            catch (Exception _objException)
            {
                entityBase.Where(c => c.BadRequest = true);
                entityBase.Where(c => c.BadRequest = true).FirstOrDefault().MensagemExeption= _objException.Message;

                return entityBase;
            }
        }

       
        [HttpGet]
        public virtual List<TEntity> Get()
        {
            List<TEntity> entityBase = new List<TEntity>();
            try
            {
                entityBase = _service.Listar(null);

                entityBase.Where(c => c.BadRequest = false);

                return entityBase;
            }
            catch (Exception _objException)
            {
                entityBase.Where(c => c.BadRequest = true);
                entityBase.Where(c => c.BadRequest = true).FirstOrDefault().MensagemExeption = _objException.Message;

                return entityBase;
            }
        }



        private void Validate(TEntity objBaseDTO_, AbstractValidator<TEntity> validator)
        {
            validator.ValidateAndThrow(objBaseDTO_);
        }
    }
}