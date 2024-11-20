using DSM.MJMLEditor.Domain.BLL.Interfaces;
using DSM.MJMLEditor.Interface.DLL;
using DSM.MJMLEditor.Interface.Interfaces.DLL;
using Microsoft.Extensions.Configuration;

namespace DSM.MJMLEditor.Domain.BLL
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
