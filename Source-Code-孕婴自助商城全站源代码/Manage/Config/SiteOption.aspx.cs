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
using ZoomLa.BLL;
using ZoomLa.Common;
using ZoomLa.Components;
using System.IO;
using ZoomLa.Model;
using System.Text;
using System.Xml;
using ZoomLa.BLL.User;
using ZoomLa.Model.User;
using ZoomLa.SQLDAL;
using System.Text.RegularExpressions;
using System.Linq;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

public partial class Manage_I_Config_SiteOption : CustomerPageAction
{
    protected B_Admin badmin = new B_Admin();
    protected B_Node nll = new B_Node();
    protected B_Label labelBll = new B_Label();
    protected B_Model mll = new B_Model();
    EnviorHelper webhelper = new EnviorHelper();
    private string[] orderparam = "ordered,payed".Split(',');
    protected void Page_Load(object sender, EventArgs e)
    {
        string prodirName = Request.QueryString["prodirName"];
        if (prodirName!=null)
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "", "showconfig('1');", true);
        }
        if (!B_ARoleAuth.Check(ZLEnum.Auth.other, "SiteConfig"))
        {
            function.WriteErrMsg("没有权限进行此项操作");
        }
        if (!IsPostBack)
        {
            B_Node nll = new B_Node();
            txtStylePath.Text = SiteConfig.SiteOption.StylePath;
            txtAdvertisementDir.Text = SiteConfig.SiteOption.AdvertisementDir;
            languages.SelectedValue = SiteConfig.SiteOption.Language;

            TraditionalChinese.SelectedValue = System.Configuration.ConfigurationManager.AppSettings["TraditionalChinese"];
            //rblManage.SelectedValue = SiteConfig.SiteOption.SiteManageMode + "";
            EnableSiteManageCod.Checked = SiteConfig.SiteOption.EnableSiteManageCode;

            EnableSoftKey.Checked = SiteConfig.SiteOption.EnableSoftKey;
            EnableUploadFiles.Checked = SiteConfig.SiteOption.EnableUploadFiles;

            if (SiteConfig.SiteOption.IsAbsoluatePath)
            { rdoIapTrue.Checked = true; }
            else
            { rdoIapFalse.Checked = true; }

            rdoBtnLSh.Checked=SiteConfig.SiteOption.RegPageStart;

            if (SiteConfig.SiteOption.IsOpenHelp == "0")
            {
                DeleteLocal.Text = "同时删除本地帮助文件";
                PromptHelp.Visible = false;
            }
            else
            {
                DeleteLocal.Text = "从云端下载帮助文件放到Manage/help下";
                PromptHelp.Visible = true;
            }
            MailPermission.Checked = SiteConfig.SiteOption.MailPermission=="1"?true:false;
            FileN.Items[Convert.ToInt32(SiteConfig.SiteOption.FileN)].Selected = true;
            //个人空间设置
            IsZone.Checked = SiteConfig.SiteOption.IsZone;

            //云盘权限
            for (int i = 0; i < cloud_ChkList.Items.Count && !string.IsNullOrEmpty(SiteConfig.SiteOption.Cloud_Auth); i++)
            {
                cloud_ChkList.Items[i].Selected = SiteConfig.SiteOption.Cloud_Auth.Contains(cloud_ChkList.Items[i].Value);
            }
            //多用户网店
            IsMall.Checked = SiteConfig.SiteOption.IsMall;

            //是否开启短信
            OpenSendMessage.Checked = SiteConfig.SiteOption.OpenSendMessage;

            cloudLeadTips.Checked = SiteConfig.SiteOption.CloudLeadTips == "1" ? true : false;

            //短消息提示
            //SMSTips.Checked=SiteConfig.SiteOption.SMSTips;

            //快递跟踪,订单提醒
            if (SiteConfig.SiteOption.KDAPI == 0)
            {
                RB_switch.Checked = false;
            }
            else 
            {
                RB_switch.Checked = true;
                Api.Style.Add("display","block");
            }
            TB_Api.Text = SiteConfig.SiteOption.KDKey;
            SetCheckVal(OrderMsg_Chk, SiteConfig.SiteOption.OrderMsg_Chk);
            SetCheckVal(OrderMasterMsg_Chk,SiteConfig.SiteOption.OrderMasterMsg_Chk);
            SetCheckVal(OrderMasterEmail_Chk, SiteConfig.SiteOption.OrderMasterEmail_Chk);
            ReturnDate_T.Text = SiteConfig.SiteOption.THDate.ToString();
            OrderMsg_ordered_T.Text = SetJsonVal(SiteConfig.SiteOption.OrderMsg_Tlp, "ordered");
            OrderMsg_payed_T.Text = SetJsonVal(SiteConfig.SiteOption.OrderMsg_Tlp, "payed");
            OrderMasterMsg_ordered_Tlp.Text = SetJsonVal(SiteConfig.SiteOption.OrderMasterMsg_Tlp,"ordered");
            OrderMasterMsg_payed_Tlp.Text = SetJsonVal(SiteConfig.SiteOption.OrderMasterMsg_Tlp, "payed");
            OrderMasterEmail_ordered_Tlp.Text = SetJsonVal(SiteConfig.SiteOption.OrderMasterEmail_Tlp, "ordered");
            OrderMasterEmail_payed_Tlp.Text = SetJsonVal(SiteConfig.SiteOption.OrderMasterEmail_Tlp, "payed"); 
            /*-------------------------------------------------------*/
            EditVer.SelectedValue = SiteConfig.SiteOption.EditVer;
            //freedomain.Text = SiteConfig.SiteOption.freedomain;
            OpenLog.Checked = SiteConfig.SiteOption.OpenLog=="1"?true:false;
            //Savadaylog.Text = SiteConfig.SiteOption.Savadaylog;
            //Savanumlog.Text = SiteConfig.SiteOption.Savanumlog;
            IndexEx.Text = SiteConfig.SiteOption.IndexEx;
            SiteCollKey_T.Text = SiteConfig.SiteOption.SiteCollKey;
            PayType_Hid.Value = SiteConfig.SiteOption.SiteID;
            //IsManageReg.Checked = SiteConfig.SiteOption.RegManager == 1;
            //safeDomainT.Text = SiteConfig.SiteOption.SafeDomain;
            txtSiteManageCode.Text = SiteConfig.SiteOption.SiteManageCode;
            if (prodirName != null)
            {

                //Text = "/Template/" + prodirName;
                txtCssDir.Text = "/Template/" + prodirName + "/style";
            }
            else
            {
                DataTable Dfileinfo = FileSystemObject.GetDirectorySmall(function.VToP("/Template/"));
                for (int i = 0; i < Dfileinfo.Rows.Count; i++)
                {
                    ListItem li = new ListItem("/Template/" + Dfileinfo.Rows[i]["name"]);
                    if (li.Text.Equals(SiteConfig.SiteOption.TemplateDir))
                    {
                        li.Selected = true;
                    }
                    DropTemplateDir.Items.Add(li);
                }
                //txtTemplateDir.Text = SiteConfig.SiteOption.TemplateDir;
                txtCssDir.Text = SiteConfig.SiteOption.CssDir;
            }
            if (!string.IsNullOrEmpty(SiteConfig.SiteOption.TemplateDir))
            {
                BindDP(SiteConfig.SiteOption.TemplateDir);
                IndexTemplate_DP.SelectedValue = SiteConfig.SiteOption.IndexTemplate;
            }
            txtProjectServer.Text = SiteConfig.SiteOption.ProjectServer.Trim();
            txtCatalog.Text = SiteConfig.SiteOption.GeneratedDirectory;
            txtPdf.Text = SiteConfig.SiteOption.PdfDirectory;//生成PDF目录
            ShopTemplate_DP.SelectedValue = SiteConfig.SiteOption.ShopTemplate;
            txtUploadDir.Text = SiteConfig.SiteOption.UploadDir;
            txtUploadFileExts.Text = SiteConfig.SiteOption.UploadFileExts;
            txtUploadFileMaxSize.Text =webhelper.GetMaxFile() ;

            TxtUpPicExt.Text = SiteConfig.SiteOption.UploadPicExts;
            TxtUpPicSize.Text = SiteConfig.SiteOption.UploadPicMaxSize.ToString();

            TxtUpMediaExt.Text = SiteConfig.SiteOption.UploadMdaExts;
            TxtUpMediaSize.Text = SiteConfig.SiteOption.UploadMdaMaxSize.ToString();

            TxtUpFlashSize.Text = SiteConfig.SiteOption.UploadFlhMaxSize.ToString();

            TxtSensitivity.Text = SiteConfig.SiteOption.Sensitivity;
            //短消息提示
            if (SiteConfig.SiteOption.UAgent)
            {
                UAgent.Checked = true;
                uaMag.Visible = true;
            }
            else
            {
                UAgent.Checked = false;
                uaMag.Visible = false;
            }
              
            OpenMessage.Checked = SiteConfig.SiteOption.OpenMessage==1?true:false;
            //标题查重
            IsRepet.Checked = SiteConfig.SiteOption.FileRj == 1 ? true : false;
            DupTitleNum_T.Text = SiteConfig.SiteOption.DupTitleNum.ToString();
            rdoIsSensitivity.Checked = SiteConfig.SiteOption.IsSensitivity==1?true:false;
            OpenAudit.Checked = SiteConfig.SiteOption.OpenAudit == 1 ? true : false;
            //商城配置
            OpenMoneySel_Chk.Checked = SiteConfig.SiteOption.OpenMoneySel;
            IsCheckPay.Checked = SiteConfig.ShopConfig.IsCheckPay == 1;
            //txtSetPrice.Text = SiteConfig.ShopConfig.OrderNum.ToString();
            ItemRegular_T.Text = SiteConfig.ShopConfig.ItemRegular;
            OrderExpired_T.Text = SiteConfig.ShopConfig.OrderExpired.ToString();
            Videourl.Text = SiteConfig.SiteOption.Videourl;
            FlexKey.Text = SiteConfig.SiteOption.FlexKey;
            APPAuth_T.Text = SiteConfig.SiteOption.WxAppID;
            MastMoney.Text = SiteConfig.SiteOption.MastMoney.ToString("F2");
            DeleteLocal.Checked = SiteConfig.SiteOption.DeleteLocal;
            IsOpenHelp.Checked = SiteConfig.SiteOption.IsOpenHelp=="1"?true:false;
            CommentRule.Text = SiteConfig.UserConfig.CommentRule.ToString();
            // Getgooglemap();
            Call.SetBreadCrumb(Master, "<li><a href='SiteInfo.aspx'>系统设置</a></li><li><a href='SiteInfo.aspx'>网站配置</a></li><li class=\"active\"><a href='SiteOption.aspx'>网站参数配置</a></li>" + Call.GetHelp(3));
        }
    }
    // 保存
    protected void Button1_Click(object sender, EventArgs e)
    {
        SiteConfig.SiteOption.AdvertisementDir = txtAdvertisementDir.Text;
        SiteConfig.SiteOption.CssDir = txtCssDir.Text;
        SiteConfig.SiteOption.StylePath = txtStylePath.Text;
        //SiteConfig.SiteOption.SiteManageMode = DataConverter.CLng(rblManage.SelectedValue);
        //检索是否存在该语言
        if (languages.SelectedIndex > 1)
        {
            string dirPath = HttpContext.Current.Server.MapPath("~/Language/" + languages.SelectedValue + ".xml");
            if (!File.Exists(dirPath))
            {
                function.WriteErrMsg("对不起，系统未配置此语言，请检索配置或联系官网获取此语言配置！", Request.RawUrl);
            }
        }
        SiteConfig.SiteOption.Language = languages.SelectedValue;
        lang.LangOP = languages.SelectedValue;
        SiteConfig.SiteOption.EnableSiteManageCode = EnableSiteManageCod.Checked;
        SiteConfig.SiteOption.EnableSoftKey = EnableSoftKey.Checked;
        SiteConfig.SiteOption.EnableUploadFiles = EnableUploadFiles.Checked;
        if (rdoIapTrue.Checked) { SiteConfig.SiteOption.IsAbsoluatePath = true; }
        else { SiteConfig.SiteOption.IsAbsoluatePath = false; }
        SiteConfig.SiteOption.OpenSendMessage = OpenSendMessage.Checked;
        SiteConfig.SiteOption.IsZone = IsZone.Checked;
        //云盘
        SiteConfig.SiteOption.Cloud_Auth = "";
        for (int i = 0; i < cloud_ChkList.Items.Count; i++)
        {
            if (cloud_ChkList.Items[i].Selected) SiteConfig.SiteOption.Cloud_Auth += cloud_ChkList.Items[i].Value + ",";
        }
        SiteConfig.SiteOption.IsMall = IsMall.Checked;
        SiteConfig.SiteOption.CloudLeadTips =cloudLeadTips.Checked?"1":"0"; 
        if (UAgent.Checked) { SiteConfig.SiteOption.UAgent = true; }
        else { SiteConfig.SiteOption.UAgent = false; }
        SiteConfig.SiteOption.KDAPI = RB_switch.Checked ? 1 : 0;//快递100
        SiteConfig.SiteOption.KDKey = TB_Api.Text.Trim();
        //商城模块配置
        SiteConfig.SiteOption.OrderMsg_Chk = GetCheckVal(OrderMsg_Chk);
        SiteConfig.SiteOption.THDate = Convert.ToInt32(ReturnDate_T.Text);
        SiteConfig.SiteOption.OrderMsg_Tlp = GetJson(orderparam, OrderMsg_ordered_T.Text, OrderMsg_payed_T.Text); 
        SiteConfig.SiteOption.OrderMasterMsg_Chk = GetCheckVal(OrderMasterMsg_Chk);
        SiteConfig.SiteOption.OrderMasterMsg_Tlp = GetJson(orderparam, OrderMasterMsg_ordered_Tlp.Text, OrderMasterMsg_payed_Tlp.Text); 
        SiteConfig.SiteOption.OrderMasterEmail_Chk = GetCheckVal(OrderMasterEmail_Chk);
        SiteConfig.SiteOption.OrderMasterEmail_Tlp = GetJson(orderparam, OrderMasterEmail_ordered_Tlp.Text, OrderMasterEmail_payed_Tlp.Text); 
        //----
        //SiteConfig.SiteOption.SMSTips = SMSTips.Checked;
        SiteConfig.SiteOption.OpenLog = OpenLog.Checked?"1":"0";
        //SiteConfig.SiteOption.Savadaylog = DataConverter.CLng(Savadaylog.Text).ToString();
        //SiteConfig.SiteOption.Savanumlog = DataConverter.CLng(Savanumlog.Text).ToString();
        SiteConfig.SiteOption.SiteCollKey = SiteCollKey_T.Text.Trim();
        //SiteConfig.SiteOption.SafeDomain = safeDomainT.Text.Trim();
        SiteConfig.SiteOption.SiteManageCode = txtSiteManageCode.Text;
        SiteConfig.SiteOption.TemplateDir = DropTemplateDir.SelectedItem.Text;
        SiteConfig.SiteOption.ProjectServer = txtProjectServer.Text;
        SiteConfig.SiteOption.GeneratedDirectory = txtCatalog.Text;//生成页面目录
        SiteConfig.SiteOption.PdfDirectory = txtPdf.Text;//生成PDF目录
        SiteConfig.SiteOption.IndexEx = IndexEx.Text;
        SiteConfig.SiteOption.IndexTemplate = Request.Form[IndexTemplate_DP.UniqueID];
        SiteConfig.SiteOption.ShopTemplate = Request.Form[ShopTemplate_DP.UniqueID];
        SiteConfig.SiteOption.UploadDir = txtUploadDir.Text;
        SiteConfig.SiteOption.UploadFileExts = txtUploadFileExts.Text;
        SiteConfig.SiteOption.UploadPicExts = TxtUpPicExt.Text;
        SiteConfig.SiteOption.UploadPicMaxSize = int.Parse(TxtUpPicSize.Text);
        SiteConfig.SiteOption.EditVer = EditVer.SelectedValue;
        SiteConfig.SiteOption.IsSaveRemoteImage = EditVer.SelectedValue == "1" ? true : false;
        SiteConfig.SiteOption.UploadMdaExts = TxtUpMediaExt.Text;
        SiteConfig.SiteOption.UploadMdaMaxSize = int.Parse(TxtUpMediaSize.Text);

        SiteConfig.SiteOption.UploadFlhMaxSize = int.Parse(TxtUpFlashSize.Text);
        //SiteConfig.ShopConfig.OrderNum = decimal.Parse(txtSetPrice.Text);
        SiteConfig.ShopConfig.ItemRegular = ItemRegular_T.Text;
        SiteConfig.ShopConfig.IsCheckPay = IsCheckPay.Checked ? 1 : 0;
        SiteConfig.ShopConfig.OrderExpired = DataConvert.CLng(OrderExpired_T.Text);
        SiteConfig.SiteOption.OpenMoneySel = OpenMoneySel_Chk.Checked;
        SiteConfig.SiteOption.OpenMessage = OpenMessage.Checked ? 1 : 0;
        SiteConfig.SiteOption.FileRj = IsRepet.Checked ? 1 : 0;
        SiteConfig.SiteOption.DupTitleNum = DataConvert.CLng(DupTitleNum_T.Text);
        SiteConfig.SiteOption.OpenAudit = OpenAudit.Checked ? 1 : 0;
        SiteConfig.SiteOption.IsSensitivity = rdoIsSensitivity.Checked?1:0;
        SiteConfig.SiteOption.Sensitivity = TxtSensitivity.Text.Trim();
        SiteConfig.SiteOption.Videourl = Videourl.Text.Trim();
        SiteConfig.SiteOption.FlexKey = FlexKey.Text.Trim();
        SiteConfig.SiteOption.WxAppID = APPAuth_T.Text.Trim();
        SiteConfig.SiteOption.MastMoney = DataConverter.CDouble(MastMoney.Text);

        SiteConfig.SiteOption.RegPageStart = rdoBtnLSh.Checked;
        SiteConfig.SiteOption.MailPermission = MailPermission.Checked?"1":"0";
        SiteConfig.SiteOption.FileN = FileN.SelectedIndex;
        SiteConfig.SiteOption.DeleteLocal = DeleteLocal.Checked;
        SiteConfig.SiteOption.IsOpenHelp = IsOpenHelp.Checked?"1":"0";
        SiteConfig.UserConfig.CommentRule = DataConverter.CLng(CommentRule.Text);
        SiteConfig.SiteOption.SiteID = Request.Form["PayType"];
        //SiteConfig.SiteOption.RegManager = IsManageReg.Checked ? 1 : 0;
        string path = base.Request.PhysicalApplicationPath + "/manage/help";
        if (IsOpenHelp.Checked)
        {
            if (!Directory.Exists(path)) { Directory.CreateDirectory(path); }
            if (DeleteLocal.Checked)
            {
                System.Net.WebClient myWebClient = new System.Net.WebClient();
                DataSet ds = new DataSet();
                try
                {
                    ds.ReadXml(SiteConfig.SiteOption.ProjectServer + "/api/gettemplate.aspx?menu=gethelp");
                }
                catch
                {
                    function.WriteErrMsg("请检查云端设置是否正常", CustomerPageAction.customPath+"Config/SiteOption.aspx");
                }
                DataTable dt = ds.Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    myWebClient.DownloadFile(SiteConfig.SiteOption.ProjectServer + "/help/" + dt.Rows[i]["TempDirName"].ToString(), base.Request.PhysicalApplicationPath + "/manage/help/" + dt.Rows[i]["TempDirName"].ToString());
                }
            }
        }
        if ((!IsOpenHelp.Checked) && DeleteLocal.Checked)
        {
            if (Directory.Exists(path))
            {
                FileSystemObject.Delete(path, FsoMethod.Folder);
            }
        }
        XmlDocument xmlDoc2 = new XmlDocument();
        xmlDoc2.Load(Server.MapPath("/Config/AppSettings.config"));
        XmlNodeList amde = xmlDoc2.SelectSingleNode("appSettings").ChildNodes;
        foreach (XmlNode xn in amde)
        {
            XmlElement xe = (XmlElement)xn;
            if (xe.GetAttribute("key").ToString() == "TraditionalChinese")
                xe.SetAttribute("value", TraditionalChinese.SelectedValue);
        }
        try
        {
            xmlDoc2.Save(Server.MapPath("/Config/AppSettings.config"));
        }
        catch (System.IO.IOException) {}
        try
        {
            SiteConfig.Update();
            if (Convert.ToInt64(txtUploadFileMaxSize.Text) > 4096)
                function.WriteErrMsg("IIS可支持最大文件上传的容量为4G！");
            webhelper.UpdateMaxFile((Convert.ToInt64(txtUploadFileMaxSize.Text) * 1024 * 1024).ToString());
            function.WriteSuccessMsg("网站参数配置保存成功", CustomerPageAction.customPath + "Config/SiteOption.aspx"); 
        }
        catch (FileNotFoundException)
        {
            function.WriteErrMsg("文件未找到", "SiteOption.aspx");
        }
        catch (UnauthorizedAccessException)
        {
            function.WriteErrMsg("检查您的服务器是否给配置文件或文件夹配置了写入权限", CustomerPageAction.customPath + "Config/SiteOption.aspx");
        }

    }
    //清空
    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtCssDir.Text = "";
        txtStylePath.Text = "";
        txtAdvertisementDir.Text = "";
        IndexEx.Text = "";
        txtSiteManageCode.Text = "";
        //txtTemplateDir.Text = "";
        txtCatalog.Text = "";
        txtPdf.Text = "";//生成PDF目录
        txtUploadDir.Text = "";
        txtUploadFileExts.Text = "";
        txtUploadFileMaxSize.Text = "";
        TxtUpPicExt.Text = "";
        TxtUpPicSize.Text = "";
        TxtUpMediaExt.Text = "";
        TxtUpMediaSize.Text = "";
        TxtUpFlashSize.Text = "";
        TxtSensitivity.Text = "";
        Videourl.Text = "";
        FlexKey.Text = "";
        MastMoney.Text = "";
        txtSetPrice.Text = "";
        TB_Api.Text = "";
    }
    //一键开销
    protected void Button2_Click(object sender, EventArgs e)
    {
        bindShengji();
        thisDiv.Value = "1";
        function.Script(Page, "showconfig('1')");
    }
    protected void languages_SelectedIndexChanged(object sender, EventArgs e)
    {
        string dirPath = HttpContext.Current.Server.MapPath("~/Language/" + languages.SelectedValue + ".xml");
        if (!File.Exists(dirPath)&&languages.SelectedIndex>1)
        {
            Prompt.Text = "*对不起，系统未配置此语言，请检索配置或联系官网获取此语言配置";
        }
        else
            Prompt.Text = "系统已配置此语言，此语言可以使用";
    }
    protected void IsOpenHelp_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!IsOpenHelp.Checked)
        {
            DeleteLocal.Text = "同时删除本地帮助文件";
            PromptHelp.Visible = false;
        }
        else
        {
            DeleteLocal.Text = "从云端下载帮助文件放到Manage/help下";
            PromptHelp.Visible = true;
        }
    }
    //--------------Tools
    public void BindDP(string vpath)
    {
        string ppath = Server.MapPath(vpath);
        DataTable dt = FileSystemObject.GetDirectoryAllInfos(ppath, FsoMethod.File);
        dt.DefaultView.RowFilter = "rname Like '%.html'";
        dt = dt.DefaultView.ToTable(false, "rname");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            dt.Rows[i]["rname"] = dt.Rows[i]["rname"].ToString().Replace(ppath, "").Replace(@"\", "/");
        }
        IndexTemplate_DP.DataSource = dt;
        IndexTemplate_DP.DataBind();
        ShopTemplate_DP.DataSource = dt;
        ShopTemplate_DP.DataBind();
        IndexTemplate_DP.Items.Insert(0, new ListItem("未指定", ""));
        ShopTemplate_DP.Items.Insert(0, new ListItem("未指定", ""));
    }
    public void bindShengji()
    {
        try
        {
            //升级节点
            DataSet nodelist = nll.GetDirectory();
            if (nodelist != null)
            {
                //生成目录
                if (!FileSystemObject.IsExist(base.Request.PhysicalApplicationPath + @"\" + SiteConfig.SiteOption.TemplateDir.Replace("/", @"\") + @"\配置库\节点\", FsoMethod.Folder))
                {
                    FileSystemObject.CreateFileFolder(base.Request.PhysicalApplicationPath + @"\" + SiteConfig.SiteOption.TemplateDir.Replace("/", @"\") + @"\配置库\节点\");
                }
                nodelist.WriteXml(base.Request.PhysicalApplicationPath + @"\" + SiteConfig.SiteOption.TemplateDir.Replace("/", @"\") + @"\配置库\节点\Directory.node");

                if (!FileSystemObject.IsExist(base.Request.PhysicalApplicationPath + @"\" + SiteConfig.SiteOption.TemplateDir.Replace("/", @"\") + @"\配置库\节点\NodeList", FsoMethod.Folder))
                {
                    FileSystemObject.CreateFileFolder(base.Request.PhysicalApplicationPath + @"\" + SiteConfig.SiteOption.TemplateDir.Replace("/", @"\") + @"\配置库\节点\NodeList");
                }

                for (int i = 0; i < nodelist.Tables[0].Rows.Count; i++)
                {
                    int NodeID = DataConverter.CLng(nodelist.Tables[0].Rows[i]["NodeID"]);
                    string NodeName = nodelist.Tables[0].Rows[i]["NodeName"].ToString();
                    DataSet nodeset = nll.GetNodeSet(NodeID);
                    nodeset.WriteXml(base.Request.PhysicalApplicationPath + @"\" + SiteConfig.SiteOption.TemplateDir.Replace("/", @"\") + @"\配置库\节点\NodeList\" + NodeID.ToString() + ".node");
                }
            }
            nodelist.Dispose();
            if (!FileSystemObject.IsExist(base.Request.PhysicalApplicationPath + @"\" + SiteConfig.SiteOption.TemplateDir.Replace("/", @"\") + @"\配置库\标签\", FsoMethod.Folder))
            {
                FileSystemObject.CreateFileFolder(base.Request.PhysicalApplicationPath + @"\" + SiteConfig.SiteOption.TemplateDir.Replace("/", @"\") + @"\配置库\标签\");
            }
            string dirfilename = base.Request.PhysicalApplicationPath + @"\" + SiteConfig.SiteOption.TemplateDir.Replace("/", @"\") + @"\配置库\标签\Directory.label";
            DataSet nodedir = new DataSet("NewDataSet");
            DataTable dttemp = labelBll.GetLabelCateListXML();
            DataSet dsLabals = new DataSet("NewDataSet");
            DataTable dtLabals = new DataTable("DataTable");
            dsLabals.Tables.Add(dtLabals);
            for (int i = 0; i < dttemp.Rows.Count; i++)
            {
                DataRow dr = dttemp.Rows[i];
                DataSet labeltable1 = new DataSet("NewDataSet");
                DataTable dtFIle = FileSystemObject.GetDirectoryInfos(base.Request.PhysicalApplicationPath + @"\" + SiteConfig.SiteOption.TemplateDir.Replace("/", @"\") + @"\配置库\标签\" + dr["name"].ToString(), FsoMethod.File);
                for (int ss = 0; ss < dtFIle.Rows.Count; ss++)
                {
                    if (dtFIle.Rows[ss]["content_type"].ToString().ToLower() == "label")
                    {
                        string filenameLabel = SiteConfig.SiteMapath().Substring(0, SiteConfig.SiteMapath().Length - 1) + SiteConfig.SiteOption.TemplateDir.Replace("/", @"\") + @"\配置库\标签\" + dr["name"] + @"\" + dtFIle.Rows[ss]["name"];
                        DataSet tempset = new DataSet();
                        tempset.ReadXml(filenameLabel);
                        DataTable converttable = tempset.Tables[0].Copy();
                        tempset.Dispose();
                        if (dtLabals.Columns.Count <= 0)
                        {
                            for (int jj = 0; jj < converttable.Columns.Count; jj++)
                            {
                                dtLabals.Columns.Add(converttable.Columns[jj].ColumnName, converttable.Columns[jj].DataType);
                            }
                        }
                        dtLabals.ImportRow(converttable.Rows[0]);
                    }
                }
                if (labeltable1.Tables.Count <= 0)
                {
                    DataTable dtnew = new DataTable("Table");
                    DataColumn dc = new DataColumn("LabelID", typeof(string));
                    dtnew.Columns.Add(dc);
                    dc = new DataColumn("LabelName", typeof(string));
                    dtnew.Columns.Add(dc);
                    dc = new DataColumn("LabelType", typeof(string));
                    dtnew.Columns.Add(dc);
                    dc = new DataColumn("LabelCate", typeof(string));
                    dtnew.Columns.Add(dc);
                    labeltable1.Tables.Add(dtnew);
                }
            }
            for (int i = dtLabals.Columns.Count - 1; i >= 4; i--)
            {
                dtLabals.Columns.RemoveAt(i);
            }
            DataTable labeltoptable = dsLabals.Tables[0].Copy();
            labeltoptable.TableName = "Table";
            nodedir.Tables.Add(labeltoptable);
            nodedir.WriteXml(dirfilename);
            nodedir.Dispose();
            mll.UpModel();
            lblKai.Text = "一键开销成功";
        }
        catch
        {
            lblKai.Text = "一键开销成功";
            throw;
        }
    }
    public string GetCheckVal(CheckBoxList chkList)
    {
        string value = "";
        for (int i = 0; i < chkList.Items.Count; i++)
        {
            if (chkList.Items[i].Selected) value += chkList.Items[i].Value + ",";
        }
        return value.TrimEnd(',');
    }
    public void SetCheckVal(CheckBoxList chkList, string value)
    {
        if (chkList.Items.Count < 1 || string.IsNullOrEmpty(value)) return;
        for (int i = 0; i < chkList.Items.Count; i++)
        {
            chkList.Items[i].Selected = value.Contains(chkList.Items[i].Value);
        }
    }
    public string GetJson(string[] name, params string[] value)
    {
        JObject obj = new JObject();
        if (name.Length != value.Length) function.WriteErrMsg("键与值的数量不匹配");
        for (int i = 0; i < name.Length; i++)
        {
            obj.Add(name[i], value[i]);
        }
        return obj.ToString();
    }
    public string SetJsonVal(string json, string name)
    {
        if (string.IsNullOrEmpty(json)) return "";
        JObject obj = (JObject)JsonConvert.DeserializeObject(json);
        return obj[name].ToString();
    }
}