using System;
using System.Data.SQLite;

namespace GymGenZ.PControls
{
    internal class CPaymentPackage
    {
        private string _connectionString;

        public CPaymentPackage(string connectionString)
        {
            _connectionString = connectionString;
        }
    }
}
