using AppEmpresa.ConsumeAPI;
using AppEmpresa.Entidades;

namespace MauiApp002;

public partial class Empleados : ContentPage
{
    private string apiUrl = "https://appempresaapi.azurewebsites.net/api/Empleados";
	public Empleados()
	{
		InitializeComponent();
	}

    private void cmdCrear_Clicked(object sender, EventArgs e)
    {
        var data = Crud<Empleado>.Create(apiUrl, new Empleado
        {
            Id = 0,
            Apellidos = txtApellidosEmpleado.Text,
            Nombres = txtNombresEmpleado.Text,
            Direcrion = txtDireccionEmpleado.Text,
            FechaNacimiento = DateTime.Parse(txtFechaNacimientoEmpleado.Text), // Asumiendo que se introduce una fecha válida
            Salario = double.Parse(txtSalarioEmpleado.Text),
            Comision = string.IsNullOrEmpty(txtComisionEmpleado.Text) ? (double?)null : double.Parse(txtComisionEmpleado.Text),
            CargoId = int.Parse(txtCargoIdEmpleado.Text),
            DepartamentoId = int.Parse(txtDepartamentoIdEmpleado.Text)
        });

        if (data != null)
        {
            DisplayAlert("Correcto", "Registro creado", "Continuar");
        }
        else
        {
            DisplayAlert("Error", "No se pudo crear el registro", "Continuar");
        }
    }

    private void cmdActualizar_Clicked(object sender, EventArgs e)
    {
        var idEmpleado = int.Parse(txtIdEmpleado.Text);
        var result = Crud<Empleado>.Update(apiUrl, idEmpleado, new Empleado
        {
            Id = idEmpleado,
            Apellidos = txtApellidosEmpleado.Text,
            Nombres = txtNombresEmpleado.Text,
            Direcrion = txtDireccionEmpleado.Text,
            FechaNacimiento = DateTime.Parse(txtFechaNacimientoEmpleado.Text),
            Salario = double.Parse(txtSalarioEmpleado.Text),
            Comision = string.IsNullOrEmpty(txtComisionEmpleado.Text) ? (double?)null : double.Parse(txtComisionEmpleado.Text),
            CargoId = int.Parse(txtCargoIdEmpleado.Text),
            DepartamentoId = int.Parse(txtDepartamentoIdEmpleado.Text)
        });

        if (result != null)
        {
            DisplayAlert("Correcto", "Registro actualizado", "Continuar");
        }
        else
        {
            DisplayAlert("Error", "No se pudo actualizar el registro", "Continuar");
        }
    }

    private void cmdLeer_Clicked(object sender, EventArgs e)
    {
        var idEmpleado = int.Parse(txtIdEmpleado.Text);
        var data = Crud<Empleado>.Read_ById(apiUrl, idEmpleado);

        if (data != null)
        {
            txtApellidosEmpleado.Text = data.Apellidos;
            txtNombresEmpleado.Text = data.Nombres;
            txtDireccionEmpleado.Text = data.Direcrion;
            txtFechaNacimientoEmpleado.Text = data.FechaNacimiento?.ToString("yyyy-MM-dd");
            txtSalarioEmpleado.Text = data.Salario.ToString();
            txtComisionEmpleado.Text = data.Comision?.ToString();
            txtCargoIdEmpleado.Text = data.CargoId.ToString();
            txtDepartamentoIdEmpleado.Text = data.DepartamentoId.ToString();
        }
        else
        {
            DisplayAlert("Error", "No se pudo leer el registro", "Continuar");
        }
    }

    private void cmdBorrar_Clicked(object sender, EventArgs e)
    {
        var idEmpleado = int.Parse(txtIdEmpleado.Text);
        var result = Crud<Empleado>.Delete(apiUrl, idEmpleado);

        if (result)
        {
            txtIdEmpleado.Text = "";
            txtApellidosEmpleado.Text = "";
            txtNombresEmpleado.Text = "";
            txtDireccionEmpleado.Text = "";
            txtFechaNacimientoEmpleado.Text = "";
            txtSalarioEmpleado.Text = "";
            txtComisionEmpleado.Text = "";
            txtCargoIdEmpleado.Text = "";
            txtDepartamentoIdEmpleado.Text = "";
            DisplayAlert("Correcto", "Registro eliminado", "Continuar");
        }
        else
        {
            DisplayAlert("Error", "No se pudo eliminar el registro", "Continuar");
        }
    }
}