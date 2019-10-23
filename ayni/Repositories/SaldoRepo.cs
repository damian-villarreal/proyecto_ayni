using ayni.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ayni.Repositories
{
    public class SaldoRepo
    {
        ProyectoAyniEntities Db = new ProyectoAyniEntities();

        UsuarioRepo usuarioRepo = new UsuarioRepo();

        public Saldo ObtenerSaldoUsuario(int? idUsuario)
        {
            Saldo s = Db.Saldo.Where(x => x.IdUsuario == idUsuario).FirstOrDefault();
            return s;
        }
   
        public void ActualizarSaldo(int? idUsuario, int? saldo) {
            Saldo saldoActualizar = Db.Saldo.Where(x => x.IdUsuario == idUsuario).FirstOrDefault();
            saldoActualizar.Cantidad = saldo;
            Db.SaveChanges();
        }

        public void CrearSaldo(int? idUsuario, int saldo) {
            Saldo s = new Saldo();
            s.IdUsuario = idUsuario.Value;
            s.Cantidad = saldo;
            Db.Saldo.Add(s);
            Db.SaveChanges();
        }
    }
}