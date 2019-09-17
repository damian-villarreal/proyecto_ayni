using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ayni.Repositories;
using ayni.Models;

namespace ayni.Services
{
    public class PublicacionService
    {
        PublicacionRepo publicacionRepo = new PublicacionRepo();

        internal List<Publicacion> BuscarHome(String s) {
            return publicacionRepo.BuscarHome(s);
        }

        internal List<Publicacion> ListarPedidos() {
            return publicacionRepo.ListarPedidos();
        }
    }
}