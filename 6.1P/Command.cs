using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinAdventure;

namespace SwinAdventure
{
    public abstract class Command : IdentifiableObject //Step 1 of the UMLin the Command class
    {
        public Command(string[] ids) : base(ids) //Step 2 of the UML in the Command class
        {

        }

        public abstract string Execute(Player p, string[] text); //Step 3 of the UML in the Command class
    }
}
