using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_5_CSharp.Classes
{
    static class Open_Save
    {
        static public void GetFileExtension(bool isOpen, ref string filePath, DataGridView ListFilesData)
        {
            if (isOpen)
            {
                switch (Path.GetExtension(filePath).ToLower())
                {
                    case ".csv":
                        OpenFileCSV(ref filePath, ListFilesData);
                        break;
                }
            }
            else
            {
                switch (Path.GetExtension(filePath).ToLower())
                {
                    case ".csv":
                        SaveFileCSV(ref filePath, ListFilesData);
                        break;
                }
            }
        }

        static public void OpenFileCSV(ref string filePath, DataGridView ListFilesData)
        {
            using (var CSVReader = new StreamReader(filePath))
            {
                string primeraLinea = CSVReader.ReadLine();

                if (primeraLinea == null)
                {
                    return;
                }

                string[] encabezados = primeraLinea.Split(',');

                ListFilesData.Columns.Clear();

                foreach (var encabezado in encabezados)
                {
                    ListFilesData.Columns.Add(encabezado, encabezado);
                }

                while (!CSVReader.EndOfStream)
                {
                    string line = CSVReader.ReadLine();
                    string[] propertyless = line.Split(',');

                    ListFilesData.Rows.Add(propertyless);
                }

                MessageBox.Show("Data uploaded from the CSV file successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        static public void SaveFileCSV(ref string filePath, DataGridView ListFilesData)
        {
            using (var CSVwriter = new StreamWriter(filePath))
            {
                for (int i = 0; i < ListFilesData.Columns.Count; i++)
                {
                    CSVwriter.Write(ListFilesData.Columns[i].HeaderText);

                    if (i < ListFilesData.Columns.Count - 1)
                    {
                        CSVwriter.Write(",");
                    }
                }

                CSVwriter.WriteLine();

                for (int i = 0; i < ListFilesData.Rows.Count; i++)
                {
                    for (int j = 0; j < ListFilesData.Columns.Count; j++)
                    {
                        CSVwriter.Write(ListFilesData.Rows[i].Cells[j].Value);

                        if (j < ListFilesData.Columns.Count - 1)
                        {
                            CSVwriter.Write(",");
                        }
                    }

                    CSVwriter.WriteLine();
                }
            }

            MessageBox.Show("CSV file saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
