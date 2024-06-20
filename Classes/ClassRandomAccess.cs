using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit_5_CSharp.Interface;

namespace Unit_5_CSharp.Classes
{
    internal class ClassRandomAccess : IOrganization
    {
        public int Count => organizationsHash.Count;
        private Hash organizationsHash;

        public ClassRandomAccess()
        {
            organizationsHash = new Hash();
        }

        public void Add(Student alumno)
        {
            organizationsHash.Add(alumno);

            Update();
        }

        public void Delete(int id)
        {
            organizationsHash.Delete(id);

            Update();
        }

        public void Search(int id, DataGridView dataGridView)
        {
            organizationsHash.Search(id, dataGridView);
        }

        public void Edit(int id, Student nuevoAlumno)
        {
            organizationsHash.Edit(id, nuevoAlumno);
        }

        public void Show(DataGridView dataGridView)
        {
            organizationsHash.Show(dataGridView);
        }

        private void Update()
        {
            organizationsHash.Update();
        }

    }
}
