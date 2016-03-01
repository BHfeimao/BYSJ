using PM25.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM25.InterfaceFile.BodyTems
{
    public interface IBodyTems
    {
        List<BodyTem> GetAllBodyTem();
        bool DeleteBodyTem(int ID);
        bool InsertBodyTem(string img, string summary, string detail);
        bool UpdataBodyTem(int ID, string img, string summary, string detail);
        BodyTem GetBodyTemById(int ID);
    }
}
