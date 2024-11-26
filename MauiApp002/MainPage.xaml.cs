using AppEmpresa.Entidades;
using AppEmpresa.ConsumeAPI;

namespace MauiApp002
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        private string apiUrl = "https://appempresaapi.azurewebsites.net/api/Departamentos";

        public MainPage()
        {
            InitializeComponent();
        }

        private void cmdCrear_Clicked(object sender, EventArgs e)
        {
            var data = Crud<Departamento>.Create(apiUrl, new Departamento
            {
                Id = 0,
                Nombre = txtNombreDepartamento.Text,
                Ciudad = txtCiudad.Text
            });

            if ( data != null )
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
            var idDepartamento = int.Parse(txtIdDepartamento.Text);
            var result = Crud<Departamento>.Update(apiUrl, idDepartamento, new Departamento
            {
                Id = idDepartamento,
                Nombre = txtNombreDepartamento.Text,
                Ciudad = txtCiudad.Text
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
            var idDepartamento = int.Parse(txtIdDepartamento.Text);
            var data = Crud<Departamento>.Read_ById(apiUrl, idDepartamento);

            if (data != null)
            {
                txtNombreDepartamento.Text = data.Nombre;
                txtCiudad.Text = data.Ciudad;
            }
            else
            {
                DisplayAlert("Error", "No se pudo leer el registro", "Continuar");
            }
        }

        private void cmdBorrar_Clicked(object sender, EventArgs e)
        {
            var idDepartamento = int.Parse(txtIdDepartamento.Text);
            var result = Crud<Departamento>.Delete(apiUrl, idDepartamento);

            if (result)
            {
                txtIdDepartamento.Text = "";
                txtNombreDepartamento.Text = "";
                txtCiudad.Text = "";
                DisplayAlert("Correcto", "Resgistro eliminado", "Continuar");
            }
            else
            {
                DisplayAlert("Error", "No se pudo eliminar el registro", "Continuar");
            }
        }
    }

}
