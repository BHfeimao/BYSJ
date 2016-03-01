using PM25.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM25.InterfaceFile.News
{
    public interface INews
    {
        List<New> GetAllNew();
        bool DeleteNew(int ID);
        bool InsertNew(string img, string summary, string detail);
        bool UpdataNew(int ID, string img, string summary, string detail);
        New GetNewById(int ID);
    }
}
