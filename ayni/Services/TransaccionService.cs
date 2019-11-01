﻿using NBitcoin;
using Nethereum.Web3;
using Nethereum.HdWallet;
using ayni.Models;
using System.Threading.Tasks;
using Nethereum.Web3.Accounts;
using ayni.Repositories;
using System.Collections.Generic;
using System;

namespace ayni.Services
{
    public class TransaccionService
    {

        TransaccionRepo transaccionRepo = new TransaccionRepo();
        SaldoService saldoService = new SaldoService();
        UsuarioRepo usuarioRepo = new UsuarioRepo();
        PublicacionRepo publicacionRepo = new PublicacionRepo();

        //UsuarioService usuarioService = new UsuarioService();

        //direccion del smart contract
        private string ContractAddress = "0x7bdb011d03836c7bae1fdc4264031543773f7ca5";
        //direccion y clave privada de la cuenta que envia tokens
        private string senderAddress = "0x1e8d758eb690d2d7e260937b8d703869db12d4f9";
        //private string receiverAddress = "0x9d831ef777D68256532a5BEB15190348Dd1Ef0f8";
        private string privateKey = "855950ED47AD62DE9807775FC2BDD7CD808432240042A15B7E5BF9D24DB84B22";
        private string words = "radio tonight salmon negative actress process water useful effort over math rare";
        private string password = "nX(^\b2BeuQeT,,7";
        //abi y bytecode del contrato
        private string abi = @"[{""constant"":true,""inputs"":[],""name"":""name"",""outputs"":[{""name"":"""",""type"":""string""}],""payable"":false,""stateMutability"":""view"",""type"":""function""},{""constant"":false,""inputs"":[{""name"":""spender"",""type"":""address""},{""name"":""value"",""type"":""uint256""}],""name"":""approve"",""outputs"":[{""name"":"""",""type"":""bool""}],""payable"":false,""stateMutability"":""nonpayable"",""type"":""function""},{""constant"":true,""inputs"":[],""name"":""totalSupply"",""outputs"":[{""name"":"""",""type"":""uint256""}],""payable"":false,""stateMutability"":""view"",""type"":""function""},{""constant"":false,""inputs"":[{""name"":""sender"",""type"":""address""},{""name"":""recipient"",""type"":""address""},{""name"":""amount"",""type"":""uint256""}],""name"":""transferFrom"",""outputs"":[{""name"":"""",""type"":""bool""}],""payable"":false,""stateMutability"":""nonpayable"",""type"":""function""},{""constant"":true,""inputs"":[],""name"":""decimals"",""outputs"":[{""name"":"""",""type"":""uint8""}],""payable"":false,""stateMutability"":""view"",""type"":""function""},{""constant"":false,""inputs"":[{""name"":""spender"",""type"":""address""},{""name"":""addedValue"",""type"":""uint256""}],""name"":""increaseAllowance"",""outputs"":[{""name"":"""",""type"":""bool""}],""payable"":false,""stateMutability"":""nonpayable"",""type"":""function""},{""constant"":false,""inputs"":[{""name"":""value"",""type"":""uint256""}],""name"":""burn"",""outputs"":[],""payable"":false,""stateMutability"":""nonpayable"",""type"":""function""},{""constant"":true,""inputs"":[{""name"":""account"",""type"":""address""}],""name"":""balanceOf"",""outputs"":[{""name"":"""",""type"":""uint256""}],""payable"":false,""stateMutability"":""view"",""type"":""function""},{""constant"":true,""inputs"":[],""name"":""symbol"",""outputs"":[{""name"":"""",""type"":""string""}],""payable"":false,""stateMutability"":""view"",""type"":""function""},{""constant"":false,""inputs"":[{""name"":""spender"",""type"":""address""},{""name"":""subtractedValue"",""type"":""uint256""}],""name"":""decreaseAllowance"",""outputs"":[{""name"":"""",""type"":""bool""}],""payable"":false,""stateMutability"":""nonpayable"",""type"":""function""},{""constant"":false,""inputs"":[{""name"":""recipient"",""type"":""address""},{""name"":""amount"",""type"":""uint256""}],""name"":""transfer"",""outputs"":[{""name"":"""",""type"":""bool""}],""payable"":false,""stateMutability"":""nonpayable"",""type"":""function""},{""constant"":true,""inputs"":[{""name"":""owner"",""type"":""address""},{""name"":""spender"",""type"":""address""}],""name"":""allowance"",""outputs"":[{""name"":"""",""type"":""uint256""}],""payable"":false,""stateMutability"":""view"",""type"":""function""},{""inputs"":[{""name"":""name"",""type"":""string""},{""name"":""symbol"",""type"":""string""},{""name"":""decimals"",""type"":""uint8""},{""name"":""totalSupply"",""type"":""uint256""},{""name"":""feeReceiver"",""type"":""address""},{""name"":""tokenOwnerAddress"",""type"":""address""}],""payable"":true,""stateMutability"":""payable"",""type"":""constructor""},{""anonymous"":false,""inputs"":[{""indexed"":true,""name"":""from"",""type"":""address""},{""indexed"":true,""name"":""to"",""type"":""address""},{""indexed"":false,""name"":""value"",""type"":""uint256""}],""name"":""Transfer"",""type"":""event""},{""anonymous"":false,""inputs"":[{""indexed"":true,""name"":""owner"",""type"":""address""},{""indexed"":true,""name"":""spender"",""type"":""address""},{""indexed"":false,""name"":""value"",""type"":""uint256""}],""name"":""Approval"",""type"":""event""}]";
        private string contractByteCode = "0x6080604052600436106100ba576000357c0100000000000000000000000000000000000000000000000000000000900463ffffffff16806306fdde03146100bf578063095ea7b31461014f57806318160ddd146101c257806323b872dd146101ed578063313ce5671461028057806339509351146102b157806342966c681461032457806370a082311461035f57806395d89b41146103c4578063a457c2d714610454578063a9059cbb146104c7578063dd62ed3e1461053a575b600080fd5b3480156100cb57600080fd5b506100d46105bf565b6040518080602001828103825283818151815260200191508051906020019080838360005b838110156101145780820151818401526020810190506100f9565b50505050905090810190601f1680156101415780820380516001836020036101000a031916815260200191505b509250505060405180910390f35b34801561015b57600080fd5b506101a86004803603604081101561017257600080fd5b81019080803573ffffffffffffffffffffffffffffffffffffffff16906020019092919080359060200190929190505050610661565b604051808215151515815260200191505060405180910390f35b3480156101ce57600080fd5b506101d7610678565b6040518082815260200191505060405180910390f35b3480156101f957600080fd5b506102666004803603606081101561021057600080fd5b81019080803573ffffffffffffffffffffffffffffffffffffffff169060200190929190803573ffffffffffffffffffffffffffffffffffffffff16906020019092919080359060200190929190505050610682565b604051808215151515815260200191505060405180910390f35b34801561028c57600080fd5b50610295610733565b604051808260ff1660ff16815260200191505060405180910390f35b3480156102bd57600080fd5b5061030a600480360360408110156102d457600080fd5b81019080803573ffffffffffffffffffffffffffffffffffffffff1690602001909291908035906020019092919050505061074a565b604051808215151515815260200191505060405180910390f35b34801561033057600080fd5b5061035d6004803603602081101561034757600080fd5b81019080803590602001909291905050506107ef565b005b34801561036b57600080fd5b506103ae6004803603602081101561038257600080fd5b81019080803573ffffffffffffffffffffffffffffffffffffffff1690602001909291905050506107fc565b6040518082815260200191505060405180910390f35b3480156103d057600080fd5b506103d9610844565b6040518080602001828103825283818151815260200191508051906020019080838360005b838110156104195780820151818401526020810190506103fe565b50505050905090810190601f1680156104465780820380516001836020036101000a031916815260200191505b509250505060405180910390f35b34801561046057600080fd5b506104ad6004803603604081101561047757600080fd5b81019080803573ffffffffffffffffffffffffffffffffffffffff169060200190929190803590602001909291905050506108e6565b604051808215151515815260200191505060405180910390f35b3480156104d357600080fd5b50610520600480360360408110156104ea57600080fd5b81019080803573ffffffffffffffffffffffffffffffffffffffff1690602001909291908035906020019092919050505061098b565b604051808215151515815260200191505060405180910390f35b34801561054657600080fd5b506105a96004803603604081101561055d57600080fd5b81019080803573ffffffffffffffffffffffffffffffffffffffff169060200190929190803573ffffffffffffffffffffffffffffffffffffffff1690602001909291905050506109a2565b6040518082815260200191505060405180910390f35b606060038054600181600116156101000203166002900480601f0160208091040260200160405190810160405280929190818152602001828054600181600116156101000203166002900480156106575780601f1061062c57610100808354040283529160200191610657565b820191906000526020600020905b81548152906001019060200180831161063a57829003601f168201915b5050505050905090565b600061066e338484610a29565b6001905092915050565b6000600254905090565b600061068f848484610caa565b610728843361072385600160008a73ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060003373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002054610fd090919063ffffffff16565b610a29565b600190509392505050565b6000600560009054906101000a900460ff16905090565b60006107e533846107e085600160003373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060008973ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff1681526020019081526020016000205461105b90919063ffffffff16565b610a29565b6001905092915050565b6107f933826110e5565b50565b60008060008373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff168152602001908152602001600020549050919050565b606060048054600181600116156101000203166002900480601f0160208091040260200160405190810160405280929190818152602001828054600181600116156101000203166002900480156108dc5780601f106108b1576101008083540402835291602001916108dc565b820191906000526020600020905b8154815290600101906020018083116108bf57829003601f168201915b5050505050905090565b6000610981338461097c85600160003373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060008973ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002054610fd090919063ffffffff16565b610a29565b6001905092915050565b6000610998338484610caa565b6001905092915050565b6000600160008473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060008373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002054905092915050565b600073ffffffffffffffffffffffffffffffffffffffff168373ffffffffffffffffffffffffffffffffffffffff1614151515610af4576040517f08c379a00000000000000000000000000000000000000000000000000000000081526004018080602001828103825260248152602001807f45524332303a20617070726f76652066726f6d20746865207a65726f2061646481526020017f726573730000000000000000000000000000000000000000000000000000000081525060400191505060405180910390fd5b600073ffffffffffffffffffffffffffffffffffffffff168273ffffffffffffffffffffffffffffffffffffffff1614151515610bbf576040517f08c379a00000000000000000000000000000000000000000000000000000000081526004018080602001828103825260228152602001807f45524332303a20617070726f766520746f20746865207a65726f20616464726581526020017f737300000000000000000000000000000000000000000000000000000000000081525060400191505060405180910390fd5b80600160008573ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060008473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff168152602001908152602001600020819055508173ffffffffffffffffffffffffffffffffffffffff168373ffffffffffffffffffffffffffffffffffffffff167f8c5be1e5ebec7d5bd14f71427d1e84f3dd0314c0f7b2291e5b200ac8c7c3b925836040518082815260200191505060405180910390a3505050565b600073ffffffffffffffffffffffffffffffffffffffff168373ffffffffffffffffffffffffffffffffffffffff1614151515610d75576040517f08c379a00000000000000000000000000000000000000000000000000000000081526004018080602001828103825260258152602001807f45524332303a207472616e736665722066726f6d20746865207a65726f20616481526020017f647265737300000000000000000000000000000000000000000000000000000081525060400191505060405180910390fd5b600073ffffffffffffffffffffffffffffffffffffffff168273ffffffffffffffffffffffffffffffffffffffff1614151515610e40576040517f08c379a00000000000000000000000000000000000000000000000000000000081526004018080602001828103825260238152602001807f45524332303a207472616e7366657220746f20746865207a65726f206164647281526020017f657373000000000000000000000000000000000000000000000000000000000081525060400191505060405180910390fd5b610e91816000808673ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002054610fd090919063ffffffff16565b6000808573ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002081905550610f24816000808573ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff1681526020019081526020016000205461105b90919063ffffffff16565b6000808473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff168152602001908152602001600020819055508173ffffffffffffffffffffffffffffffffffffffff168373ffffffffffffffffffffffffffffffffffffffff167fddf252ad1be2c89b69c2b068fc378daa952ba7f163c4a11628f55a4df523b3ef836040518082815260200191505060405180910390a3505050565b600082821115151561104a576040517f08c379a000000000000000000000000000000000000000000000000000000000815260040180806020018281038252601e8152602001807f536166654d6174683a207375627472616374696f6e206f766572666c6f77000081525060200191505060405180910390fd5b600082840390508091505092915050565b60008082840190508381101515156110db576040517f08c379a000000000000000000000000000000000000000000000000000000000815260040180806020018281038252601b8152602001807f536166654d6174683a206164646974696f6e206f766572666c6f77000000000081525060200191505060405180910390fd5b8091505092915050565b600073ffffffffffffffffffffffffffffffffffffffff168273ffffffffffffffffffffffffffffffffffffffff16141515156111b0576040517f08c379a00000000000000000000000000000000000000000000000000000000081526004018080602001828103825260218152602001807f45524332303a206275726e2066726f6d20746865207a65726f2061646472657381526020017f730000000000000000000000000000000000000000000000000000000000000081525060400191505060405180910390fd5b6111c581600254610fd090919063ffffffff16565b60028190555061121c816000808573ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002054610fd090919063ffffffff16565b6000808473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002081905550600073ffffffffffffffffffffffffffffffffffffffff168273ffffffffffffffffffffffffffffffffffffffff167fddf252ad1be2c89b69c2b068fc378daa952ba7f163c4a11628f55a4df523b3ef836040518082815260200191505060405180910390a3505056fea165627a7a72305820e20d925751f78a8e97575d042cae5a0688546f17e3e28665288efb94861651f10029";
        //private string infuraApi = "https://api.infura.io/v1/jsonrpc/ropsten";
        private string infuraApi = "https://ropsten.infura.io/v3/696a078116024b19b8c9097910980a44";

        public Usuario GenerateKeyForUser(Usuario usuario)
        {
            //creo palabras aleatorias para generar clave privada
            Mnemonic mnemo = new Mnemonic(Wordlist.English, WordCount.Twelve);
            string Words = mnemo.ToString();
            //creo wallet
            var wallet = new Wallet(Words, usuario.Password);
            var account = new Wallet(Words, usuario.Password).GetAccount(0);
            var web3 = new Web3(account);
            usuario.Address = account.Address;
            usuario.PrivateKey = account.PrivateKey;
            usuario.Words = Words;
            return usuario;
        }


        public async Task TransferFirstAmmount(Usuario usuario)
        {

            var url = infuraApi;
            var account = new Account(privateKey);
            var web3 = new Web3(account, url);

            string Words = "radio tonight salmon negative actress process water useful effort over math rare";
            string Password = "nX(^\b2BeuQeT,,7";
            var wallet = new Wallet(Words, Password);

            var transaction = await web3.Eth.GetEtherTransferService()
                .TransferEtherAndWaitForReceiptAsync(usuario.Address, 0.000001m);
        }

        public async Task<decimal> GetUserBalance(Usuario usuario)
        {
            var url = infuraApi;
            var account = new Account(usuario.PrivateKey);
            var web3 = new Web3(account, url);
            var balance = await web3.Eth.GetBalance.SendRequestAsync(usuario.Address);
            var etherAmount = Web3.Convert.FromWei(balance.Value);
            return etherAmount;
        }

        public async Task<bool> TransferBetweenUsers(Usuario from, Usuario to, decimal amount)
        {
            var url = infuraApi;
            var account1 = new Account(privateKey);
            var web3_1 = new Web3(account1, url);
            //var wallet = new Wallet(from.Words, from.Password);            
            var transaction = await web3_1.Eth.GetEtherTransferService()
                .TransferEtherAndWaitForReceiptAsync(from.Address, 0.000021m);

            var account2 = new Account(from.PrivateKey);
            var web3_2 = new Web3(account2, url);
            //var wallet = new Wallet(from.Words, from.Password);            
            var transaction2 = await web3_2.Eth.GetEtherTransferService()
                .TransferEtherAndWaitForReceiptAsync(to.Address, amount);
            return true;
        }

        public bool Crear(Postulacion p)
        {
            Transaccion t = new Transaccion();
            t.idEstadoTransaccion = 1;
            t.idPublicacion = p.idPublicacion;
            if (p.Publicacion.idTipoPublicacion == 1) {
                t.idUsuarioRecibe = p.Publicacion.idUsuario;
                t.idUsuarioOfrece = p.idPostulante;
            }
            else {
                t.idUsuarioOfrece = p.Publicacion.idUsuario;
                t.idUsuarioRecibe = p.idPostulante;
            }

            transaccionRepo.Crear(t);
            return true;
        }

        public List<Transaccion> BuscarPorIdUsuario(int? idUsuario) {
            return transaccionRepo.BuscarPorIdUsuario(idUsuario);
        }

        async
        public Task Confirmar(int? idTransaccion)
        {
            Transaccion t = transaccionRepo.BuscarPorId(idTransaccion);
            int idUsuario = Sesiones.SessionManagement.IdUsuario;

            if (idUsuario == t.idUsuarioOfrece)
            {
                t.confirm_ofrece = true;
            }

            if (idUsuario == t.idUsuarioRecibe)
            {
                t.confirm_recibe = true;
            }

            transaccionRepo.Modificar(t);

            if (t.confirm_ofrece == true && t.confirm_ofrece == t.confirm_recibe)
            {
                Usuario from = usuarioRepo.FindUserById(t.idUsuarioRecibe);
                Usuario to = usuarioRepo.FindUserById(t.idUsuarioOfrece);

                decimal valorDecimal = Convert.ToDecimal(t.Publicacion.Valor);
                decimal monto = valorDecimal / 1000000;
                await TransferBetweenUsers(from, to, monto);
                Publicacion p = publicacionRepo.BuscarPorId(t.idPublicacion);
                p.idEstadoPublicacion = 3;
                publicacionRepo.Modificar(p);
                int saldoFrom = await saldoService.GetUserBalance(from);
                int saldoTo = await saldoService.GetUserBalance(to);

                saldoService.actualizarSaldo(from.idUsuario, saldoFrom);
                saldoService.actualizarSaldo(to.idUsuario, saldoTo);
                
            }

            
        }

    }
}