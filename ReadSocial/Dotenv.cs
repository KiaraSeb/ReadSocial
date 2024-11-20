public static class DotEnvLoader
{
    public static void Load(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine($"El archivo {filePath} no existe.");
            return;
        }

        foreach (var line in File.ReadAllLines(filePath))
        {
            var parts = line.Split(
                '=',
                StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length != 2)
            {
                Console.WriteLine($"La línea '{line}' no es válida y será ignorada.");
                continue;
            }

            Environment.SetEnvironmentVariable(parts[0], parts[1]);
        }
    }
}