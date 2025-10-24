using System.Text.Json;

namespace TicketFlowApi.Utils;
public class JsonSnakeCaseNamingPolicy : JsonNamingPolicy
{
    public override string ConvertName(string name)
    {
        if (string.IsNullOrEmpty(name))
            return name;

        var snakeCase = new System.Text.StringBuilder();
        for (int i = 0; i < name.Length; i++)
        {
            char c = name[i];
            if (char.IsUpper(c))
            {
                if (i > 0)
                    snakeCase.Append('_');
                snakeCase.Append(char.ToLowerInvariant(c));
            }
            else
            {
                snakeCase.Append(c);
            }
        }
        return snakeCase.ToString();
    }
}
