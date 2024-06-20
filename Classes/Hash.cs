using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit_5_CSharp.Interface;

namespace Unit_5_CSharp.Classes
{
    internal class Hash : IOrganization
    {
        public int Count => hashTable.Count;
        private Dictionary<int, Student> hashTable;

        public Hash()
        {
            hashTable = new Dictionary<int, Student>();
        }

        public void Add(Student alumno)
        {
            hashTable.Add(alumno.Id, alumno);

            Update();
        }

        public void Delete(int id)
        {
            if (hashTable.ContainsKey(id))
            {
                hashTable.Remove(id);

                Update();
            }
        }

        public void Search(int id, DataGridView dataGridView)
        {
            dataGridView.Rows.Clear();

            if (hashTable.TryGetValue(id, out Student alumnoEncontrado))
            {
                dataGridView.Rows.Add(alumnoEncontrado.Id, alumnoEncontrado.Name, alumnoEncontrado.LastName, alumnoEncontrado.Unit1, alumnoEncontrado.Unit2, alumnoEncontrado.Unit3, alumnoEncontrado.Average);
            }
        }

        public void Edit(int id, Student nuevoAlumno)
        {
            if (hashTable.ContainsKey(id))
            {
                hashTable[id] = nuevoAlumno;
            }
        }

        public void Show(DataGridView dataGridView)
        {
            dataGridView.Rows.Clear();

            foreach (var alumno in hashTable.Values)
            {
                dataGridView.Rows.Add(alumno.Id, alumno.Name, alumno.LastName, alumno.Unit1, alumno.Unit2, alumno.Unit3, alumno.Average);
            }
        }

        public void Update()
        {
            int id = 0;
            foreach (var alumno in hashTable.Values)
            {
                alumno.Id = id++;
            }
        }

    }
}
