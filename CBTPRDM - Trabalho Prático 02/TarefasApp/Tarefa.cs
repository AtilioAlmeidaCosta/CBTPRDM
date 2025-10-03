using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TarefasApp;

public class Tarefa : INotifyPropertyChanged
{
    private string titulo;
    private string descricao;
    private DateTime dataCriacao;
    private string prioridade;

    public string Titulo
    {
        get => titulo;
        set { titulo = value; OnPropertyChanged(); }
    }

    public string Descricao
    {
        get => descricao;
        set { descricao = value; OnPropertyChanged(); }
    }

    public DateTime DataCriacao
    {
        get => dataCriacao;
        set { dataCriacao = value; OnPropertyChanged(); }
    }

    public string Prioridade
    {
        get => prioridade;
        set { prioridade = value; OnPropertyChanged(); }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    private void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
