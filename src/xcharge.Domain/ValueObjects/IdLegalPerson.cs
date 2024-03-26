namespace xcharge.Domain.ValueObjects;

public record IdLegalPerson(string? Cnpj, string? StateRegistration, string? CityRegistration)
{
    public static bool IsValidCnpj(string? cnpj)
    {
        if (string.IsNullOrEmpty(cnpj))
        {
            return false;
        }

        // Remove any non-digit characters
        cnpj = new string(cnpj.Where(char.IsDigit).ToArray());

        // CNPJ must have 14 characters
        if (cnpj.Length != 14)
            return false;

        // Verifying digits
        int[] digits = new int[14];
        for (int i = 0; i < 14; i++)
        {
            digits[i] = int.Parse(cnpj[i].ToString());
        }

        // Computing first verification digit
        int sum = 0;
        for (int i = 0, j = 5; i < 12; i++)
        {
            sum += digits[i] * j--;
            if (j < 2)
                j = 9;
        }
        int mod = sum % 11;
        int digit1 = (mod < 2) ? 0 : (11 - mod);

        // Computing second verification digit
        sum = 0;
        for (int i = 0, j = 6; i < 13; i++)
        {
            sum += digits[i] * j--;
            if (j < 2)
                j = 9;
        }
        mod = sum % 11;
        int digit2 = (mod < 2) ? 0 : (11 - mod);

        // Check if computed digits match the provided CNPJ
        return (digits[12] == digit1 && digits[13] == digit2);
    }
}
