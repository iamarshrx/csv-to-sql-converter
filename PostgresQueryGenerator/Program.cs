using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter input CSV file path:");
        string inputPath = Console.ReadLine();

        Console.WriteLine("Enter output SQL file path:");
        string outputPath = Console.ReadLine();

        Console.WriteLine("Enter table name:");
        string tableName = Console.ReadLine();

        try
        {
            string[] lines = File.ReadAllLines(inputPath);
            string[] headers = lines[0].Split(',');

            if (!outputPath.EndsWith(".sql"))
            {
                outputPath = Path.Combine(outputPath, $"{tableName}.sql");
            }

            // Create directory if it doesn't exist
            string directory = Path.GetDirectoryName(outputPath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            using (StreamWriter writer = new StreamWriter(outputPath))
            {
                for (int i = 1; i < lines.Length; i++)
                {
                    string[] values = lines[i].Split(',');
                    string query = GenerateInsertQuery(tableName, headers, values);
                    writer.WriteLine(query);
                }
            }

            Console.WriteLine("SQL file generated successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }

    


    static string GenerateInsertQuery(string tableName, string[] headers, string[] values)
    {
        string columns = string.Join(", ", Array.ConvertAll(headers, h => $"\"{h.Trim('\"')}\""));

        // Convert empty strings to NULL for UUID columns
        for (int i = 0; i < values.Length; i++)
        {
            if (values[i] == "" && headers[i].EndsWith("Id"))
            {
                values[i] = "NULL";
             
            }
            else
            {
                // Remove double quotes from values
                values[i] = values[i].Trim('"');
                values[i] = $"'{values[i]}'";
            }
        }

        string valueStr = string.Join(", ", values);
        return $"INSERT INTO \"{tableName}\" ({columns}) VALUES ({valueStr});";
    }

}