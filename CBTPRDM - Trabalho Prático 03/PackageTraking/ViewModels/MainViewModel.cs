/*
Autores:
Atilio Almeida Costa
CB3025497
João Victor Crivoi Cesar Sousa
CB3062027
*/
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using PackageTraking.Models;

namespace PackageTraking.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        string _trackingCode = string.Empty;
        public string TrackingCode
        {
            get => _trackingCode;
            set { _trackingCode = value; OnPropertyChanged(); }
        }

        public ObservableCollection<Package> Packages { get; } = new();

        public ICommand SearchCommand { get; }
        public ICommand SelectPackageCommand { get; }

        public MainViewModel()
        {
            // Preenche 5 pacotes falsos
            var now = DateTime.Now;
            Packages.Add(new Package
            {
                Id = "PKG001",
                Status = "Em transito",
                ShippedDate = now.AddDays(-5),
                ExpectedDelivery = now.AddDays(2),
                CurrentLocation = "Centro de distribuicao - Sao Paulo"
            });
            Packages.Add(new Package
            {
                Id = "PKG002",
                Status = "Em transito",
                ShippedDate = now.AddDays(-3),
                ExpectedDelivery = now.AddDays(1),
                CurrentLocation = "Centro de distribuicao - Rio de Janeiro"
            });
            Packages.Add(new Package
            {
                Id = "PKG003",
                Status = "Pronto para entrega",
                ShippedDate = now.AddDays(-2),
                ExpectedDelivery = now.AddDays(0),
                CurrentLocation = "Filial local - Salvador"
            });
            Packages.Add(new Package
            {
                Id = "PKG004",
                Status = "Entregue",
                ShippedDate = now.AddDays(-10),
                ExpectedDelivery = now.AddDays(-5),
                CurrentLocation = "Destino - Belo Horizonte"
            });
            Packages.Add(new Package
            {
                Id = "PKG005",
                Status = "Em transito",
                ShippedDate = now.AddDays(-1),
                ExpectedDelivery = now.AddDays(4),
                CurrentLocation = "Centro de distribuicao - Curitiba"
            });

            SearchCommand = new Command(async () =>
            {
                if (string.IsNullOrWhiteSpace(TrackingCode))
                {
                    await Shell.Current.DisplayAlert("Atencao", "Informe o codigo de rastreamento.", "OK");
                    return;
                }

                var encoded = Uri.EscapeDataString(TrackingCode.Trim());
                await Shell.Current.GoToAsync($"ResultsPage?code={encoded}");
            });

            SelectPackageCommand = new Command<object>(async (param) =>
            {
                if (param is SelectionChangedEventArgs args)
                {
                    var pkg = args.CurrentSelection?.FirstOrDefault() as Package;
                    if (pkg != null)
                    {
                        var code = Uri.EscapeDataString(pkg.Id);
                        await Shell.Current.GoToAsync($"ResultsPage?code={code}");
                    }
                }
            });
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string? name = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}