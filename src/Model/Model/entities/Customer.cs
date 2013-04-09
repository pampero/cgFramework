using System;
using System.Web;
using System.ComponentModel;

namespace Model
{
    public class Customer: BaseClass
    {
        public string Name
        {
            get;
            set;
        }

        public ContractTypeEnum DefaultContractType
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    }
}
