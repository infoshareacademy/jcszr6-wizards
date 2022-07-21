using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wizards.Core.Interfaces;
using Wizards.Core.Model;

namespace Wizards.Repository.Repository
{
    internal class ItemRepository : IItemRepository

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

        public async Task<Item> Get(int id)
        {
            return await _wizardsContext.Items.SingleOrDefaultAsync(i => i.Id == id);
        }

        public async Task<List<Item>> GetAll()
        {
            return await _wizardsContext.Items.ToListAsync();
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
}
