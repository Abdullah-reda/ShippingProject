
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

public class EnglishTextAttribute : ValidationAttribute, IClientModelValidator
{
    public override bool IsValid(object? value)
    {
        if (value == null)
            return true;

        string text = value.ToString()!;

        foreach (char c in text)
        {
            char upper = char.ToUpperInvariant(c);

            if ((upper >= 'A' && upper <= 'Z') ||
                (c >= '0' && c <= '9') ||
                c == '-' ||
                char.IsWhiteSpace(c))
            {
                continue;
            }

            return false;
        }

        return true;
    }

    public void AddValidation(ClientModelValidationContext context)
    {
        context.Attributes.TryAdd("data-val", "true");

        context.Attributes.TryAdd(
            "data-val-englishtext",
            ErrorMessage ?? "Enter English letters, numbers, spaces, or hyphens only."
        );
    }
}
