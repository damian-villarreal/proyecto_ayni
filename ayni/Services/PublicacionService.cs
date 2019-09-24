using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ayni.Repositories;
using ayni.Models;
using ayni.Services;

namespace ayni.Services
{
    public class PublicacionService
    {
        PublicacionRepo publicacionRepo = new PublicacionRepo();
        UsuarioService usuarioService = new UsuarioService();
        EstadoPublicacionService estadoPublicacionService = new EstadoPublicacionService();
        CategoriaService categoriaService = new CategoriaService();
        TipoPublicacionService tipoPublicacionService = new TipoPublicacionService();

        public List<Publicacion> BuscarHome(String s) {
            return publicacionRepo.BuscarHome(s);
        }

        public List<Publicacion> ListarPedidos() {
            return publicacionRepo.ListarPedidos();
        }

        public void Crear(Publicacion p) {
            Publicacion publicacion = new Publicacion
            {
                Titulo = p.Titulo,
                idUsuario = p.idUsuario,
                Valor = p.Valor,
                idTipoPublicacion = p.idTipoPublicacion,
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

        public Publicacion BuscarFavorPorIdPublicacion(int? id)
        {
            return publicacionRepo.BuscarFavorPorIdPublicacion(id);
        }

        public bool Modificar(Publicacion p)
        {
            var booleano = publicacionRepo.Modificar(p);
            return booleano;
        }
    }
}