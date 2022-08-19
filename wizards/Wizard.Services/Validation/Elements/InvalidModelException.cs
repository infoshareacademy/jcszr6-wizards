using System.Runtime.Serialization;

namespace Wizards.Services.Validation.Elements;

[Serializable]
public class InvalidModelException : Exception
{
    public Dictionary<string, string> ModelStatesData { get; set; }

    public InvalidModelException(Dictionary<string, string> modelStatesData)
    {
        ModelStatesData = modelStatesData;
    }

    public InvalidModelException()
    {
    }

    public InvalidModelException(string message) : base(message)
    {
    }

    public InvalidModelException(string message, Exception inner) : base(message, inner)
    {
    }

    protected InvalidModelException(
        SerializationInfo info,
        StreamingContext context) : base(info, context)
    {
    }
}