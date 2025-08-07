using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    //Change from internal to public
    public class IdentifiableObject
    {
        //Set attributes
        private List<string> _identifiers = new List<string>();
        //Set constructors and methods
        //1: Add identifiers to the Identifiable Object from the passed in array
        public IdentifiableObject(string[] idents)
        {
            foreach (string ident in idents)
            {
                _identifiers.Add(ident.ToLower());
            }
        }
        //2
        public bool AreYou(string id)
        { 
            return _identifiers.Contains(id.ToLower());
        }
        //3: FirstId() method returns the first identifier from _identifiers,
        //or an empty string if the object has identifiers
        public string FirstID
        {
            get
            {
                //Checks if _identifiers return an 
                if (_identifiers.Count > 0)
                {
                    return _identifiers[0];
                }
                else
                {
                    return "";
                }
            }
        }
        //4: AddIdentifier() method
        public void AddIdentifier(string id)
        {
            _identifiers.Add(id.ToLower());
        }
        //PrivilegeEscalation() method
        public void PrivilegeEscalation(string pin)
        {
            if (_identifiers.Count > 0 && _identifiers[0] == pin)
            {
                _identifiers[0] = "COS20007"; // store in lowercase
            }
        }

    }
}
