using ayni.Models;
using System.Threading.Tasks;
using Nethereum.Web3.Accounts;
using Nethereum.Web3;
using ayni.Repositories;
using System;

namespace ayni.Services
{
    public class SaldoService
    {
        private string infuraApi = "https://ropsten.infura.io/v3/696a078116024b19b8c9097910980a44";
        SaldoRepo saldoRepo = new SaldoRepo();

        public async Task<int> GetUserBalance(Usuario usuario)
        {
            var url = infuraApi;
            var account = new Account(usuario.PrivateKey);
            var web3 = new Web3(account, url);
            var balance = await web3.Eth.GetBalance.SendRequestAsync(usuario.Address);
            decimal etherAmount = Web3.Convert.FromWei(balance.Value);
            int saldoInt = Decimal.ToInt32(etherAmount*1000000) ;
            return saldoInt; 
        }

        public int ObtenerSaldoUsuario(int? idUsuario) {

             
            int Saldo = saldoRepo.ObtenerSaldoUsuario(idUsuario).Cantidad.Value;
            if (Saldo > 0)
            {
                return Saldo;
            }
            else {
                return 0;
            }            
        }

        public void actualizarSaldo(int? idUsuario, int saldo) {
            saldoRepo.ActualizarSaldo(idUsuario, saldo);
        }

        public void crearSaldo(int? idUsuario, int saldo) {
            saldoRepo.CrearSaldo(idUsuario, saldo);
        }

    }

    
}