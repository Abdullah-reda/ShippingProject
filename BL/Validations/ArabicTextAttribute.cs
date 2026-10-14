
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

public class ArabicTextAttribute : ValidationAttribute, IClientModelValidator
{
    public override bool IsValid(object? value)
    {
        if (value == null)
            return true;

        string text = value.ToString()!;

        foreach (char c in text)
        {
            if (char.IsLetter(c))
            {
                string name = char.GetUnicodeCategory(c).ToString();

                // Accept Arabic letters only
                if (c < '\u0600' || c > '\u06FF')
                    return false;
            }
            else if (!char.IsWhiteSpace(c))
            {
                return false;
            }
        }

        return true;
    }


    public void AddValidation(ClientModelValidationContext context)
    {
        context.Attributes.TryAdd("data-val", "true");

        context.Attributes.TryAdd(
            "data-val-arabictext",
            ErrorMessage ?? "Please enter Arabic letters only."
        );
    }
}
