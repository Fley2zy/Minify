using System.Collections.Generic;
using System.Threading.Tasks;
using Minify.Model;

namespace Minify.Interfaces{
    public interface IRepository
    {
        void Add(MinifyData minifyData);
        IEnumerable<MinifyData> Get();

        Task<MinifyData> Get(string key);

        void Delete(string key);
    }
}