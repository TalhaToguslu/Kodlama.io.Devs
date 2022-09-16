using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProgramingLanguage: Entity
    {
        public string Name { get; set; }
        public virtual ICollection<ProgramingLanguageTechnology> ProgramingLanguageTechnologies { get; set; }

        public ProgramingLanguage()
        {

        }

        public ProgramingLanguage(int id, string name):this()
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
