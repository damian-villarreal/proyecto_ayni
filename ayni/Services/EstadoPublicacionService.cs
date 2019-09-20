using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ayni.Repositories;
using ayni.Models;

namespace ayni.Services
{
    public class EstadoPublicacionService
    {
        EstadoPublicacionRepo estadoPublicacionRepo = new EstadoPublicacionRepo();

        public EstadoPublicacion ObtenerPorId(int id) {
            return estadoPublicacionRepo.GetByid(id);
        }

    }
}