using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CurrenciesService
{
    [ServiceContract]
    public interface ICurrencyService
    {
        [OperationContract]
        List<CurrencyDetails> getCurrencyInfo();

        [OperationContract]
        string translate(string currency);
    }
}
