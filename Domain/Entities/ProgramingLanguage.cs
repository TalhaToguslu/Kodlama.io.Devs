using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("ProgramingLanguages")]
    public class ProgramingLanguage: Entity
    {
        public string Name { get; set; }

        public ProgramingLanguage()
        {

        }

        public ProgramingLanguage(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
