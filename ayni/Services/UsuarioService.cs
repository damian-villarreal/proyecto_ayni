using ayni.Models;
using ayni.Repositories;
using Nethereum.HdWallet;
using Nethereum.Web3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using NBitcoin;
using Nethereum.Web3.Accounts;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ayni.Services
{
    public class UsuarioService
    {
        ProyectoAyniEntities ctx = new ProyectoAyniEntities();
        TransaccionService transaccionService = new TransaccionService();

        //Alta    
        async
        public Task<bool> Alta(Usuario usuario)
        {
            Usuario usuarioToAdd = transaccionService.GenerateKeyForUser(usuario);
            ctx.Usuario.Add(usuarioToAdd);
            ctx.SaveChanges();
            await transaccionService.TransferFirstAmmount(usuarioToAdd);
            await transaccionService.GetUserBalance(usuarioToAdd);
            return true;
        }

        //Buscar 1

        public Usuario Obtener1Id(int idUsuario)
        {
            var query = from u in ctx.Usuario where u.idUsuario == idUsuario select u;
            var usuario = query.FirstOrDefault();
            return usuario;
        }

        public Usuario Obtener1(string nombreUsuario)
        {
            var query = from u in ctx.Usuario where u.NombreUsuario == nombreUsuario select u;
            var usuario = query.FirstOrDefault();
            return usuario;
        }

        //Modificar
        public bool Modificar(Usuario usuario, string usuarioActual)
        {
            var usuarioModificar = this.Obtener1(usuarioActual);
            usuarioModificar.Email = usuario.Email;
            usuarioModificar.NombreUsuario = usuario.NombreUsuario;
            usuarioModificar.Password = usuario.Password;
            ctx.SaveChanges();
            return true;    
        }

        //Baja
        public bool Eliminar1(Usuario usuario)
        {
            var usuarioEliminar = this.Obtener1(usuario.NombreUsuario);
            ctx.Usuario.Remove(usuarioEliminar);
            ctx.SaveChanges();
            return true;
        }
    }
}