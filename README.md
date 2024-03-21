

# CSV to SQL Converter

This tool converts CSV (Comma Separated Values) files into SQL (Structured Query Language) INSERT statements. It's useful for converting CSV data into SQL database import scripts.

## Features

- Converts CSV files into SQL INSERT statements
- Handles empty values, generating appropriate NULL values in SQL
- Supports generating GUIDs for empty UUID fields
- Command-line interface for easy usage

## How to Use

1. **Clone the Repository**:

git clone https://github.com/your-username/csv-to-sql-converter.git


2. **Navigate to the Project Directory**:

cd csv-to-sql-converter


3. **Compile and Run the Program**:

dotnet run


4. **Follow the Prompts**:
- Enter the path to the input CSV file.
- Enter the path for the output SQL file.
- Enter the table name for the SQL INSERT statements.

5. **Generated SQL File**:
- After providing the necessary inputs, the program will generate an SQL file containing the INSERT statements based on the provided CSV file.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

## Contributing

Contributions are welcome! Feel free to submit issues and pull requests to suggest improvements, report bugs, or add new features.

## Acknowledgements

- This project was created by [Your Name] and is maintained by contributors.
