using Microsoft.Maui.Controls;

namespace TarefasApp;

public partial class EditarTarefaPage : ContentPage
{
    private Tarefa TarefaOriginal { get; set; }

    public EditarTarefaPage(Tarefa tarefa)
    {
        InitializeComponent();

        TarefaOriginal = tarefa;

        // Preencher campos com os dados existentes
        entryTitulo.Text = tarefa.Titulo;
        entryDescricao.Text = tarefa.Descricao;

        // Data de criação correta
        datePicker.Date = tarefa.DataCriacao == DateTime.MinValue ? DateTime.Now : tarefa.DataCriacao;

        // Garantir que o texto da data apareça
        datePicker.TextColor = (Color)Application.Current.Resources["MarromEscuro"];

        // Preencher prioridade e garantir valor padrão
        pickerPrioridade.SelectedItem = string.IsNullOrEmpty(tarefa.Prioridade) ? "Normal" : tarefa.Prioridade;
    }

    private async void OnSalvarClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(entryTitulo.Text))
        {
            await DisplayAlert("Erro", "O título é obrigatório.", "OK");
            return;
        }

        // Atualizar os dados da tarefa original
        TarefaOriginal.Titulo = entryTitulo.Text;
        TarefaOriginal.Descricao = entryDescricao.Text;
        TarefaOriginal.DataCriacao = datePicker.Date;
        TarefaOriginal.Prioridade = pickerPrioridade.SelectedItem?.ToString() ?? "Normal";

        // Não é necessário disparar evento, o CollectionView vai atualizar automaticamente
        await Navigation.PopModalAsync();
    }

    private async void OnCancelarClicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}
