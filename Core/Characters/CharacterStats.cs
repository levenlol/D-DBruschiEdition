using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DndBruschiEd.Core.Characters
{
    class CharacterStats
    {
        public int Level { get; set; }
        public int HP { get; set; }
        public int AbsorbPoint { get; set; }
        public int ArmorClass { get; set; }
        public int MagicResistance { get; set; }
        public int Attack { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Intellect { get; set; }
        public int Constitution { get; set; }
        public int Spirit { get; set; }

        public CharacterStats()
        {

        }
    }
}
