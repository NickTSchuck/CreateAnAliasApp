using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CreateAnAliasBLL
{
    public interface ICreateAnAliasBLL
    {
        public abstract Task<object> sendHTTPRequest(string baseAddress, string path);
        public abstract IDictionary<string, string> getNewAlias();
    }

    
}
