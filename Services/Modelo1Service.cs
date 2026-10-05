using Microsoft.EntityFrameworkCore;
using Josmery_AP1_P1.Context;
using Josmery_AP1_P1.Models;

namespace Josmery_AP1_P1.Services;

public class Modelo1Service
{
    private readonly Contexto _context;

    public Modelo1Service(Contexto context)
    {
        _context = context;
    }
    public async Task<List<Autores>> ObtenerTodosAsync()
    {
        return await _context.Modelo1.AsNoTracking().ToListAsync();
    }
    public async Task<bool> CrearAsync(Autores modelo)
    {
        _context.Modelo1.Add(modelo);
        return await _context.SaveChangesAsync() > 0;
    }
}