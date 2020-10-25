using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepInvest
{
    public interface ISecurities
    {
        string ISIN { get; set; }
        string CompanyName { get; set; }
        string Ticker { get; set; }
    }

    public class Stock: ISecurities
    {
        public string ISIN { get; set; }
        public string CompanyName { get; set; }
        public string Ticker { get; set; }
    }

    public class Bond: ISecurities
    {
        public string ISIN { get; set; }
        public string CompanyName { get; set; }
        public string Ticker { get; set; }
    }


}
