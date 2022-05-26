using System;

namespace Wizards.BusinessLogic
{
    public class ModelsMenagement
    {
        public void AddPlayer(Player playerToAdd)
        {
            throw new NotImplementedException();
        }
        
        public void AddHeroToPlayer(Hero heroToAdd, Player playerToAddFor)
        {
            playerToAddFor.Heroes.Add(heroToAdd);
        }

        public void AddItemToInventory(Item itemToAdd, Hero heroToAddFor)
        {
            heroToAddFor.Inventory.Add(itemToAdd);
        }

        public void ReplacePlayer(Player playerToReplace, Player newPlayer)
        {
            playerToReplace = newPlayer;
        }

        public void ReplaceHeroInPlayer(Hero heroToReplace, Hero newHero)
        {
            heroToReplace = newHero;
        }

        public void ReplaceItem(Item itemToReplace, Item newItem)
        {
            itemToReplace = newItem;
        }

        public void RemovePlayer(Player playerToRemove)
        {
            throw new NotImplementedException();
        }

        public void RemoveHeroFromPlayer(Hero heroToRemove, Player playerToRemoveFrom)
        {
            playerToRemoveFrom.Heroes.Remove(heroToRemove);
        }

        public void RemoveItemFromInventory(Item itemToRemove, Hero heroToRemoveFrom)
        {
            heroToRemoveFrom.Inventory.Remove(itemToRemove);
        }

    }
}