using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ayni.Repositories;
using ayni.Models;
using ayni.Services;
using System.Data.Entity;
using System.Threading.Tasks;

namespace ayni.Services
{
    public class PublicacionService
    {
        PublicacionRepo publicacionRepo = new PublicacionRepo();
        UsuarioService usuarioService = new UsuarioService();
        EstadoPublicacionService estadoPublicacionService = new EstadoPublicacionService();
        CategoriaService categoriaService = new CategoriaService();
        TipoPublicacionService tipoPublicacionService = new TipoPublicacionService();
        UsuarioRepo usuarioRepo = new UsuarioRepo();
        TransaccionService transaccionService = new TransaccionService();

        public List<Publicacion> BuscarHome(String s) {
            return publicacionRepo.BuscarHome(s);
        }

        public List<Publicacion> ListarPedidos() {
            return publicacionRepo.ListarPedidos();
        }

        public List<Publicacion> ListarOfrecidos()
        {
            return publicacionRepo.ListarOfrecidos();
        }

        public void Crearfavor(Publicacion p) {
            Publicacion publicacion = new Publicacion
            {
                Titulo = p.Titulo,
                idUsuario = p.idUsuario,
                Valor = p.Valor,
                idTipoPublicacion = 1,
                Descripcion = p.Descripcion,
                idEstadoPublicacion = 1,
                idCategoria = p.idCategoria,
                Fecha_publicacion = DateTime.Now
            };
            publicacionRepo.Crear(publicacion);   
        }


        public void Crearofrecido(Publicacion p)
        {
            Publicacion publicacion = new Publicacion
            {
                Titulo = p.Titulo,
                idUsuario = p.idUsuario,
                Valor = p.Valor,
                idTipoPublicacion = 2,
                Descripcion = p.Descripcion,
                idEstadoPublicacion = 1,
                idCategoria = p.idCategoria,
                Fecha_publicacion = DateTime.Now
            };
            publicacionRepo.Crear(publicacion);
        }



        public List<Publicacion> BuscarPedidosPorIdUsuario(int? id) {
            return publicacionRepo.BuscarPedidosPorIdUsuario(id);
        }

        public List<Publicacion> BuscarOfrecimientosPorIdUsuario(int? id)
        {
            return publicacionRepo.BuscarOfrecimientosPorIdUsuario(id);
        }

        public List<Publicacion> BuscarPublicacionesPostuladasPorIdUsuario(int? id, int? idTipoPublicacion)
        {
            return publicacionRepo.BuscarPublicacionesPostuladasPorUsuario(id, idTipoPublicacion);
        }

        public Publicacion BuscarFavorPorIdPublicacion(int? id)
        {
            return publicacionRepo.BuscarFavorPorIdPublicacion(id);
        }

        public int Modificar(Publicacion p)
        {
            return publicacionRepo.Modificar(p);
        }

        public int Eliminar1(Publicacion p)
        {
            return publicacionRepo.Eliminar1(p);
        }

        public async Task<bool> Finalizar(int fromUserId, string toAddress) {

            Usuario fromUser = usuarioRepo.FindUserById(fromUserId);
            Usuario toUser = usuarioRepo.FindUserByAddress(toAddress);
            await transaccionService.TransferBetweenUsers(fromUser, toUser, 0.000001m);

            return true;
        }
    }
}