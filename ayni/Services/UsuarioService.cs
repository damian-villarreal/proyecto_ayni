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

namespace ayni.Services
{
    public class UsuarioService
    {
        ProyectoAyniEntities ctx = new ProyectoAyniEntities();

        //Alta
        public bool Alta(Usuario usuario)
        {
            //creo palabras aleatorias para generar clave privada
            Mnemonic mnemo = new Mnemonic(Wordlist.Spanish, WordCount.Fifteen);
            string Words = mnemo.ToString();            
            //creo wallet
            var wallet = new Wallet(Words, usuario.Password);
            var account = new Wallet(Words, usuario.Password).GetAccount(0);
            var web3 = new Web3(account); 
            
            usuario.Address = account.Address;
            usuario.PublicKey = account.PrivateKey;
            ctx.Usuario.Add(usuario);
            ctx.SaveChanges();

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