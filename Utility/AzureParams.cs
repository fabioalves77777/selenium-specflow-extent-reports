using System.Data;
using System.Threading.Tasks;

namespace Selenium.Specflow.Extent.Reports.Utility
{

    public class AzureParams
    {
        private static string _vstsPat = "zo3d5odvsnbbjbirz2hypx4zuy6vdxu4ujq2kgqyhv2oufxvkiqa";
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
