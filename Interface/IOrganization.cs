using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit_5_CSharp.Classes;
using System.Windows.Forms;

namespace Unit_5_CSharp.Interface
{
    public interface IOrganization
    {
        int Count { get; }
        void Add(Student alumno);
        void Delete(int id);
        void Search(int id, DataGridView dataGridView);
        void Edit(int id, Student nuevoAlumno);
        void Show(DataGridView dataGridView);
    }
}
