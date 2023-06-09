using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace EDU_QA_DB.Helpers
{
    public class PageResetter
    {
        public static void ResetPage(PlaceHolder phContent)
        {
            phContent.Controls.Clear();

        }
    }
}