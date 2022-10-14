namespace Wizards.LogsSender.Models;

public class ArgumentRecord
{
    public int Number { get; set; }
    public string ObjectType { get; set; }
    public string JsonSerializedObject { get; set; }
}