using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProgramingLanguageTechnology: Entity
    {
        public string Name { get; set; }
        public int programingLanguageId { get; set; }

        // hasMany vs. gibi ilişkiyle çekerken döngü oluşturmasın diye.
        [JsonIgnore]
        public virtual ProgramingLanguage? ProgramingLanguage { get; set; }

        public ProgramingLanguageTechnology()
        {

        }

        public ProgramingLanguageTechnology(int id, string name, int ProgramingLanguageId):this()
        {
            Id = id;
            Name = name;
            programingLanguageId = ProgramingLanguageId;
        }
    }
}
