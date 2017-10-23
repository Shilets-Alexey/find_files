using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Find_Files
{
    public interface IFindFiles
    {
        IEnumerable<string> GetFilesPaths();
    }
}
