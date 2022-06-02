using System;
using System.Linq;
using Wizards.BusinessLogic.Model.Items;

namespace Wizards.BusinessLogic
{
    public class EquipmentMenagement
    {
        private Hero _hero;

        public EquipmentMenagement(Hero hero)
        {
            _hero = hero;
        }
        public void EquipItem(Item itemToEquip)
        {
            if (_hero == null || itemToEquip == null)
                return;

            if (!_hero.Inventory.Contains(itemToEquip))
                return;

            // TODO sprawdź czy gracz może założyć item

            if (IsEquippedItemTypeOf(itemToEquip))
            {
                UnequipItem(GetEquippedItemTypeOf(itemToEquip));
            }

            if (_hero.Equipped.Count < 2)
            {
                _hero.Equipped.Add(itemToEquip);
                _hero.Inventory.Remove(itemToEquip);
            }

            SortEquipment(_hero);
        }

        private Item GetEquippedItemTypeOf(Item itemToEquip)
        {
            if (itemToEquip is Weapon)
            {
                return _hero.Equipped.FirstOrDefault(i => i is Weapon);
            }

            if (itemToEquip is Armor)
            {
                return _hero.Equipped.FirstOrDefault(i => i is Armor);
            }

            return null;
        }

        private bool IsEquippedItemTypeOf(Item itemToEquip)
        {
            var isWeapon = itemToEquip is Weapon;
            var hasEquippedWeapon = _hero.Equipped.Any(i => i is Weapon);

            if (hasEquippedWeapon && isWeapon)
            {
                return true;
            }

            var isArmor = itemToEquip is Armor;
            var hasEquippedArmor = _hero.Equipped.Any(i => i is Armor);
            if (hasEquippedArmor && isArmor)
            {
                return true;
            }

            return false;
        }

        public void UnequipItem(Item itemToUnequip)
        {
            if (_hero == null || itemToUnequip == null)
                return;

            if (_hero.Equipped.Any(i => i == itemToUnequip))
            {
                _hero.Inventory.Add(itemToUnequip);
                _hero.Equipped.Remove(itemToUnequip);
            }
        }

        public void SortEquipment(Hero hero)
        {
            hero.Equipped = hero.Equipped.OrderBy(i => i.Name).ToList();
        }

    }
}
