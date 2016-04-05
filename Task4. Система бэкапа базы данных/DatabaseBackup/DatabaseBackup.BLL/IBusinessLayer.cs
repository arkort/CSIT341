using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseBackup.BLL
{
    public interface IBusinessLayer
    {
        void Connect(string connectionString);
        void Backup();
        void Restore();
    }
}
