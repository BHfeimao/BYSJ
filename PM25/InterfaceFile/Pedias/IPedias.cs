using PM25.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM25.InterfaceFile.Pedias
{
    /// <summary>
    /// 百科知识接口
    /// </summary>
    public interface IPedias
    {
        List<Pedia> GetAllPedia();
        bool DeletePedia(int ID);
        bool InsertPedia(string title, string text);
        bool UpdataPedia(int ID, string title, string text);
        Pedia GetPediaById(int ID);
    }
}
