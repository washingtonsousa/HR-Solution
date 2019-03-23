using Microsoft.SharePoint.Client;
using Microsoft.SharePoint.Client.UserProfiles;
using System;
using System.Collections.Generic;
using RiscServicesHRSharepointAddIn.Models;
using RiscServicesHRSharepointAddIn.Repositories;
using RiscServicesHRSharepointAddIn.Helpers;
using RiscServicesHRSharepointAddIn.Controllers.TemplateControllers;
using System.Web.Http;
using System.Linq;

namespace RiscServicesHRSharepointAddIn.Controllers
{
  /// <summary>
  /// Controller que contém métodos Helpers que auxiliam em processos Ajax do sistema
  /// que buscam informações do Sahrepoint no contexto do site Sharepoint do Add-in instalado
  /// </summary>

  [Authorize(Roles = "Administrador")]
  public class SPUsersController : BasicApiAppController
    {

        private UsuariosRepository usuarioRepo;
        public SPUsersController()
        { 
      usuarioRepo = new UsuariosRepository();
 
      this.spAuthHelper = new BasicAuthHelper();
         }

        [HttpOptions]
        [HttpGet]
        public IHttpActionResult Get()
        {
      ClientContext clientContext = TokenHelper.GetClientContextWithAccessToken(this.contextAppUrl, this.spAuthHelper.GetSPAppToken());
      SPUserRepository spUserRepository = new SPUserRepository(clientContext);
      return Ok(spUserRepository.GetSPUsers());

        } 
    }
}
