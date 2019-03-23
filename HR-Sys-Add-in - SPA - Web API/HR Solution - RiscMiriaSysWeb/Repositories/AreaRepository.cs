﻿using System.Collections.Generic;
using System.Linq;
using RiscServicesHRSharepointAddIn.Factories;
using RiscServicesHRSharepointAddIn.Models;

namespace RiscServicesHRSharepointAddIn.Repositories
{
  public class AreaRepository : RepositoryTemplate
    {
        private AreaFactory areaFactory;

        public AreaRepository()
        {
            areaFactory = new AreaFactory();

        }

        public IList<Area> GetAreas()
        {
            return this.Context.Areas.OrderBy(a => a.Nome).ToList();

        }

        public Area FindArea(int Id)
        {
            return this.Context.Areas.Where(e => e.Id == Id).FirstOrDefault();

        }

        public void InsertArea(Area Area)
        {
           
            this.Context.Add(Area);
        }


        public void DeleteArea(Area Area)
        {
            this.Context.Areas.Remove(Area);

        }

        public void UpdateArea(Area AreaData)
        {
            AreaData.Atualizado_em = System.DateTime.Now;
            this.Context.Areas.Update(AreaData);

        }

        internal dynamic getTotalNumberCountRegisters()
        {
            return this.Context.Areas.Count();
        }
    }
}