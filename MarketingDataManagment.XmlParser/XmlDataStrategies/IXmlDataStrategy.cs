using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketingDataManagment.XmlHandler
{
    public interface IXmlDataStrategy
    {
        void Handle(string filePath);
    }
}
