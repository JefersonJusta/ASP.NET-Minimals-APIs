using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.interfaces;
using MinimalApi.DTOs;
using MinimalApi.Infraestrutura.Db;

namespace MinimalApi.Dominio.Servicos;

public class VeiculoServico : IVeiculoServico
{
    private readonly DbContexto _contexto;
    public VeiculoServico(DbContexto contexto)
    {
        _contexto = contexto;
    }

    public void Atualizar(Veiculo veiculo)
    {
        _contexto.Veiculos.Update(veiculo);
        _contexto.SaveChanges();
    }

    public Veiculo? BuscaPorId(int id)
    {
        return _contexto.Veiculos.Where(v => v.Id == id).FirstOrDefault();
    }

    public void Deletar(Veiculo veiculo)
    {
        _contexto.Veiculos.Remove(veiculo);
        _contexto.SaveChanges();
    }

    public void Incluir(Veiculo veiculo)
    {
        _contexto.Veiculos.Add(veiculo);
        _contexto.SaveChanges();
    }

   public List<Veiculo> Todos(int? pagina = 1, string? nome = null, string? marca = null)
{
    var query = _contexto.Veiculos.AsQueryable();

    // Filtro pelo nome, com case insensitive usando ToLower
    if (!string.IsNullOrEmpty(nome))
    {
        query = query.Where(v => EF.Functions.Like(v.Nome.ToLower(), $"%{nome.ToLower()}%"));
    }

    // Filtro pela marca, se necessário
    if (!string.IsNullOrEmpty(marca))
    {
        query = query.Where(v => EF.Functions.Like(v.Marca.ToLower(), $"%{marca.ToLower()}%"));
    }

    // Paginação
    int itensPorPagina = 10;
    int paginaCorrente = Math.Max(0, (pagina ?? 1) - 1); // Ajusta página para valores válidos
    query = query.Skip(paginaCorrente * itensPorPagina).Take(itensPorPagina);

    // Retorna a lista final
    return query.ToList();
}
}