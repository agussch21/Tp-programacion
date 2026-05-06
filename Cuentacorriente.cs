public class CuentaCorriente : Cuenta, ITransferible
{
    private decimal limiteDescubierto = -10000;

    public CuentaCorriente(string titular, decimal saldo) : base(titular, saldo) { }

    public override bool Retirar(decimal monto)
    {
        if (monto > 0 && (Saldo - monto) >= limiteDescubierto)
        {
            Saldo -= monto;
            return true;
        }
        return false;
    }

    public void Transferir(decimal monto, ITransferible destino)
    {
        if (Retirar(monto))
            destino.RecibirTransferencia(monto);
    }

    public void RecibirTransferencia(decimal monto)
    {
        Depositar(monto);
    }
}