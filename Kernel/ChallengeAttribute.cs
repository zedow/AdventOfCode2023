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
        private string _inputFilePath;
        public ChallengeAttribute(string name,string inputFilePath) 
        {
            _name = name;
            _inputFilePath = inputFilePath;
        }

        public string GetName() => _name;
        public string GetInputFilePath() => _inputFilePath;
    }
}
