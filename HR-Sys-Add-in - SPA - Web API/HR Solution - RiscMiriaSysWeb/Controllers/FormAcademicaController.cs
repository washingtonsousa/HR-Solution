using System;
using RiscServicesHRSharepointAddIn.Repositories;
using RiscServicesHRSharepointAddIn.Models;
using RiscServicesHRSharepointAddIn.Filters;
using RiscServicesHRSharepointAddIn.Helpers;
using RiscServicesHRSharepointAddIn.Strategy.Errors;
using RiscServicesHRSharepointAddIn.Controllers.TemplateControllers;
using System.Collections.Generic;
using System.Web.Http;
using System.Linq;
using System.Net.Http;
using System.Net;

namespace RiscServicesHRSharepointAddIn.Controllers
{

    public class FormAcademicaController : BasicApiAppController
    {

        private FormAcademicaRepository formAcademicaRepo;
        private JsonResultObjHelper JsonResultObjHelper;

        public FormAcademicaController()
        {
        
            formAcademicaRepo = new FormAcademicaRepository();
            JsonResultObjHelper = new JsonResultObjHelper();
        } // Fim método



    [Authorize(Roles = "Administrador")]
    [HttpGet]
    [HttpPost]
    public IHttpActionResult Get()
    {

      IList<FormAcademica> FormAcademicas = formAcademicaRepo.GetFormAcademicas();


      return Ok(FormAcademicas);
    }

    [Authorize(Roles = "Administrador, Funcionario")]
    [HttpGet]
    [HttpOptions]
    public IHttpActionResult GetSingle()
    {
      this.SetCurrentLoggedUserHandler();
      IList<FormAcademica> FormAcademicas = formAcademicaRepo.GetFormAcademicas().Where(c => c.UsuarioId == Usuario_Id).ToList();

      if (FormAcademicas.FirstOrDefault() == null)
      {
        return NotFound();
      }

      return Ok(FormAcademicas);

    }



    [Authorize(Roles = "Administrador, Funcionario")]
    [HttpOptions]
        [HttpPost]
        public HttpResponseMessage PostSingle(FormAcademica FormAcademica)
        {
      SetCurrentLoggedUserHandler();
            FormAcademica.UsuarioId =   Usuario_Id;
            formAcademicaRepo.InsertFormAcademica(FormAcademica);
            formAcademicaRepo.Save();

            return Request.CreateResponse(HttpStatusCode.OK , FormAcademica);
        }

    [Authorize(Roles = "Administrador, Funcionario")]
    [HttpOptions]
        [HttpPut]
        public HttpResponseMessage PutSingle(FormAcademica FormAcademica)
        {
      SetCurrentLoggedUserHandler();
            FormAcademica FormAcademicaFromDb = formAcademicaRepo.FindFormAcademicaByBothIds(FormAcademica.Id, Usuario_Id);
            if (FormAcademicaFromDb != null)
            {
                FormAcademicaFromDb.UsuarioId = Usuario_Id;
                FormAcademicaFromDb.Instituicao = FormAcademica.Instituicao;
                FormAcademicaFromDb.Situacao = FormAcademica.Situacao;
                FormAcademicaFromDb.TipoCurso = FormAcademica.TipoCurso;
                FormAcademicaFromDb.Curso = FormAcademica.Curso;
                FormAcademica.Atualizado_em = DateTime.Now;
                formAcademicaRepo.UpdateFormAcademica(FormAcademicaFromDb);
                formAcademicaRepo.Save();

                return Request.CreateResponse(HttpStatusCode.OK , FormAcademica);

            }

            return Request.CreateResponse(HttpStatusCode.BadRequest , new ErrorHelper().getError(new DatabaseNullResultError()));

          
        }


    [Authorize(Roles = "Administrador, Funcionario")]
    [HttpOptions]
        [HttpDelete]
        public HttpResponseMessage DeleteSingle(int Id)
        {

      this.SetCurrentLoggedUserHandler();
            FormAcademica FormAcademicaFromDb = formAcademicaRepo.FindFormAcademicaByBothIds(Id,   Usuario_Id);

            if (FormAcademicaFromDb != null)
            {
                formAcademicaRepo.DeleteFormAcademica(FormAcademicaFromDb);
                formAcademicaRepo.Save();

                return Request.CreateResponse(HttpStatusCode.OK , JsonResultObjHelper.getArquivoJsonResultSuccessObj());
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest , new ErrorHelper().getError(new DatabaseNullResultError()));


        }

    [Authorize(Roles = "Administrador")]
    [HttpOptions]
        [HttpPost]
        public HttpResponseMessage Post(FormAcademica FormAcademica)
        {


            formAcademicaRepo.InsertFormAcademica(FormAcademica);
            formAcademicaRepo.Save();

            return Request.CreateResponse(HttpStatusCode.OK , FormAcademica);
        }


    [Authorize(Roles = "Administrador")]
    [HttpOptions]
        [HttpPut]
        public HttpResponseMessage Put(FormAcademica FormAcademica)
        {

            FormAcademica FormAcademicaFromDb = formAcademicaRepo.FindFormAcademicaByBothIds(FormAcademica.Id, FormAcademica.UsuarioId);

            if (FormAcademicaFromDb != null)
            {
        FormAcademicaFromDb.Curso = FormAcademica.Curso;
        FormAcademicaFromDb.Instituicao = FormAcademica.Instituicao;
        FormAcademicaFromDb.Situacao = FormAcademica.Situacao;
        FormAcademicaFromDb.TipoCurso = FormAcademica.TipoCurso;

                formAcademicaRepo.UpdateFormAcademica(FormAcademicaFromDb);
                formAcademicaRepo.Save();

                return Request.CreateResponse(HttpStatusCode.OK, FormAcademica);
               

            }

            return Request.CreateResponse(HttpStatusCode.BadRequest , new ErrorHelper().getError(new DatabaseNullResultError()));
        }


    [Authorize(Roles = "Administrador")]
    [HttpDelete]
        [HttpOptions]
        public HttpResponseMessage Delete(int Id)
        {

            FormAcademica FormAcademicaFromDb = formAcademicaRepo.FindFormAcademica(Id);

            if (FormAcademicaFromDb != null)
            {
                formAcademicaRepo.DeleteFormAcademica(FormAcademicaFromDb);
                formAcademicaRepo.Save();

                return Request.CreateResponse(HttpStatusCode.OK , JsonResultObjHelper.getArquivoJsonResultSuccessObj());
                

            }

            return Request.CreateResponse(HttpStatusCode.BadRequest , new ErrorHelper().getError(new DatabaseNullResultError()));

        } // Fim método



    } // Classe
} // Namespace
