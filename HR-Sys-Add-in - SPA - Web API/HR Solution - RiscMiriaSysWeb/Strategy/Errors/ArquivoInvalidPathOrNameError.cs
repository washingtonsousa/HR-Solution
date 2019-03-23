﻿using RiscServicesHRSharepointAddIn.Models;

namespace RiscServicesHRSharepointAddIn.Strategy.Errors
{
  public class ArquivoInvalidPathOrNameError : IError
    {
        public override Error getError()
        {
            Error error = new Error();

            error.code = 13;

            error.message = "Arquivo já existe ou possue nomenclatura inválida";

            return error;

        }
    }
}