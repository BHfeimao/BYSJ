using PM25.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM25.InterfaceFile.InfraStus
{
    public interface IInfraStus
    {
        List<InfraStu> GetAllInfraStu();
        bool DeleteInfraStu(int ID);
        bool InsertInfraStu(string img, string summary, string detail);
        bool UpdataInfraStu(int ID, string img, string summary, string detail);
        InfraStu GetInfraStuById(int ID);
    }
}
