using PM25.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM25.InterfaceFile.IllnessStus
{
    public interface IIllnessStus
    {
        List<IllnessStu> GetAllIllnessStu();
        bool DeleteIllnessStu(int ID);
        bool InsertIllnessStu(string img, string summary, string detail);
        bool UpdataIllnessStu(int ID, string img, string summary, string detail);
        IllnessStu GetIllnessStuById(int ID);
    }
}
