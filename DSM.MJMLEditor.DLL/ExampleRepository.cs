using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSM.MJMLEditor.Interface.DLL.Interfaces;
using Microsoft.Extensions.Configuration;

namespace DSM.MJMLEditor.Interface.DLL
{
    public class ExampleRepository : BaseRepository, IExampleRepository
    {
        private readonly string _conexion;

        public ExampleRepository(IConfiguration config) : base(config)
        {
            _conexion = config.GetConnectionString(config["ActiveConnection"]!)!;
        }

        #region QUERIES



        #endregion

        #region INSERT, UPDATE, DELETE



        #endregion

    }
}
