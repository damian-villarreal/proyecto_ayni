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
                Usuario = usuarioService.Obtener1Id(1),
                Valor = p.Valor,
                Descripcion = p.Descripcion,
                TipoPublicacion = tipoPublicacionService.ObtenerPorId(p.idTipoPublicacion),
                Categoria = categoriaService.ObtenerPorId(p.idCategoria),
                EstadoPublicacion = estadoPublicacionService.ObtenerPorId(1),
                Fecha_publicacion = DateTime.Now
            };
            publicacionRepo.Crear(publicacion);   
        }
    }
}