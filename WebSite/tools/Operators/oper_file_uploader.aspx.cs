using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;

public partial class tools_operators_oper_file_uploader : System.Web.UI.Page
{

    protected void Page_PreInit(Object sender, EventArgs e)
    {
        site_utils PageAttr = new site_utils();
        PageAttr.setPageAttr(this.Page);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        lblStatus.Text = "";
    }
    protected void Upload_Click(object sender, EventArgs e)
    {

        if (mainFileUpload.PostedFile.ContentLength != 0) 
        {
            try 
            {
                if (mainFileUpload.PostedFile.ContentLength > 2097152) 
                {
                    lblStatus.Text = "The file is too large (Max: 2Mb). This file is not allowed.";
                }
                else
                {
                    string destDir = "D:\\netstuff\\eds\\Work\\Operators\\In\\";
                    string fileName = Path.GetFileName(mainFileUpload.PostedFile.FileName);
                    string destPath = Path.Combine(destDir, fileName);
                    mainFileUpload.PostedFile.SaveAs(destPath);
                    lblStatus.Text = "Thanks for uploading your file.";
                }
            }
            catch(Exception err)
            {
                lblStatus.Text = err.Message;
            }
        }

    }
}
