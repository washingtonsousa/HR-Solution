﻿using System;
using System.Collections.Generic;

namespace Core.Application.Entities
{
  public class UserFromAuthEngine   {
        public int UsuarioFromDbId { get; set; }
        public string AccountName { get; set; }
        public string DisplayName { get; set; }
        public string PictureUrl { get; set; }
        public string UserUrl { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
        public IDictionary<string , string> personProperties {get; set;}

    }
}