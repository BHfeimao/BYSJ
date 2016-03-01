using PM25.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM25.InterfaceFile.Nows
{
    public interface INows
    {
        List<Now> GetAllNow();
        bool DeleteNow(int ID);
        bool InsertNow(string title, string summary, string downloadURL);
        bool UpdataNow(int ID, string title, string summary, string downloadURL);
        Now GetNowById(int ID);
    }
}
