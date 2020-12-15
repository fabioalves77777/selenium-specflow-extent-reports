using System.Data;
using System.Threading.Tasks;

namespace Selenium.Specflow.Extent.Reports.Utility
{

    public class AzureParams
    {
        private static string _vstsPat = "44rt2ct2ojqpiam75plsnq4oyvfxkkqtp74lnyosv2zwxtii5u2q";
        private static string _vstsUrl = "https://fabiotestproject.visualstudio.com/";

        public DataRowCollection GetParams(string testcaseID)
        {
            GetTestCaseParams p = new GetTestCaseParams
            {
                Pat = _vstsPat,
                VstsURI = _vstsUrl
            };
            DataSet ds = new DataSet();
            Task.Run(async () => { ds = await p.GetParams(testcaseID); }).GetAwaiter().GetResult();
            return ds.Tables[0].Rows;
        }

    }
}
