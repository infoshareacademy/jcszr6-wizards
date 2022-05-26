using System;

namespace Wizards.BusinessLogic
{
    internal class EquipmentMenagement
    {
        public void EquipItem(Hero hero, Item itemToEquip)
        {
            // TODO sprawdź czy item jest w inventorze gracza
            // TODO sprawdź czy gracz może założyć item
            // TODO sprawdź czy gracz ma już założony item tego typu (np staff)
            //      jeśli trzeba to podmień item jeśli nie to przenieś z inventory do equipped.
            throw new NotImplementedException();
        }

        public void UnequipItem(Hero hero, Item itemToUnequip)
        {
            throw new NotImplementedException();
        }

        public void SortEquipment(Hero hero)
        {
            throw new NotImplementedException();
        }

    }
}
