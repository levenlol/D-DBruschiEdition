using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DndBruschiEd.Core.Characters
{
    class CharacterInfo
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Race { get; set; }
        public string Class { get; set; }

        public CharacterInfo()
        {
            FirstName = SecondName = Race = Class = "";
        }

        public CharacterInfo(string firstName, string secondName, string race, string charClass)
        {
            FirstName = firstName.Trim();
            SecondName = secondName.Trim();
            Race = race;
            Class = charClass;
        }

        public string GetFullName()
        {
            return (FirstName + " " + SecondName).Trim(); 
        }

    }
}
