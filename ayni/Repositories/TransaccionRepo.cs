using ayni.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ayni.Repositories
{
    public class TransaccionRepo
    {
        ProyectoAyniEntities Db = new ProyectoAyniEntities();

        public Boolean Crear(Transaccion t) {
            Db.Transaccion.Add(t);
            Db.SaveChanges();
            return true;
        }

        public List<Transaccion> BuscarPorIdUsuario(int? idUsuario) {
            return Db.Transaccion.Where(x => x.idUsuarioOfrece == idUsuario || x.idUsuarioRecibe == idUsuario
            ).ToList();
        }
    }
}