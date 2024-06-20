using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit_5_CSharp.Interface;
using System.Windows.Forms;

namespace Unit_5_CSharp.Classes
{
    internal class Sequential : IOrganization
    {
        public int Count => alumnos.Count;
        private List<Student> alumnos;

        public Sequential()
        {
            alumnos = new List<Student>();
        }

        public void Add(Student alumno)
        {
            alumnos.Add(alumno);

            Update();
        }

        public void Delete(int id)
        {
            Student alumno = alumnos.Find(a => a.Id == id);
            if (alumno != null)
            {
                alumnos.Remove(alumno);

                Update();
            }
        }

        public void Search(int id, DataGridView dataGridView)
        {
            dataGridView.Rows.Clear();

            Student alumnoEncontrado = alumnos.Find(a => a.Id == id);
            if (alumnoEncontrado != null)
            {
                dataGridView.Rows.Add(alumnoEncontrado.Id, alumnoEncontrado.Name, alumnoEncontrado.LastName, alumnoEncontrado.Unit1, alumnoEncontrado.Unit2, alumnoEncontrado.Unit3, alumnoEncontrado.Average);
            }
        }

        public void Edit(int id, Student nuevoAlumno)
        {
            int index = alumnos.FindIndex(a => a.Id == id);
            if (index != -1)
            {
                alumnos[index] = nuevoAlumno;
            }
        }

        public void Show(DataGridView dataGridView)
        {
            dataGridView.Rows.Clear();

            foreach (var alumno in alumnos)
            {
                dataGridView.Rows.Add(alumno.Id, alumno.Name, alumno.LastName, alumno.Unit1, alumno.Unit2, alumno.Unit3, alumno.Average);
            }
        }

        private void Update()
        {
            for (int i = 0; i < alumnos.Count; i++)
            {
                alumnos[i].Id = i;
            }
        }
    }
}
