using Microsoft.EntityFrameworkCore;
using Wizards.Core.Interfaces;
using Wizards.Core.Model;
using Wizards.Core.Model.Enums;

namespace Wizards.Repository.Repository;

public class ItemRepository : IItemRepository

{
    private readonly WizardsContext _wizardsContext;

    public ItemRepository(WizardsContext wizardsContext)
    {
        _wizardsContext = wizardsContext;
    }

    public async Task Add(Item item)
    {
        await _wizardsContext.AddAsync(item);
        await _wizardsContext.SaveChangesAsync();
    }

    public async Task<bool> Exists(int id, string name)
    {
        return await _wizardsContext.Items.AnyAsync(i => i.Id == id && i.Name == name);
    }

    public async Task<Item?> Get(int id)
    {
        return await _wizardsContext.Items
            .Include(i => i.Attributes)
            .SingleOrDefaultAsync(i => i.Id == id);
    }

    public async Task<List<Item>> GetAll()
    {
        return await _wizardsContext.Items
            .Include(i => i.Attributes)
            .ToListAsync();
    }
    public async Task<List<Item>> GetAll(ProfessionRestriction professionRestriction)
    {
        return await _wizardsContext.Items
            .Include(i => i.Attributes)
            .Where(i => i.Restriction == professionRestriction)
            .ToListAsync();
    }

    public async Task<List<string>> GetAllNames()
    {
        return await _wizardsContext.Items.Select(i => i.Name).ToListAsync();
    }

    public async Task Remove(Item item)
    {
        _wizardsContext.Remove(item);
        await _wizardsContext.SaveChangesAsync();
    }

    public async Task Update(Item item)
    {
        _wizardsContext.Update(item);
        await _wizardsContext.SaveChangesAsync();
    }
}