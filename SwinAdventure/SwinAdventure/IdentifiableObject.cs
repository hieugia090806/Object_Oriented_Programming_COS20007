using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinAdventure;

namespace SwinAdventure
{
    public class IdentifiableObject //change from internal to public
    {
        //Attributes
        private List<string> _identifiers = new List<string>();
        //Constructor & Methods
        public IdentifiableObject(string[] idents)
        {
            foreach (string ident in idents)
            {
                _identifiers.Add(ident.ToLower());
            }
        }
        public bool AreYou(string id)
        {
            return _identifiers.Contains(id.ToLower());
        }
        public string FirstId
        {
            get
            {
                if (_identifiers.Count > 0)
                {
                    return _identifiers.First();
                }
                else
                {
                    return "";
                }
            }
        }
        public void AddIdentifier(string id)
        {
            _identifiers.Add(id.ToLower());
        }
        public void PrivilegeEscalation(string pin)
        {
            string studentID = "105565520";
            if (pin == studentID)
            {
                _identifiers[0] = "COS20007";
            }
        }
    }
}
