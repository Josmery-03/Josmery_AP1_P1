using Josmery_AP1_P1.Context;
using Josmery_AP1_P1.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Josmery_AP1_P1.Services;

public class AutoresService(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<bool> Guardar(Autores autores)
    {
        if (!await Existe(autores.IdAutores))
            return await Insertar(autores);
        else
            return await Modificar(autores);
    }

    private async Task<bool> Existe(int idAutores)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Autores
            .AnyAsync(a => a.IdAutores == idAutores);
    }

    private async Task<bool> Insertar(Autores autores)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Autores.Add(autores);
        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Autores autores)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Autores.Update(autores);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<Autores?> Buscar(int idAutores)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Autores
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.IdAutores == idAutores);
    }

    public async Task<bool> Eliminar(int idAutores)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Autores
            .Where(a => a.IdAutores == idAutores)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<List<Autores>> Listar(Expression<Func<Autores, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Autores
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<List<Autores>> ObtenerTodosAsync()
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Autores
            .AsNoTracking()
            .ToListAsync();
    }
}



