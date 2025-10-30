/*
Autores:
Atilio Almeida Costa
CB3025497
João Victor Crivoi Cesar Sousa
CB3062027
*/
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using PackageTraking.Models;

namespace PackageTraking.Services
{
    // Servico mock que simula uma busca de rastreamento com eventos especificos por codigo
    public class MockTrackingService : ITrackingService
    {
        public Task<Package?> GetPackageAsync(string trackingCode)
        {
            if (string.IsNullOrWhiteSpace(trackingCode))
                return Task.FromResult<Package?>(null);

            var code = trackingCode.Trim().ToUpperInvariant();
            var now = DateTime.Now;

            Package pkg = code switch
            {
                "PKG001" => new Package
                {
                    Id = "PKG001",
                    Status = "Em transito",
                    ShippedDate = now.AddDays(-5),
                    ExpectedDelivery = now.AddDays(2),
                    CurrentLocation = "Centro de distribuicao - Sao Paulo",
                    Events = new ObservableCollection<TrackingEvent>
                    {
                        new TrackingEvent { Date = now.AddDays(-5).AddHours(8), Location = "Origem - Sao Paulo", Description = "Remetente despachou o pacote" },
                        new TrackingEvent { Date = now.AddDays(-4), Location = "Centro de triagem - Sao Paulo", Description = "Pacote recebido para triagem" },
                        new TrackingEvent { Date = now.AddDays(-3), Location = "Hub regional - Campinas", Description = "Encaminhado para rota de longa distancia" },
                        new TrackingEvent { Date = now.AddDays(-1), Location = "Centro de distribuicao - Sao Paulo", Description = "Chegou ao centro de distribuicao" }
                    }
                },

                "PKG002" => new Package
                {
                    Id = "PKG002",
                    Status = "Em transito",
                    ShippedDate = now.AddDays(-3),
                    ExpectedDelivery = now.AddDays(1),
                    CurrentLocation = "Centro de distribuicao - Rio de Janeiro",
                    Events = new ObservableCollection<TrackingEvent>
                    {
                        new TrackingEvent { Date = now.AddDays(-3).AddHours(9), Location = "Origem - Niteroi", Description = "Coleta realizada pelo transportador" },
                        new TrackingEvent { Date = now.AddDays(-2), Location = "Centro de triagem - Rio de Janeiro", Description = "Pacote processado e etiquetado" },
                        new TrackingEvent { Date = now.AddDays(-1), Location = "Em rota intermunicipal", Description = "Pacote em translado para regiao sul" },
                        new TrackingEvent { Date = now, Location = "Centro de distribuicao - Rio de Janeiro", Description = "Em transito interno" }
                    }
                },

                "PKG003" => new Package
                {
                    Id = "PKG003",
                    Status = "Pronto para entrega",
                    ShippedDate = now.AddDays(-2),
                    ExpectedDelivery = now,
                    CurrentLocation = "Filial local - Salvador",
                    Events = new ObservableCollection<TrackingEvent>
                    {
                        new TrackingEvent { Date = now.AddDays(-2).AddHours(7), Location = "Origem - Feira de Santana", Description = "Pedido despachado" },
                        new TrackingEvent { Date = now.AddDays(-1), Location = "Centro de triagem - Salvador", Description = "Triagem concluida" },
                        new TrackingEvent { Date = now.AddHours(-6), Location = "Filial local - Salvador", Description = "Pronto para entrega ao cliente" },
                        new TrackingEvent { Date = now.AddHours(-1), Location = "Veiculo de entrega - Salvador", Description = "Saiu para entrega" }
                    }
                },

                "PKG004" => new Package
                {
                    Id = "PKG004",
                    Status = "Entregue",
                    ShippedDate = now.AddDays(-10),
                    ExpectedDelivery = now.AddDays(-5),
                    CurrentLocation = "Destino - Belo Horizonte",
                    Events = new ObservableCollection<TrackingEvent>
                    {
                        new TrackingEvent { Date = now.AddDays(-10).AddHours(10), Location = "Origem - Vitoria", Description = "Remetente despachou o pacote" },
                        new TrackingEvent { Date = now.AddDays(-8), Location = "Centro de triagem - Vitoria", Description = "Pacote em transito" },
                        new TrackingEvent { Date = now.AddDays(-6), Location = "Centro de distribuicao - Belo Horizonte", Description = "Chegou ao destino regional" },
                        new TrackingEvent { Date = now.AddDays(-5).AddHours(14), Location = "Endereco do destinatario - Belo Horizonte", Description = "Entregue e recebido pelo destinatario" }
                    }
                },

                "PKG005" => new Package
                {
                    Id = "PKG005",
                    Status = "Em transito",
                    ShippedDate = now.AddDays(-1),
                    ExpectedDelivery = now.AddDays(4),
                    CurrentLocation = "Centro de distribuicao - Curitiba",
                    Events = new ObservableCollection<TrackingEvent>
                    {
                        new TrackingEvent { Date = now.AddDays(-1).AddHours(11), Location = "Origem - Curitiba", Description = "Etiqueta gerada e pronto para coleta" },
                        new TrackingEvent { Date = now.AddHours(-20), Location = "Coleta - Curitiba", Description = "Pacote coletado pelo transportador" },
                        new TrackingEvent { Date = now.AddHours(-5), Location = "Centro de triagem - Curitiba", Description = "Pacote em processamento" },
                        new TrackingEvent { Date = now, Location = "Centro de distribuicao - Curitiba", Description = "Aguardando consolidacao de rota" }
                    }
                },

                _ => null
            };

            return Task.FromResult(pkg);
        }
    }
}