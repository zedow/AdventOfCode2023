using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kernel
{
    [System.AttributeUsage(System.AttributeTargets.Class)]
    public class ChallengeAttribute : System.Attribute
    {
        private string _name;
        public ChallengeAttribute(string name) 
        {
            _name = name;
        }

        public string GetName() => _name;
    }
}
