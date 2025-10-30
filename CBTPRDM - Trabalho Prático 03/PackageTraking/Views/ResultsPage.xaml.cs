/*
Autores:
Atilio Almeida Costa
CB3025497
João Victor Crivoi Cesar Sousa
CB3062027
*/
using Microsoft.Maui.Controls;

namespace PackageTraking.Views
{
    public partial class ResultsPage : ContentPage
    {
        public ResultsPage()
        {
            InitializeComponent();
            BindingContext = new ViewModels.ResultsViewModel();
        }
    }
}