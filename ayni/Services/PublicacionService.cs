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
        readonly UsuarioService usuarioService = new UsuarioService();
        readonly EstadoPublicacionService estadoPublicacionService = new EstadoPublicacionService();
        readonly CategoriaService categoriaService = new CategoriaService();
        readonly TipoPublicacionService tipoPublicacionService = new TipoPublicacionService();
        UsuarioRepo usuarioRepo = new UsuarioRepo();
        TransaccionService transaccionService = new TransaccionService();

        public List<Publicacion> BuscarHome(String s) {
            return publicacionRepo.BuscarHome(s);
        }

        public List<Publicacion> ListarTodos()
        {
            return publicacionRepo.ListarTodos();
        }

        public List<Publicacion> ListarPedidos()
        {
            return publicacionRepo.ListarPedidos();
        }

        public List<Publicacion> ListarPedidosHome() {
            return publicacionRepo.ListarPedidosHome();
        }

        public List<Publicacion> ListarOfrecidosHome()
        {
            return publicacionRepo.ListarOfrecidosHome();
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
                Fecha_publicacion = DateTime.Now,
                Ubicacion = p.Ubicacion,
                Imagen = p.Imagen
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
                Imagen = p.Imagen,
                Ubicacion = p.Ubicacion,
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

        public List<Publicacion> BuscarPublicacionesPostuladasPorIdUsuario(int? id)
        {
            return publicacionRepo.BuscarPublicacionesPostuladasPorUsuario(id);
        }

        public Publicacion BuscarFavorPorIdPublicacion(int? id)
        {
            return publicacionRepo.BuscarFavorPorIdPublicacion(id);
        }

        public List<Publicacion> BuscarPublicacionPorContenido(string s)
        {
            return publicacionRepo.BuscarPublicacionPorContenido(s);
        }

        public List<Publicacion> BuscarAvanzada(string inputBuscar, string Ubicacion, int? Categoria, int? Usuario, int? Ordenar, string AscDsc)
        {
            System.Diagnostics.Debug.WriteLine("AscDsc:" + AscDsc);
            var publicacionesTodas = this.ListarTodos();
            var publicacionesFiltro = from p in publicacionesTodas where p.idEstadoPublicacion == 1 select p;


            if (!string.IsNullOrWhiteSpace(inputBuscar))
                publicacionesFiltro = publicacionesFiltro.Where(p => p.Titulo.Contains(inputBuscar));
            if (!string.IsNullOrWhiteSpace(Ubicacion))
                publicacionesFiltro = publicacionesFiltro.Where(p => p.Ubicacion == Ubicacion);
            if (!(Categoria == null || Categoria == 0))
                publicacionesFiltro = publicacionesFiltro.Where(p => p.idCategoria == Categoria);
            if (!(Usuario == null || Usuario == 0))
                publicacionesFiltro = publicacionesFiltro.Where(p => p.idUsuario == Usuario);

            switch (Ordenar)
            {
                case 1:
                    if (AscDsc == "1")
                    {
                        publicacionesFiltro = publicacionesFiltro.OrderByDescending(p => p.Titulo);
                    }
                    else
                    {
                        publicacionesFiltro = publicacionesFiltro.OrderBy(p => p.Titulo);
                    }
                    
                    break;
                case 2:
                    if (AscDsc == "1")
                    {
                        publicacionesFiltro = publicacionesFiltro.OrderByDescending(p => p.Fecha_publicacion);
                    }
                    else
                    {
                        publicacionesFiltro = publicacionesFiltro.OrderBy(p => p.Fecha_publicacion);
                    }
                    
                    break;
                case 3:
                    if (AscDsc == "1")
                    {
                        publicacionesFiltro = publicacionesFiltro.OrderByDescending(p => p.Valor);
                    }
                    else
                    {
                        publicacionesFiltro = publicacionesFiltro.OrderBy(p => p.Valor);
                    }
                    break;
                default:
                    publicacionesFiltro = publicacionesFiltro.OrderBy(p => p.Titulo);
                    break;
            }

            return publicacionesFiltro.ToList();
        }


        //Modificación

        public int Modificar(Publicacion p)
        {
            return publicacionRepo.Modificar(p);
        }

        public int Eliminar1(Publicacion p)
        {
            return publicacionRepo.Eliminar1(p);
        }

        //public async Task<bool> Finalizar(int fromUserId, string toAddress)
        //{

        //    Usuario fromUser = usuarioRepo.FindUserById(fromUserId);
        //    Usuario toUser = usuarioRepo.FindUserByAddress(toAddress);
        //    await transaccionService.TransferBetweenUsers(fromUser, toUser, 0.000001m);

        //    return true;
        //}

        public Publicacion BuscarPorID(int? idPublicacion) {
            return publicacionRepo.BuscarPorId(idPublicacion);
        }

        public int? ObtenerPrecioDePublicacionesActivas(int? idUsuario) {
            int? precioDePublicacionesActivas = publicacionRepo.ObtenerPrecioDePublicacionesActivas(idUsuario);

            return precioDePublicacionesActivas;
        }

    }
}