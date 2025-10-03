using Microsoft.Maui.Controls;

namespace TarefasApp;

public partial class DetalhesPage : ContentPage
{
    private Tarefa TarefaAtual { get; set; }

    // Eventos para notificar a HomePage
    public event EventHandler<Tarefa> TarefaEditada;
    public event EventHandler<Tarefa> TarefaExcluida;

    public DetalhesPage(Tarefa tarefa)
    {
        InitializeComponent();
        TarefaAtual = tarefa;
        BindingContext = TarefaAtual;
    }

    private async void OnEditarClicked(object sender, EventArgs e)
    {
        var editarPage = new EditarTarefaPage(TarefaAtual);
        editarPage.Disappearing += (s, args) =>
        {
            // Notifica que a tarefa foi editada
            TarefaEditada?.Invoke(this, TarefaAtual);
        };
        await Navigation.PushModalAsync(editarPage);
    }

    private async void OnExcluirClicked(object sender, EventArgs e)
    {
        bool confirm = await DisplayAlert("Confirmar", "Deseja realmente excluir esta tarefa?", "Sim", "Não");
        if (confirm)
        {
            TarefaExcluida?.Invoke(this, TarefaAtual);
            await Navigation.PopAsync();
        }
    }
}
