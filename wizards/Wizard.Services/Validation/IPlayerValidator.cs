namespace Wizards.Services.Validation
{
    public interface IPlayerValidator
    {
        void ValidateForCreate(Core.Model.Player player);
        void ValidateForUpdate(Core.Model.Player player);
        void ValidateForPasswordUpdate(Core.Model.Player player);
    }
}