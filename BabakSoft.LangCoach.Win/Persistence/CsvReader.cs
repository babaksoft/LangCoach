using System.Text;
using BabakSoft.Platform.Common;

namespace BabakSoft.LangCoach.Persistence
{
    /// <summary>
    /// Provides operations and options required for reading bulk data from a
    /// Comma-Separated Values (CSV) file
    /// </summary>
    /// <remarks>As normal text may contain comma character, this class uses semicolon
    /// as the default column separator string.</remarks>
    public class CsvReader
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CsvReader"/> class
        /// </summary>
        /// <param name="columnSeparator">A string of one more characters that acts as delimiter
        /// for recognizing a column of data. Default is semicolon.</param>
        /// <param name="throwOnError">
        /// Indicates if operation must be aborted with an exception in case of any data file error,
        /// e.g. insufficient columns.
        /// </param>
        public CsvReader(string columnSeparator = ";", bool throwOnError = true)
        {
            ColumnSeparator = columnSeparator;
            ThrowOnError = throwOnError;
        }

        /// <summary>
        /// Gets the current delimiter for recognizing a column of data
        /// </summary>
        public string ColumnSeparator { get; }

        /// <summary>
        /// Gets a value that indicates if read operation should be sensitive to data file errors
        /// </summary>
        public bool ThrowOnError { get; }

        /// <summary>
        /// Reads and returns all data rows from a data file in the given path.
        /// </summary>
        /// <param name="path">Relative or absolute path of the data file</param>
        /// <param name="encoding">
        /// Text encoding of the data path. If not specified, defaults to UTF8.
        /// </param>
        /// <param name="hasHeading">
        /// Indicates if the first line in the given data file should be treated as heading row.
        /// If not specified, defaults to True.
        /// </param>
        /// <returns>Collection of all rows successfully read from given data file</returns>
        public IEnumerable<Dictionary<string, string>> ReadAllRows(
            string path, Encoding encoding = null, bool hasHeading = true)
        {
            Verify.FileExists(path);
            var textEncoding = encoding ?? Encoding.UTF8;
            var rows = File.ReadAllLines(path, textEncoding);
            if (rows.Length == 0)
            {
                return Enumerable.Empty<Dictionary<string, string>>();
            }

            var columnNames = GetColumnNames(rows[0], hasHeading);
            var dataRows = new List<Dictionary<string, string>>();
            int skipCount = hasHeading ? 1 : 0;
            int rowIndex = 1;
            foreach (var row in rows.Skip(skipCount))
            {
                dataRows.Add(BuildDataRow(rowIndex, row, columnNames));
                rowIndex++;
            }

            return dataRows;
        }

        private List<string> GetColumnNames(string row, bool hasHeading)
        {
            var columnNames = default(List<string>);
            var items = row.Split(ColumnSeparator, StringSplitOptions.RemoveEmptyEntries);
            if (hasHeading)
            {
                columnNames = new List<string>(items);
                if (columnNames.Count == 0 && ThrowOnError)
                {
                    string message = "No column headings could be found in data file.";
                    throw ExceptionBuilder.NewInvalidOperationException(message);
                }
            }
            else
            {
                int columnIndex = 1;
                columnNames = items
                    .Select(item => $"Column{columnIndex++}")
                    .ToList();
            }

            return columnNames;
        }

        private Dictionary<string, string> BuildDataRow(
            int rowIndex, string row, List<string> columnNames)
        {
            var items = new List<string>(row.Split(ColumnSeparator, StringSplitOptions.None));
            if (ThrowOnError && items.Count != columnNames.Count)
            {
                string message = $"Not enough columns could be found in row no. {rowIndex}.";
                throw ExceptionBuilder.NewInvalidOperationException(message);
            }

            int paddingCount = columnNames.Count - items.Count;
            for (int i = 0; i < paddingCount; i++)
            {
                items.Add(null);
            }

            var dataRow = new Dictionary<string, string>();
            for (int i = 0; i < columnNames.Count; i++)
            {
                dataRow[columnNames[i]] = items[i];
            }

            return dataRow;
        }
    }
}
