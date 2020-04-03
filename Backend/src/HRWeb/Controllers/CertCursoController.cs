using System;
using Core.Data.Repositories;
using Core.Data.Models;
using HRWeb.Filters;
using HRWeb.Helpers;
using HRWeb.Strategy.Errors;
using HRWeb.Controllers.TemplateControllers;
using System.Web.Http;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;

namespace HRWeb.Controllers
{
 
    public class CertCursoController : BasicApiAppController
    {
     
        private CertCursoRepository certCurRepo;
        ;

        public CertCursoController()
        {
            
            certCurRepo = new CertCursoRepository();
              
    }


    [Authorize(Roles = "Administrador")]
    [HttpGet]
    [HttpPost]
    public IHttpActionResult Get()
    {

      IList<CertCurso> certCursos = certCurRepo.GetCertCursos();


      return Ok(certCursos);
    }

    [Authorize(Roles = "Administrador, Funcionario")]
    [HttpGet]
    [HttpOptions]
    public IHttpActionResult GetSingle()
    {
      this.SetCurrentLoggedUserHandler();
      IList<CertCurso> certCursos = certCurRepo.GetCertCursos().Where(c => c.UsuarioId == Usuario_Id).ToList();

      if (certCursos.FirstOrDefault() == null)
      {
        return NotFound();
      }

      return Ok(certCursos);

    }

    [Authorize(Roles = "Administrador,Funcionario")]
    [HttpOptions]
    [HttpPost]
    public IHttpActionResult PostSingle([FromBody]CertCurso CertCurso)
        {

      this.SetCurrentLoggedUserHandler();
      certCurRepo.InsertCertCurso(CertCurso);
            certCurRepo.Save();
            
            return Ok(CertCurso);
        }

    [Authorize(Roles = "Administrador,Funcionario")]
    [HttpOptions]
    [HttpPut]
    public HttpResponseMessage PutSingle([FromBody]CertCurso CertCurso)
        {

      this.SetCurrentLoggedUserHandler();
      CertCurso CertCursoFromDb = certCurRepo.FindCertCurso(CertCurso.Id);

            if (CertCursoFromDb != null)
             
            {
                CertCursoFromDb.Certificadora = CertCurso.Certificadora;
                CertCursoFromDb.Descricao = CertCurso.Descricao;
                CertCursoFromDb.Atualizado_em = DateTime.Now;
                CertCursoFromDb.Instituicao = CertCurso.Instituicao;
                CertCursoFromDb.Nome = CertCurso.Nome;
                CertCursoFromDb.Periodo = CertCurso.Periodo;
                certCurRepo.UpdateCertCurso(CertCursoFromDb);
                certCurRepo.Save();

                return Request.CreateResponse(HttpStatusCode.OK, CertCurso);

            }

            return Request.CreateResponse(HttpStatusCode.BadRequest , new ErrorHelper().getError(new DatabaseNullResultError()));
        }

    [Authorize(Roles = "Administrador,Funcionario")]
    [HttpOptions]
    [HttpDelete]
    public HttpResponseMessage DeleteSingle(int Id)
        {
      this.SetCurrentLoggedUserHandler();
      CertCurso CertCursoFromDb = certCurRepo.FindCertCurso(Id);

            if (CertCursoFromDb != null)
            {
                certCurRepo.DeleteCertCurso(CertCursoFromDb);

                certCurRepo.Save();

                return Request.CreateResponse(HttpStatusCode.OK, null);

            }

            return Request.CreateResponse(HttpStatusCode.BadRequest,  new ErrorHelper().getError(new DatabaseNullResultError()));

            
        }

    }
}
