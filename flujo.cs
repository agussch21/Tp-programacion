class Program
{
    static void Main(string[] args)
    {
        Banco banco = new Banco();

        var cuenta1 = new CajaAhorro("Juan", 5000);
        var cuenta2 = new CuentaCorriente("Ana", 2000);

        banco.AgregarCuenta(cuenta1);
        banco.AgregarCuenta(cuenta2);

        cuenta1.Transferir(1000, cuenta2);
        cuenta2.Retirar(5000); // puede quedar en negativo

        banco.MostrarCuentas();
    }
}