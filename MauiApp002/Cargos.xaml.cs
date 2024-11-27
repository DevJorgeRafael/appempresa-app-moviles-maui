using AppEmpresa.ConsumeAPI;
using AppEmpresa.Entidades;

namespace MauiApp002;

public partial class Cargos : ContentPage
{
    private String apiUrl = "https://appempresaapi.azurewebsites.net/api/Cargos";
	public Cargos()
	{
		InitializeComponent();
	}

    private void cmdCrear_Clicked(object sender, EventArgs e)
    {
        var data = Crud<Cargo>.Create(apiUrl, new Cargo
        {
            Id = 0,
            Nombre = txtNombreCargo.Text
        });

        if (data != null)
        {
            DisplayAlert("Correcto", "Resgistro creado", "Continuar");
        }
        else
        {
            DisplayAlert("Error", "No se pudo crear el registro", "Continuar");
        }
    }

    private void cmdActualizar_Clicked(object sender, EventArgs e)
    {
        var idCargo= int.Parse(txtIdCargo.Text);
        var result = Crud<Cargo>.Update(apiUrl, idCargo, new Cargo
        {
            Id = idCargo,
            Nombre = txtNombreCargo.Text
        });

        if (result != null)
        {
            DisplayAlert("Correcto", "Resgistro actualizado", "Continuar");
        }
        else
        {
            DisplayAlert("Error", "No se pudo actualizar el registro", "Continuar");
        }
    }

    private void cmdLeer_Clicked(object sender, EventArgs e)
    {
        var idCargo= int.Parse(txtIdCargo.Text);
        var data = Crud<Cargo>.Read_ById(apiUrl, idCargo);

        if (data != null)
        {
            txtNombreCargo.Text = data.Nombre;
        }
        else
        {
            DisplayAlert("Error", "No se pudo leer el registro", "Continuar");
        }
    }

    private void cmdBorrar_Clicked(object sender, EventArgs e)
    {
        var idCargo= int.Parse(txtIdCargo.Text);
        var result = Crud<Cargo>.Delete(apiUrl, idCargo);

        if (result)
        {
            txtIdCargo.Text = "";
            txtNombreCargo.Text = "";
            DisplayAlert("Correcto", "Resgistro eliminado", "Continuar");
        }
        else
        {
            DisplayAlert("Error", "No se pudo eliminar el registro", "Continuar");
        }
    }
}