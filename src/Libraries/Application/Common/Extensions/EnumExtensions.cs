using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ContractorDocuments.Application.Common.Extensions;

public static class EnumExtensions
{
#nullable enable
    public static string ToDisplay(this Enum value, DisplayProperty property = DisplayProperty.Name)
    {
        Assert.NotNull(value, nameof(value));
        List<string> messages = new List<string>(); ;

        FieldInfo? fieldInfo = value.GetType()
            .GetField(value.ToString());
        if (fieldInfo == null)
            return messages[0];

        var attribute = fieldInfo
            .GetCustomAttributes<DisplayAttribute>(false).FirstOrDefault();
        if (attribute == null)
            return messages[0];

        PropertyInfo? propertyInfo = attribute.GetType()
            .GetProperty(property.ToString());

        if (propertyInfo == null)
            return messages[0];

        object? propValue = propertyInfo.GetValue(attribute, null);
        if (propValue == null)
            return string.Empty;

        string? propValueStr = propValue.ToString();
        if (string.IsNullOrEmpty(propValueStr))
            return string.Empty;

        return propValueStr;
    }

    public static List<string> ToDisplays(this Enum value, DisplayProperty property = DisplayProperty.Name)
    {
        Assert.NotNull(value, nameof(value));
        List<string> Messages = new List<string>();

        FieldInfo? fieldInfo = value.GetType().GetField(value.ToString());
        if (fieldInfo == null)
            return Messages;

        DisplayAttribute? attribute = fieldInfo
            .GetCustomAttributes<DisplayAttribute>(false).FirstOrDefault();
        if (attribute == null)
            return Messages;

        PropertyInfo? propertyInfo = attribute.GetType().GetProperty(property.ToString());
        if (propertyInfo == null)
            return Messages;

        object? propValue = propertyInfo.GetValue(attribute, null);
        if (propValue != null)
        {
            string? valueStr = propValue.ToString();
            if (!string.IsNullOrWhiteSpace(valueStr))
                Messages.Add(valueStr);
        }

        return Messages;
    }
}

public enum DisplayProperty
{
    Description,
    GroupName,
    Name,
    Prompt,
    ShortName,
    Order
}