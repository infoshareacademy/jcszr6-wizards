using Wizards.Repository.TextRepo;
using Wizards.Repository.TextRepo.Enums;

namespace Wizards.Services.Validation.Elements;

public class ValidationState
{
    public bool IsValid { get; private set; }
    public string Message { get; private set; }

    public ValidationState(bool isValid, string message)
    {
        IsValid = isValid;
        Message = message;
    }

    public ValidationState(bool isValid)
    {
        IsValid = isValid;
        Message = TextRepository.Get(ValueErrorsMsg.Default);
    }
}