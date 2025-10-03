using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using System.Linq;

namespace TarefasApp;

public partial class HomePage : ContentPage
{
    public ObservableCollection<Tarefa> Tarefas { get; set; } = new();

    public HomePage()
    {
        InitializeComponent();
        TarefasListView.ItemsSource = Tarefas;

       
    }

    private async void OnAdicionarClicked(object sender, EventArgs e)
    {
        var novaTarefaPage = new AdicionarTarefaPage();
        novaTarefaPage.TarefaAdicionada += (s, tarefa) =>
        {
            Tarefas.Add(tarefa);
            OrdenarTarefas();
        };
        await Navigation.PushModalAsync(novaTarefaPage);
    }

    private async void OnEditarItemClicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.BindingContext is Tarefa tarefa)
        {
            var editarPage = new EditarTarefaPage(tarefa);
            editarPage.Disappearing += (s, args) =>
            {
                // Reordena quando voltar da página de edição
                OrdenarTarefas();
            };
            await Navigation.PushModalAsync(editarPage);
        }
    }

    private async void OnRemoverItemClicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.BindingContext is Tarefa tarefa)
        {
            Tarefas.Remove(tarefa);
            OrdenarTarefas();
        }
    }
    private async void OnDetalhesItemClicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.BindingContext is Tarefa tarefa)
        {
            var detalhesPage = new DetalhesPage(tarefa);

            // Inscrever nos eventos para atualizar a lista
            detalhesPage.TarefaExcluida += (s, t) =>
            {
                Tarefas.Remove(t);
                OrdenarTarefas();
            };
            detalhesPage.TarefaEditada += (s, t) =>
            {
                OrdenarTarefas();
            };

            await Navigation.PushAsync(detalhesPage);
        }
    }


    private void OrdenarTarefas()
    {
        // Ordena pelo valor da prioridade (Alta > Normal > Baixa)
        var prioridadeOrdem = new Dictionary<string, int> { { "Alta", 3 }, { "Normal", 2 }, { "Baixa", 1 } };

        var tarefasOrdenadas = Tarefas
            .OrderByDescending(t => prioridadeOrdem.ContainsKey(t.Prioridade) ? prioridadeOrdem[t.Prioridade] : 0)
            .ToList();

        Tarefas.Clear();
        foreach (var t in tarefasOrdenadas)
            Tarefas.Add(t);
    }
}
