using System;
using Microsoft.Maui.Controls;

namespace TP01_CBTPRDM;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private void OkBtn_Clicked(object sender, EventArgs e)
    {
        string id = IdEntry.Text?.Trim();
        string senha = PassEntry.Text;

        if (id == "admin" && senha == "@dmin")
        {
            DisplayAlert("Login", "Logado com sucesso!", "OK");
        }
        else
        {
            DisplayAlert("Login", "Login não autorizado!", "OK");
        }
    }

    private void LimparBtn_Clicked(object sender, EventArgs e)
    {
        IdEntry.Text = string.Empty;
        PassEntry.Text = string.Empty;

        IdEntry.Focus();
    }

    private void CreditosBtn_Clicked(object sender, EventArgs e)
    {
        DisplayAlert("Créditos", "Aplicativo desenvolvido por:\n• Atilio Almeida Costa | CB3025497 \n• João Victor Crivoi Cesar Souza | CB3026027", "OK");
    }
}
