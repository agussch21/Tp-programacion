public class Banco
{
    private List<Cuenta> cuentas = new List<Cuenta>();

    public void AgregarCuenta(Cuenta cuenta)
    {
        cuentas.Add(cuenta);
    }

    public void MostrarCuentas()
    {
        foreach (var cuenta in cuentas)
        {
            cuenta.MostrarEstado();
        }
    }
}