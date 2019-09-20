using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ayni.Repositories;
using ayni.Models;

namespace ayni.Services
{
    public class CategoriaService
    {
        CategoriaRepo categoriaRepo = new CategoriaRepo();

        public List<Categoria> Listar() {
            return categoriaRepo.List();
        }

        public Categoria ObtenerPorId(int? id) {
            return categoriaRepo.GetById(id);
        }

    }
}