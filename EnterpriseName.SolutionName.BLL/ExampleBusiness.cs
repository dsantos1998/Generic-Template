using EnterpriseName.SolutionName.Domain.BLL.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseName.SolutionName.Domain.BLL
{
    public class ExampleBusiness : BaseBusiness, IExampleBusiness
    {
        public ExampleBusiness(IConfiguration config) : base(config)
        {
        }

        #region Public Methods

        #region Third party API requests



        #endregion

        #region Logic



        #endregion

        #region Queries

        #endregion

        #endregion

        #region Private Methods



        #endregion

    }
}
