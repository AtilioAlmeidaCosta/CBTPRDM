using Microsoft.Maui.Controls;

namespace TarefasApp;

public partial class AdicionarTarefaPage : ContentPage
{
    public event EventHandler<Tarefa> TarefaAdicionada;

    public AdicionarTarefaPage()
    {
        InitializeComponent();

        // Data inicial
        datePicker.Date = DateTime.Now;
        datePicker.TextColor = (Color)Application.Current.Resources["MarromEscuro"];

        // Prioridade inicial
        pickerPrioridade.SelectedItem = "Normal";
        pickerPrioridade.TextColor = (Color)Application.Current.Resources["MarromEscuro"];
    }

    private async void OnSalvarClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(entryTitulo.Text))
        {
            await DisplayAlert("Erro", "O título é obrigatório.", "OK");
            return;
        }

        var tarefa = new Tarefa
        {
            Titulo = entryTitulo.Text,
            Descricao = entryDescricao.Text,
            DataCriacao = datePicker.Date,
            Prioridade = pickerPrioridade.SelectedItem?.ToString() ?? "Normal"
        };

        TarefaAdicionada?.Invoke(this, tarefa);
        await Navigation.PopModalAsync();
    }

    private async void OnCancelarClicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}
