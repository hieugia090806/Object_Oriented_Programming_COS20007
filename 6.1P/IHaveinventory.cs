using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinAdventure;

namespace SwinAdventure
{
    public interface IHaveInventory //Change from interna to public interface
    {
        //Step 1 of the UML in the IHaveInventory interface
        GameObject Locate(string id);
        //Step 2 of the UML in the IHaveInventory interface
        public string Name
        {
            get;
        }

    }
}
