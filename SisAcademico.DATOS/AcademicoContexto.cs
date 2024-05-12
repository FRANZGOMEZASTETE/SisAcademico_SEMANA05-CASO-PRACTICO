using SisAcademico.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisAcademico.DATOS
{
    public class AcademicoContexto : DbContext
    {
        public AcademicoContexto() : base("cadenaConexion1")
        {
        }
        public virtual DbSet<Estudiante> estudiante { get; set; }
    }
}
