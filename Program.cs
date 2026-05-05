using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaBancario
{
    public interface ITransferible
    {
        void Transferir(decimal monto, ITransferible destino);
        string NumeroCuenta { get; }
        string Titular { get; }
        void RecibirTransferencia(decimal monto);
    }

    public abstract class Cuenta
    {
        public string NumeroCuenta { get; protected set; }
        public string Titular { get; protected set; }
        public decimal Saldo { get; protected set; }

        protected Cuenta(string titular, decimal saldoInicial)
        {
            if (string.IsNullOrWhiteSpace(titular)) 
                throw new ArgumentException("El titular no puede estar vacío.");
            if (saldoInicial < 0) 
                throw new ArgumentException("No se pueden crear cuentas con saldos negativos.");

            Titular = titular;
            Saldo = saldoInicial;
            NumeroCuenta = "CBU-" + Guid.NewGuid().ToString().Substring(0, 5).ToUpper();
        }

        public void Depositar(decimal monto)
        {
            if (monto > 0) Saldo += monto;
        }

        public abstract bool Retirar(decimal monto);

        public void MostrarEstado()
        {
            string tipo = this.GetType().Name == "CajaAhorro" ? "Caja Ahorro  " : "Cta Corriente";
            Console.WriteLine($" > [{tipo}] CBU: {NumeroCuenta} | Titular: {Titular.PadRight(10)} | Saldo: ${Saldo:N2}");
        }
    }

    public class CajaAhorro : Cuenta, ITransferible
    {
        public CajaAhorro(string titular, decimal saldo) : base(titular, saldo) { }
        
        public override bool Retirar(decimal monto)
        {
            if (monto > 0 && Saldo >= monto) { Saldo -= monto; return true; }
            return false;
        }
        
        public void Transferir(decimal monto, ITransferible destino) 
        { 
            if (Retirar(monto)) destino.RecibirTransferencia(monto); 
        }
        
        public void RecibirTransferencia(decimal monto) => Depositar(monto);
    }
