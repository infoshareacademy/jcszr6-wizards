namespace Wizards.BusinessLogic.Services.ModelsValidation
{
    public interface IPlayerValidator
    {
        void ValidateForCreate(Player player);
        void ValidateForUpdate(Player player);
        void ValidateForPasswordUpdate(Player player);
    }
}