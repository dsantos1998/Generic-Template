using EnterpriseName.SolutionName.Domain.BLL.Interfaces;
using EnterpriseName.SolutionName.Interface.DLL;
using EnterpriseName.SolutionName.Interface.Interfaces.DLL;
using Microsoft.Extensions.Configuration;

namespace EnterpriseName.SolutionName.Domain.BLL
{
    public class BaseBusiness : IBaseBusiness
    {
        #region Public Properties

        private IBaseRepository BaseRepository { get; init; }

        #endregion

        public BaseBusiness(IConfiguration config)
        {
            BaseRepository = new BaseRepository(config);
        }


        #region Public Methods



        #endregion

    }
}
