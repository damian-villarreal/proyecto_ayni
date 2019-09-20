using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ayni.Repositories;
using ayni.Models;

namespace ayni.Services
{
    public class TipoPublicacionService
    {
        TipoPublicacionRepo tipoPublicacionRepo = new TipoPublicacionRepo();

        public List<TipoPublicacion> Listar() {
            return tipoPublicacionRepo.List();
        }

        public TipoPublicacion ObtenerPorId(int? id) {
            return tipoPublicacionRepo.GetById(id);
        }
    }

}