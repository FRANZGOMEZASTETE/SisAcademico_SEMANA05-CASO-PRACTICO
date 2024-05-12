using SisAcademico.DATOS;
using SisAcademico.Entities;
using SisAcademico.Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisAcademico.Negocio
{
    public class EstudianteNegocio : IEstudianteRepositorio
    {
        AcademicoContexto bd = new AcademicoContexto();

      
        public void Actualizar(Estudiante estudiante)
        {
            bd.Entry(estudiante).State = EntityState.Modified;
            bd.SaveChanges();
        }

        public void Agregar(Estudiante estudiante)
        {
            bd.estudiante.Add(estudiante);
            bd.SaveChanges();
        }

        public Estudiante Buscar(int id)
        {
            var Busqueda = bd.estudiante.Find(id);
            return Busqueda;
        }

        public List<Estudiante> ListarEstudiantes(){
            var query = from x in bd.estudiante
                        orderby x.Id    
                        select x;
            return query.ToList();
        }

      
        public List<Estudiante> ListarEstudiantesxNombre(string nombre)
        {
            var query = from x in bd.estudiante
                        where x.Nombres.Contains(nombre)
                        select x;
            return query.ToList();
        }
    }
}
