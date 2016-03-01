using PM25.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM25.InterfaceFile.Infras
{
    public interface IInfras
    {
        List<Infra> GetAllInfra();
        bool DeleteInfra(int ID);
        bool InsertInfra(string img, string summary, string detail);
        bool UpdataInfra(int ID, string img, string summary, string detail);
        Infra GetInfraById(int ID);
    }
}
