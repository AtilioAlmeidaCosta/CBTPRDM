/*
Autores:
Atilio Almeida Costa
CB3025497
João Victor Crivoi Cesar Sousa
CB3062027
*/
using Microsoft.Maui.Controls;
using PackageTraking.Views;

namespace PackageTraking
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(ResultsPage), typeof(ResultsPage));
        }
    }
}
