/*
Autores:
Atilio Almeida Costa
CB3025497
João Victor Crivoi Cesar Sousa
CB3062027
*/
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using PackageTraking.Models;
using PackageTraking.Services;

namespace PackageTraking.ViewModels
{
    [QueryProperty(nameof(Code), "code")]
    public class ResultsViewModel : INotifyPropertyChanged
    {
        readonly ITrackingService _service;

        public ResultsViewModel()
        {
            // Usamos o servico mock localmente. Para producao, injete via DI.
            _service = new MockTrackingService();
            GoBackCommand = new Command(async () => await Shell.Current.GoToAsync(".."));
        }

        string? _code;
        public string? Code
        {
            get => _code;
            set
            {
                if (_code == value) return;
                _code = value;
                OnPropertyChanged();
                _ = LoadPackageAsync(_code);
            }
        }

        Package? _package;
        public Package? Package
        {
            get => _package;
            set { _package = value; OnPropertyChanged(); }
        }

        public ICommand GoBackCommand { get; }

        async Task LoadPackageAsync(string? code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                await Shell.Current.DisplayAlert("Erro", "Codigo invalido.", "OK");
                return;
            }

            var p = await _service.GetPackageAsync(code);
            if (p == null)
            {
                await Shell.Current.DisplayAlert("Nao encontrado", "Nenhum pacote encontrado para este codigo.", "OK");
                return;
            }

            Package = p;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string? name = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}