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
using ZoomLa.Common;
using ZoomLa.BLL;
using ZoomLa.Model;
using ZoomLa.Components;
using System.Text.RegularExpressions;
using System.Collections.Generic;

public partial class Store_Shopinfo : System.Web.UI.Page
{
    protected B_CreateShopHtml shll = new B_CreateShopHtml();
    protected B_CreateHtml bll = new B_CreateHtml();
    B_Content bcontent = new B_Content();
    B_Model bmode = new B_Model();
    B_Node bnode = new B_Node();
    B_User buser = new B_User();
    B_Product pll = new B_Product();
    public int ItemID { get { return DataConverter.CLng(Request.QueryString["ID"]); } }

    protected void Page_Load(object sender, EventArgs e)
    {
        M_Product proMod = pll.GetproductByid(ItemID);
        OrderCommon.ProductCheck(proMod);
        int CPage = string.IsNullOrEmpty(base.Request.QueryString["page"]) ? 1 : DataConverter.CLng(base.Request.QueryString["page"]);
        if (CPage <= 0)
            CPage = 1;
        M_Node nodeinfo = bnode.GetNodeXML(proMod.Nodeid);
        if (nodeinfo.PurviewType)
        {
            if (!buser.CheckLogin())
            {
                function.WriteErrMsg("该信息所属栏目需登录验证，请先登录再进行此操作！", "/User/login.aspx");
            }
            else
            {
                //此处以后可以加上用户组权限检测
            }
        }

        M_ModelInfo modelinfo = bmode.GetModelById(proMod.ModelID);
        string TempNode = bnode.GetModelTemplate(proMod.Nodeid, proMod.ModelID);
        string TemplateDir = modelinfo.ContentModule;
        if (!string.IsNullOrEmpty(TempNode))
        {
            TemplateDir = TempNode;
        }

        if (string.IsNullOrEmpty(TemplateDir))
        {
            Response.Write("[产生错误的可能原因：该商品所属模型未指定模板！]");
        }
        else
        {
            string contentHtml = SafeSC.ReadFileStr(SiteConfig.SiteOption.TemplateDir + "/" + TemplateDir);
            contentHtml = this.shll.CreateShopHtml(contentHtml, 0, 0);
            contentHtml = this.bll.CreateHtml(contentHtml, 0, ItemID, 0);
            Response.Write(contentHtml);
        }

    }
}