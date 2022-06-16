namespace Wizards.BusinessLogic.Services.ModelsValidation.ValidationTasks
{
    public interface INumberValidationTask
    {
        ValidationState Validate(int value);
        ValidationState Validate(double value);
        ValidationState Validate(decimal value);
    }
}