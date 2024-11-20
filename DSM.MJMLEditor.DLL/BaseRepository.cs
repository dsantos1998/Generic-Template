using DSM.MJMLEditor.Interface.Interfaces.DLL;
using Microsoft.Extensions.Configuration;

namespace DSM.MJMLEditor.Interface.DLL
{
    public class BaseRepository : IBaseRepository
    {
        private readonly string conString;

        public BaseRepository(IConfiguration config)
        {
            string cs = config.GetConnectionString(config["ActiveConnection"]!)!;
            conString = cs;
        }

        //public ResultInfo<int> InsertErrorBusiness(ErrorBusiness ent)
        //{
        //    ResultInfo<int> result = new ResultInfo<int>();
        //    string procedure = "SP_NEW_ErrorBusiness";
        //    try
        //    {
        //        using (sqlHelper repo = new sqlHelper(conString, false))
        //        {
        //            var dbres = repo.ExecuteProcedure(procedure, ent);

        //            if (!string.IsNullOrEmpty(repo.LastErrorString))
        //            {
        //                result.Errors.Add(new ResultError(repo.LastErrorString, false, "BaseRepository.InsertErrorBusiness"));
        //            }
        //            else if (dbres == null || dbres.Rows.Count == 0)
        //            {
        //                result.Errors.Add(new ResultError("ErrorBusiness no insertado.", false, "BaseRepository.InsertErrorBusiness"));
        //            }
        //            else
        //            {
        //                result.Content = Convert.ToInt32(dbres.Rows[0][0]);
        //            }
        //            dbres?.Dispose();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Errors.Add(new ResultError((ex.InnerException == null) ? ex.Message : ex.InnerException.Message, true, "BaseRepository.InsertErrorBusiness"));
        //    }

        //    return result;
        //}

    }
}
