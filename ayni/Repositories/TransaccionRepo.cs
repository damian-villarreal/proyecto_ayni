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

        public Transaccion BuscarPorId(int? idTransaccion) {
            return Db.Transaccion.Where(x => x.idTransacion == idTransaccion).FirstOrDefault();
        }

        public void Modificar(Transaccion t) {
            Transaccion tr = BuscarPorId(t.idTransacion);
            tr.confirm_ofrece = t.confirm_ofrece;
            tr.confirm_recibe = t.confirm_recibe;
            tr.EstadoTransaccion = t.EstadoTransaccion;
            tr.idEstadoTransaccion = t.idEstadoTransaccion;
            tr.idPublicacion = t.idPublicacion;
            tr.idTransacion = t.idTransacion;
            tr.idUsuarioOfrece = t.idUsuarioOfrece;
            tr.idUsuarioRecibe = t.idUsuarioRecibe;
            tr.Publicacion = t.Publicacion;
            tr.Usuario = t.Usuario;

            Db.SaveChanges();
        }

        public Transaccion BuscarPorIdPublicacion(int? idPublicacion) {
            return Db.Transaccion.Where(x => x.idPublicacion == idPublicacion).FirstOrDefault();
        }

        public bool Calificar(Calificacion c) {
            Db.Calificacion.Add(c);
            Db.SaveChanges();
            return true;
        }

        public List<Transaccion> ObtenerTransaccionesFinalizadasPedido(int? idUsuarioCalificado)
        {
           return Db.Transaccion.Where(x => x.idUsuarioRecibe == idUsuarioCalificado && x.idEstadoTransaccion==3).ToList();
        }

        public List<Transaccion> ObtenerTransaccionesFinalizadasOfrecido(int? idUsuarioCalificado)
        {
            return Db.Transaccion.Where(x => x.idUsuarioOfrece == idUsuarioCalificado && x.idEstadoTransaccion == 3).ToList();
        }

        public void FinalizarTransaccion(int? idTransaccion) {
            Transaccion t = BuscarPorId(idTransaccion);
            t.idEstadoTransaccion = 3;
            Db.SaveChanges();
        }
    }
}