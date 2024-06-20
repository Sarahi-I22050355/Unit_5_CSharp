using Unit_5_CSharp.Classes;
using Unit_5_CSharp.Interface;

namespace Unit_5_CSharp
{
    public partial class Form1 : Form
    {
        public string filePath;
        public IOrganization Students;

        public Form1()
        {
            InitializeComponent();
            Students = new Sequential();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            if (NombreTXTisNull() && ApellidoTXTisNull())
            {
                return;
            }

            if (Unidad1TXTisNull() && Unidad2TXTisNull() && Unidad3TXTisNull())
            {
                return;
            }

            var alumno = new Student();

            alumno.Id = ListFilesData.RowCount;
            alumno.Name = NombreTXT.Text;
            alumno.LastName = ApellidoTXT.Text;
            alumno.Unit1 = int.Parse(Unidad1TXT.Text);
            alumno.Unit2 = int.Parse(Unidad2TXT.Text);
            alumno.Unit3 = int.Parse(Unidad3TXT.Text);

            Students.Add(alumno);

            ListFilesData.Rows.Add(alumno.Id, alumno.Name, alumno.LastName, alumno.Unit1, alumno.Unit2, alumno.Unit3, alumno.Average);

            IDTXT.Clear();
            NombreTXT.Clear();
            ApellidoTXT.Clear();
            Unidad1TXT.Clear();
            Unidad2TXT.Clear();
            Unidad3TXT.Clear();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (int.TryParse(IDTXT.Text, out int IdDelete))
            {
                Students.Delete(IdDelete);
            }
            else if (Students.Count > 0)
            {
                Students.Delete(Students.Count - 1);
            }
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            if (int.TryParse(IDTXT.Text, out int IdEdit))
            {
                var alumno = new Student();

                alumno.Name = NombreTXT.Text;
                alumno.LastName = ApellidoTXT.Text;
                alumno.Unit1 = int.Parse(Unidad1TXT.Text);
                alumno.Unit2 = int.Parse(Unidad2TXT.Text);
                alumno.Unit3 = int.Parse(Unidad3TXT.Text);

                Students.Edit(IdEdit, alumno);

                IDTXT.Clear();
                NombreTXT.Clear();
                ApellidoTXT.Clear();
                Unidad1TXT.Clear();
                Unidad2TXT.Clear();
                Unidad3TXT.Clear();
            }
        }

        private void Search_Click(object sender, EventArgs e)
        {
            if (int.TryParse(IDTXT.Text, out int IdSearch))
            {
                ListFilesData.Rows.Clear();

                Students.Search(IdSearch, ListFilesData);

                IDTXT.Clear();
            }
        }

        private void ShowAll_Click(object sender, EventArgs e)
        {
            ListFilesData.Rows.Clear();

            Students.Show(ListFilesData);
        }

        private void SequenciesMenuItem_Click(object sender, EventArgs e)
        {
            Students = new Sequential();

            Students.Show(ListFilesData);
        }

        private void HashMenuItem_Click(object sender, EventArgs e)
        {
            Students = new Hash();

            Students.Show(ListFilesData);
        }

        private void AccesoAleatorioMenuItem_Click(object sender, EventArgs e)
        {
            Students = new ClassRandomAccess();

            Students.Show(ListFilesData);
        }

        public bool Dialog(bool IsOpenOrSave, ref string filePath, string filter)
        {
            if (IsOpenOrSave)
            {
                var fileDialog = new OpenFileDialog
                {
                    Filter = filter
                };

                if (fileDialog.ShowDialog() != DialogResult.OK)
                {
                    return true;
                }

                filePath = fileDialog.FileName;

                return false;
            }
            else
            {
                var saveFileTem = new SaveFileDialog { Filter = filter };

                if (saveFileTem.ShowDialog() != DialogResult.OK)
                {
                    MessageBox.Show($"Operation Cancelled by the user", "Cancelled operation", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    return true;
                }

                filePath = saveFileTem.FileName;

                return false;
            }
        }

        private void OpenMenuItem_Click(object sender, EventArgs e)
        {
            ListFilesData.Rows.Clear();
            ListFilesData.Columns.Clear();

            if (Dialog(true, ref filePath, "Archivos CSV (*.csv)|*.csv"))
            {
                return;
            }

            Open_Save.GetFileExtension(true, ref filePath, ListFilesData);
        }

        private void SaveMenuItem_Click(object sender, EventArgs e)
        {
            if (ListFilesData.Rows.Count == 0)
            {
                MessageBox.Show("No data to save.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(filePath))
            {
                if (Dialog(false, ref filePath, "Archivos CSV (*.csv)|*.csv"))
                {
                    return;
                }

                Open_Save.GetFileExtension(false, ref filePath, ListFilesData);
            }
            else
            {
                Open_Save.GetFileExtension(false, ref filePath, ListFilesData);
            }
        }

        private void SaveHowMenuItem_Click(object sender, EventArgs e)
        {
            if (ListFilesData.Rows.Count == 0)
            {
                MessageBox.Show("No data to save.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Dialog(false, ref filePath, "Archivos CSV (*.csv)|*.csv"))
            {
                return;
            }

            Open_Save.GetFileExtension(false, ref filePath, ListFilesData);
        }

        public bool NombreTXTisNull()
        {
            return string.IsNullOrEmpty(NombreTXT.Text);
        }

        public bool ApellidoTXTisNull()
        {
            return string.IsNullOrEmpty(ApellidoTXT.Text);
        }

        public bool Unidad1TXTisNull()
        {
            return string.IsNullOrEmpty(Unidad1TXT.Text);
        }

        public bool Unidad2TXTisNull()
        {
            return string.IsNullOrEmpty(Unidad2TXT.Text);
        }

        public bool Unidad3TXTisNull()
        {
            return string.IsNullOrEmpty(Unidad3TXT.Text);
        }
    }
}