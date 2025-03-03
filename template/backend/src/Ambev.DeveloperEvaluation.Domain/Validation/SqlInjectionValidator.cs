using FluentValidation;
using System.Text.RegularExpressions;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class SqlInjectionValidator : AbstractValidator<string>
{
    public SqlInjectionValidator()
    {
        RuleFor(currentInput => currentInput)
            .Must(NotContainSqlInjection)
            .WithMessage("Suspicious value detected in field!");
    }

    private bool NotContainSqlInjection(string inputValue)
    {
        if (string.IsNullOrWhiteSpace(inputValue))
            return true;

        string[] sqlInjectionPatterns =
            [
                @"--",@"\bSELECT\b", @"\bINSERT\b", @"\bUPDATE\b", @"\bDELETE\b",
                @"\bDROP\b", @"\bALTER\b", @"\bEXEC\b", @"\bUNION\b", @"\bCREATE\b",
                @"\bTRUNCATE\b", @"\bGRANT\b", @"\bREVOKE\b", @"\bDECLARE\b",
                @"\bXP_CMDSHELL\b", @"\bINFORMATION_SCHEMA\b", @"\bWHERE\b", @"\bHAVING\b",
                @"[;']",
            ];

        return
            !sqlInjectionPatterns.Any(pattern => Regex.IsMatch(inputValue, pattern, RegexOptions.IgnoreCase));
    }
}