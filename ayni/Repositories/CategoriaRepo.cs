using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ayni.Models;

namespace ayni.Repositories
{
    public class CategoriaRepo
    {
        ProyectoAyniEntities Db = new ProyectoAyniEntities();

        internal List<Categoria> List()
        {
            return Db.Categoria.ToList();
        }



        internal Categoria GetById(int? id)
        {
            return Db.Categoria.Where(x => x.idCategoria == id).FirstOrDefault();
        }
    }
}