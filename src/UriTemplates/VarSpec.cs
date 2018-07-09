using System.Text;

namespace Tavis.UriTemplates
{
    public class VarSpec
    {
        private readonly OperatorInfo _operatorInfo;
        public StringBuilder VarName = new StringBuilder();
        public bool Explode = false;
        public int PrefixLength = 0;
        public bool First = true;

        public VarSpec(OperatorInfo operatorInfo)
        {
            _operatorInfo = operatorInfo;
        }

        public OperatorInfo OperatorInfo => _operatorInfo;

        public override string ToString() => (First ? _operatorInfo.First : "") 
            + VarName
            + (Explode ? "*" : "")
            + (PrefixLength > 0 ? ":" + PrefixLength : "");
    }
}