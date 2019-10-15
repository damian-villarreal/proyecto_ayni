using ayni.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ayni.Repositories
{
    public class UsuarioRepo
    {
        public ProyectoAyniEntities Db = new ProyectoAyniEntities();

        internal Usuario FindUserByAddress(string Address) {
            return Db.Usuario.Where(x => x.Address == Address).FirstOrDefault();
        }

        internal Usuario FindUserById(int id)
        {
            return Db.Usuario.Where(x => x.idUsuario == id).FirstOrDefault();
        }

    }
}