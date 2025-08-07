using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swin_Adveture_Task
{
    public class IdentifiableObject
    {
        public List<string> _identifiers = new List<string>();

        public IdentifiableObject(string[] idents)
        {
            foreach (string ident in idents)
            {
                AddIdentifier(ident);
            }
        }

        public bool AreYou(string ident)
        {
            foreach (string identifier in _identifiers)
            {
                if (ident.ToLower() == identifier)
                {
                    return true;
                }
            }
            return false;
        }

        public string FirstID
        {
            get
            {
                if (_identifiers.Count == 0)
                {
                    return "";
                }
                else
                {
                    return _identifiers.First();
                }
            }
        }

        public void AddIdentifier(string ident)
        {
            _identifiers.Add(ident.ToLower());
        }
        public void PriviliegeEscalation(string pin)
        {
            String Student_ID = "105565520";

            if (pin == Student_ID.Substring(Student_ID.Length - 4)) ;
            {
                _identifiers[0] = "Task_2_4_P";
            }
        }
    }
}