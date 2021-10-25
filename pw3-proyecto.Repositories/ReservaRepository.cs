﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pw3_proyecto.Entities;
using pw3_proyecto.Repositories.Interfaces;

namespace pw3_proyecto.Repositories
{

    public class ReservaRepository : IReservaRepository
    {
    private _20212C_TPContext _dbContext;
 
        public ReservaRepository(_20212C_TPContext dbContext)
        {
            _dbContext = dbContext;
        }    

        public void Save(Reserva reservation)
        {
            _dbContext.Reservas.Add(reservation);
            _dbContext.SaveChanges();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}