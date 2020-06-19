namespace Zoomla.Website.manage.Shop
{
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
    using ZoomLa.Model;
    using ZoomLa.Components;
    using System.Text;
    using System.Xml;
    using System.Collections.Generic;

    public partial class AddProduct : CustomerPageAction
    {
        protected B_ZL_GroupBuy zl_groupbuy = new B_ZL_GroupBuy();
        protected B_UserProduct_T BUP = new B_UserProduct_T();
        protected B_Node bnode = new B_Node();
        protected B_Model bmode = new B_Model();
        protected B_ShowField bshow = new B_ShowField();
        protected B_ModelField bfield = new B_ModelField();
        protected B_Product bll = new B_Product();
        protected B_SpecInfo bspec = new B_SpecInfo();
        protected B_Content Cll = new B_Content();
        protected B_Manufacturers fact = new B_Manufacturers();
        protected B_Trademark Tradk = new B_Trademark();
        protected B_Stock Sll = new B_Stock();
        protected B_Promotions pro = new B_Promotions();
        protected B_User bu = new B_User();
        protected B_Group bgroup = new B_Group();
        protected B_Compete bcompete = new B_Compete();
        protected int NodeID;
        protected int ModelID;
        protected int proid;
        protected B_Sensitivity sll = new B_Sensitivity();
        protected B_BindFlolar bindflolar = new B_BindFlolar();
        //protected B_S_Flolar buserflo = new B_S_Flolar();
        protected void Page_Load(object sender, EventArgs e)
        {
            string str1 = "";
            string str2 = "添加商品";
            B_Admin badmin = new B_Admin();
            if (!badmin.ChkPermissions("ProductManage"))
            {
                function.WriteErrMsg("没有权限进行此项操作");
            }
            RangeValidator1.MinimumValue = Convert.ToString(Int32.MinValue);
            RangeValidator1.MaximumValue = Convert.ToString(Int32.MaxValue);
            RangeValidator2.MinimumValue = Convert.ToString(Int32.MinValue);
            RangeValidator2.MaximumValue = Convert.ToString(Int32.MaxValue);
            RangeValidator3.MinimumValue = Convert.ToString(Int32.MinValue);
            RangeValidator3.MaximumValue = Convert.ToString(Int32.MaxValue);
            RangeValidator4.MinimumValue = Convert.ToString(Int32.MinValue);
            RangeValidator4.MaximumValue = Convert.ToString(Int32.MaxValue);
            Random rancode = new Random();
            pid = DataConverter.CLng(Request.QueryString["id"]);
            M_Product pinfo = bll.GetproductByid(pid);
            string domcode = Convert.ToString(rancode.Next(99999));
            UpdateTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") ;
            txtCountHits.Text = pinfo.AllClickNum.ToString();
            ProCode.Text = Convert.ToString(DateTime.Now.Year) + Convert.ToString(DateTime.Now.Month) + Convert.ToString(DateTime.Now.Day) + Convert.ToString(DateTime.Now.Hour) + Convert.ToString(DateTime.Now.Minute) + Convert.ToString(DateTime.Now.Second) + Convert.ToString(DateTime.Now.Millisecond) + domcode;
            if (!this.Page.IsPostBack)
            {
                BindGroup();
                if (!badmin.ChkPermissions("ContentEdit"))
                {
                    function.WriteErrMsg("没有权限进行此项操作");
                }
                if (string.IsNullOrEmpty(base.Request.QueryString["ModelID"]))
                {
                    function.WriteErrMsg("没有指定要添加内容的模型ID!");
                }
                else
                {
                    this.ModelID = DataConverter.CLng(base.Request.QueryString["ModelID"]);
                }
                if (string.IsNullOrEmpty(base.Request.QueryString["NodeID"]))
                {
                    function.WriteErrMsg("没有指定要添加内容的栏目节点ID!");
                }
                else
                {
                    this.NodeID = DataConverter.CLng(Request.QueryString["NodeID"]);
                }
                this.nodename.Text = "<a href=\"ProductManage.aspx?NodeID=" + this.NodeID + "\">" + this.bnode.GetNodeXML(this.NodeID).NodeName + "</a>";
                this.HdnModel.Value = this.ModelID.ToString();
                this.HdnNode.Value = this.NodeID.ToString();
                str1 = "<a href=\"ProductManage.aspx?NodeID=" + this.NodeID + "\">" + this.bnode.GetNodeXML(this.NodeID).NodeName + "</a>";
                proid = DataConverter.CLng(Request.QueryString["id"]);
                string menu;
                menu = Request.QueryString["menu"];
                if (menu == "edit")
                {
                    str2 = "修改商品";
                    //topmenu.Text = "修改商品";
                    ClickType.Value = "update";
                    this.btnAdd.Visible = true;
                    ID.Value = Request.QueryString["id"].ToString();
                    pid = DataConverter.CLng(Request.QueryString["id"]);
                    //M_Product pinfo = bll.GetproductByid(pid);
                    Categoryid.Value = pinfo.Categoryid.ToString();
                    ProCode.Text = pinfo.ProCode.ToString();
                    BarCode.Text = pinfo.BarCode.ToString();
                    Proname.Text = pinfo.Proname.ToString();
                    Kayword.Text = pinfo.Kayword.ToString();
                    ProUnit.Text = pinfo.ProUnit.ToString();
                    Weight.Text = pinfo.Weight.ToString();
                    this.Propeid.Text = pinfo.Propeid.ToString();
                    this.Largesspirx.Text = pinfo.Largesspirx.ToString();
                    this.Largess.Checked = pinfo.Largess == 1 ? true : false;
                    this.txtRecommend.Text = pinfo.Recommend.ToString();
                    ServerPeriod.Text = pinfo.ServerPeriod.ToString();
                    ServerType.SelectedValue = pinfo.ServerType.ToString();
                    ProClass.Value = pinfo.ProClass.ToString();
                    txtPoint.Text = pinfo.PointVal.ToString();
                    Proinfo.Text = pinfo.Proinfo.ToString();
                    Procontent.Value = pinfo.Procontent.ToString();
                    txt_Clearimg.Text = pinfo.Clearimg.ToString();
                    txt_Thumbnails.Text = pinfo.Thumbnails.ToString();
                    Quota.Text = pinfo.Quota.ToString();
                    DownQuota.Text = pinfo.DownQuota.ToString();
                    Stock.Text = pinfo.Stock.ToString();
                    StockDown.Text = pinfo.StockDown.ToString();
                    JisuanFs.Text = pinfo.JisuanFs.ToString();
                    Rate.Text = pinfo.Rate.ToString();
                    Rateset.SelectedValue = pinfo.Rateset.ToString();
                    Dengji.Text = pinfo.Dengji.ToString();
                    ShiPrice.Text = pinfo.ShiPrice.ToString();
                    Brand.Text = pinfo.Brand.ToString();
                    Producer.Text = pinfo.Producer.ToString();
                    LinPrice.Text = pinfo.LinPrice.ToString();
                    Wholesaleone.Checked = pinfo.Wholesaleone == 1 ? true : false;
                    ComModelID.Value = pinfo.ComModelID.ToString();
                    if (pinfo.FarePrice == "") //判断运费类型：免运费or运费;要运费则输出价格
                    {
                        rdoFarePrice.SelectedValue = "0";
                    }
                    else 
                    {
                        farediv.Visible = true;
                        rdoFarePrice.SelectedValue = "1";
                        string[] price = pinfo.FarePrice.Split(',');
                        string[] price1=price[0].Split(new char[]{'|'});
                        string[] price2 = price[1].Split(new char[] { '|' });
                        string[] price3 = price[2].Split(new char[] {'|' });

                        this.FareID1.Value = price1[0].ToString();
                        this.FarePrice1.Text = price1[1].ToString();
                        this.FareID2.Value = price2[0].ToString();
                        this.FarePrice2.Text = price2[1].ToString();
                        this.FareID3.Value = price3[0].ToString();
                        this.FarePrice3.Text = price3[1].ToString();
                    }

                    if (pinfo.ProClass == 3)
                    {
                        txtPoint.Enabled = true;
                        ShiPrice.Enabled = false;
                        LinPrice.Enabled = false;
                    }
                    else
                    {
                        txtPoint.Enabled = false;
                        ShiPrice.Enabled = true;
                        LinPrice.Enabled = true;
                    }
                    this.HiddenUser.Value = pinfo.AddUser;
                    if (pinfo.Istrue == 1)
                    {
                        this.istrue.Checked = true;
                    }
                    else
                    {
                        this.istrue.Checked = false;
                    }
                    string presets = pinfo.Preset;
                    if (!string.IsNullOrEmpty(presets))
                    {
                        if (presets.IndexOf(",") > -1)
                        {
                            string[] presetarr = presets.Split(new string[] { "," }, StringSplitOptions.None);
                            for (int s = 0; s < presetarr.Length; s++)
                            {
                                M_Promotions proinfo = pro.GetPromotionsByid(DataConverter.CLng(presetarr[s]));
                                if (proinfo == null) continue;
                                this.OtherProject.Items.Add(new ListItem(proinfo.Promoname, proinfo.Id.ToString()));
                            }
                        }
                        else
                        {
                            M_Promotions proinfo = pro.GetPromotionsByid(DataConverter.CLng(presets));
                            if (proinfo!= null)
                            this.OtherProject.Items.Add(new ListItem(proinfo.Promoname, proinfo.Id.ToString()));
                        }
                    }

                    if (this.OtherProject.Items.Count > 0)
                    {
                        for (int d = 0; d < this.OtherProject.Items.Count; d++)
                        {
                            this.OtherProject.Items[d].Selected = true;
                        }
                    }
                    string SpecId = this.bspec.GetSpec(pinfo.ComModelID);
                    HdnSpec.Value = SpecId;
                    rdoUserPrice.SelectedValue = pinfo.UserType.ToString();
                    if (pinfo.UserType == 0)
                    {
                        userPrice.Text = pinfo.UserPrice;
                        userP.Visible = true;
                        divGroup.Visible = false;

                    }
                    else
                    {
                        userP.Visible = false;
                        divGroup.Visible = true;
                        string[] prices = pinfo.UserPrice.Split(',');
                        if (prices != null && prices.Length > 0)
                        {
                            for (int i = 0; i < repGroup.Items.Count; i++)
                            {
                                string gid = (repGroup.Items[i].FindControl("groupID") as HiddenField).Value;
                                for (int j = 0; j < prices.Length; j++)
                                {
                                    string[] price = prices[j].Split('|');
                                    if (price != null && price.Length > 0 && price[0] == gid)
                                    {
                                        (repGroup.Items[i].FindControl("GroupPrice") as TextBox).Text = price[1];
                                    }
                                }
                            }
                        }
                    }
                    txtBookPrice.Text = pinfo.BookPrice.ToString();
                    txtBookDay.Text = pinfo.bookDay.ToString();
                    txtDayPrice.Text = pinfo.FestlPrice.ToString();
                    if (pinfo.FestPeriod.Split('|') != null && pinfo.FestPeriod.Split('|').Length > 1)
                    {
                        CheckInDate.Text = pinfo.FestPeriod.Split('|')[0];
                        CheckOutDate.Text = pinfo.FestPeriod.Split('|')[1];
                        serverdate.Value = CheckInDate.Text;
                        CheckOut.Value = CheckOutDate.Text;
                    }
                    ShowSpec(SpecId);
                    string hiddenspid = ",";
                    if (pinfo.Priority == 1)//是否为绑定
                    {
                        string spanhtml = "<TABLE id=txtTables border=0 cellSpacing=1 cellPadding=1 width=\"100%\"><TBODY><TR class=tdbgleft><TD height=24 width=\"5%\" align=middle><STRONG>ID</STRONG></TD><TD height=24 width=\"5%\" align=middle><SPAN name=\"CheckBox1\"><INPUT id=CheckAllCheckBox1 onclick=CheckAll(this); type=checkbox name=CheckAllCheckBox1></SPAN></TD><TD height=24 width=\"10%\" align=middle><STRONG>商品图片</STRONG></TD><TD height=24 width=\"35%\" align=middle><STRONG>商品名称</STRONG></TD><TD height=24 width=\"15%\" align=middle><STRONG>商品数量</STRONG></TD><TD height=24 width=\"20%\" align=middle><STRONG>商品零售价</STRONG></TD><TD height=24 width=\"15%\" align=middle><STRONG>操作</STRONG></TD></TR><TR class=tdbg>";
                        B_BindPro db = new B_BindPro();
                        DataTable bind = db.Select_Where("BindProID=" + pid + "", "");
                        for (int so = 0; so < bind.Rows.Count; so++)
                        {
                            spanhtml = spanhtml + "<TR class=tdbg><td height=24 align=center>" + bind.Rows[so]["ProID"].ToString() + "</TD><TD height=24 align=center><INPUT name=Item id=Item" + bind.Rows[so]["ProID"].ToString() + " checked type=checkbox value=" + bind.Rows[so]["ProID"].ToString() + "></TD><TD height=24 align=center>" + getproimg(bll.GetproductByid(DataConverter.CLng(bind.Rows[so]["ProID"].ToString())).Thumbnails) + "</TD><TD height=24 align=center>" + bind.Rows[so]["Proname"].ToString() + "</TD><TD height=24 align=center><INPUT name=pronum" + bind.Rows[so]["ProID"].ToString() + " type=text value=" + bind.Rows[so]["Pronum"].ToString() + " id=pronum" + bind.Rows[so]["ProID"].ToString() + " style=width:54px; /></TD><TD height=24 align=center>" + string.Format("{0:C}", DataConverter.CDouble(bind.Rows[so]["jiage"])) + "</TD><TD align=center onclick=deleteRow('txtTables',this.parentElement.rowIndex,'" + bind.Rows[so]["ProID"].ToString() + "')><U style=cursor:pointer>删除</U></TD></TR>";
                            hiddenspid = hiddenspid + bind.Rows[so]["ProID"].ToString() + ",";
                        }
                        spanhtml = spanhtml + "</TBODY></TABLE>";
                        this.Span1.InnerHtml = spanhtml;                      
                        this.Hiddenbind.Value = hiddenspid;
                    }
                    LinPrice.Enabled = true;
                    ShiPrice.Enabled = true;
                    string winfo = pinfo.Wholesalesinfo;
                    string[] winfos = winfo.Split(new char[] { ',' });
                    string[] winfos1 = winfos[0].Split(new char[] { '|' });
                    string[] winfos3 = null;
                    string[] winfos2 = null;
                    if (winfos1.Length > 1)
                    {
                        winfos2 = winfos[1].Split(new char[] { '|' });
                        winfos3 = winfos[2].Split(new char[] { '|' });
                    }
                    if (winfos1 != null && winfos1.Length > 0)
                    {
                        this.s1.Text = winfos1[0].ToString();
                    }
                    if (winfos1 != null && winfos1.Length > 1)
                    {
                        this.j1.Text = winfos1[1].ToString();
                    }

                    if (winfos2 != null && winfos2.Length > 0)
                    {
                        this.s2.Text = winfos2[0].ToString();
                    }
                    if (winfos2 != null && winfos2.Length > 1)
                    {
                        this.j2.Text = winfos2[1].ToString();
                    }

                    if (winfos3 != null && winfos3.Length > 0)
                    {
                        this.s3.Text = winfos3[0].ToString();
                    }
                    if (winfos3 != null && winfos3.Length > 1)
                    {
                        this.j3.Text = winfos3[1].ToString();
                    }

                    I_tem.Value = pinfo.ItemID.ToString();
                    Integral.Text = pinfo.Integral.ToString();
                    UpdateTime.Text = pinfo.UpdateTime.ToString();
                    ModeTemplate.Text = pinfo.ModeTemplate.ToString();
                    Wholesales.Checked = pinfo.Wholesales == 1 ? true : false;
                    if (pinfo.ProClass == 4)  //团购
                    {
                        ColonelStartTimetxt.Text = pinfo.AddTime.ToString();
                        txtColoneDeposit.Text = pinfo.ColoneDeposit.ToString();
                        if (!string.IsNullOrEmpty(pinfo.ColonelTime))
                        {
                            string[] time = pinfo.ColonelTime.Split('|');
                            if (time != null && time.Length > 1)
                            {
                                ColonelStartTimetxt.Text = time[0];
                                ColonelendTimetxt.Text = time[1];
                                //如果团购已经开始,且未结束，不允许修改
                                if (DataConverter.CDate(time[0]) <= DateTime.Now && DataConverter.CDate(time[1]) >=DateTime.Now)
                                {
                                    ColonelStartTimetxt.Enabled = false;
                                    ColonelendTimetxt.Enabled = false;
                                    hfBeginTime.Value = time[0];
                                    hfEndTime.Value = time[1];
                                }
                            }
                        }
                    }
                    Wholesaleone.Checked = pinfo.Wholesaleone == 1 ? true : false;
                    if (pinfo.Isnew == 1) { isnew.Checked = true; }
                    if (pinfo.Ishot == 1) { ishot.Checked = true; }
                    if (pinfo.Isbest == 1) { isbest.Checked = true; }
                    if (pinfo.Sales == 1) { Sales.Checked = true; }
                    if (pinfo.Allowed == 1) { Allowed.Checked = true; }
                    DataTable dr = bll.Getmodetable(pinfo.TableName.ToString(), DataConverter.CLng(pinfo.ItemID));
                    if (dr != null && dr.Rows.Count > 0)
                    {
                        this.ModelHtml.Text = this.bfield.GetUpdateHtml(this.ModelID, NodeID, dr);
                    }
                    ProjectType.Text = pinfo.ProjectType.ToString();
                    IntegralNum.Text = pinfo.IntegralNum.ToString();
                    switch (pinfo.ProjectType)
                    {
                        case 1:
                            break;
                        case 2:
                            this.ProjectPronum2.Text = pinfo.ProjectPronum.ToString();
                            break;
                        case 3:
                            this.ProjectPronum3.Text = pinfo.ProjectPronum.ToString();
                            this.Productsname3.Text = pinfo.PesentNames.ToString();
                            this.HiddenField3.Value = pinfo.PesentNameid.ToString();
                            break;
                        case 4:
                            this.ProjectPronum4.Text = pinfo.ProjectPronum.ToString();
                            break;
                        case 5:
                            this.ProjectPronum5.Text = pinfo.ProjectPronum.ToString();
                            this.Productsname5.Text = pinfo.PesentNames.ToString();
                            this.HiddenField5.Value = pinfo.PesentNameid.ToString();
                            break;
                        case 6:
                            this.ProjectMoney7.Text = pinfo.ProjectMoney.ToString();
                            this.Productsname6.Text = pinfo.PesentNames.ToString();
                            this.HiddenField6.Value = pinfo.PesentNameid.ToString();
                            break;
                        case 7:
                            this.ProjectMoney7.Text = pinfo.ProjectMoney.ToString();
                            this.Productsname7.Text = pinfo.PesentNames.ToString();
                            this.HiddenField7.Value = pinfo.PesentNameid.ToString();
                            break;
                    }
                    switch (pinfo.GuessType)
                    {
                        case 1:
                            Radio1.Checked = true;
                            Radio2.Checked = false;
                            Radio3.Checked = false;
                            break;
                        case 2://秒杀
                            Radio1.Checked = false;
                            Radio2.Checked = true;
                            Radio3.Checked = false;
                            if (!string.IsNullOrEmpty(pinfo.GuessXML))
                            {
                                XmlDocument xmlDoc = new XmlDocument();
                                xmlDoc.LoadXml(pinfo.GuessXML);
                                XmlNodeList nodeList = xmlDoc.SelectSingleNode("GuessXML").ChildNodes;
                                TextBox3.Text = function.GetXmlNode(nodeList, "StartBiddingDate");//秒杀时间段（开始）
                                TextBox4.Text = function.GetXmlNode(nodeList, "EndBiddingDate");//秒杀时间段（结束）
                                TextBox7.Text = function.GetXmlNode(nodeList, "SingleNum");//购买数量
                                TextBox8.Text = function.GetXmlNode(nodeList, "BuyNum");//开放秒杀商品数量
                            }
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>ShowGuess(2)</script>");
                            break;
                        case 3://竞拍
                            Radio1.Checked = false;
                            Radio2.Checked = false;
                            Radio3.Checked = true;
                            string s = "1";
                            if (!string.IsNullOrEmpty(pinfo.GuessXML))
                            {
                                XmlDocument xmlDoc = new XmlDocument();
                                xmlDoc.LoadXml(pinfo.GuessXML);
                                XmlNodeList nodeList = xmlDoc.SelectSingleNode("GuessXML").ChildNodes;
                                txtStime.Text = function.GetXmlNode(nodeList, "StartBiddingDate");//竞拍起始时间
                                txtEtime.Text = function.GetXmlNode(nodeList, "EndBiddingDate");//竞拍结束时间
                                RadioButtonList1.SelectedValue = function.GetXmlNode(nodeList, "GuessPattern");//竞拍模式
                                TextBox11.Text = function.GetXmlNode(nodeList, "StartPrice");//竞拍起始价格
                                //TextBox12.Text = function.GetXmlNode(nodeList, "Margin");//竞拍保证金
                                TextBox5.Text = function.GetXmlNode(nodeList, "ComeNumber");//Cometype 1：不干扰，2：按达到人数干扰，3：按达到金额干扰，4：按倒计时干扰
                                s = function.GetXmlNode(nodeList, "Cometype");//干扰类型
                                switch (s)
                                {
                                    case "1":
                                        Radio4.Checked = true;
                                        Radio5.Checked = false;
                                        Radio6.Checked = false;
                                        Radio7.Checked = false;
                                        break;
                                    case "2":
                                        Radio4.Checked = false;
                                        Radio5.Checked = true;
                                        Radio6.Checked = false;
                                        Radio7.Checked = false;
                                        break;
                                    case "3":
                                        Radio4.Checked = false;
                                        Radio5.Checked = false;
                                        Radio6.Checked = true;
                                        Radio7.Checked = false;
                                        break;
                                    case "4":
                                        Radio4.Checked = false;
                                        Radio5.Checked = false;
                                        Radio6.Checked = false;
                                        Radio7.Checked = true;
                                        break;
                                }

                                TextBox9.Text = function.GetXmlNode(nodeList, "Views");//干扰次数
                                TextBox10.Text = function.GetXmlNode(nodeList, "InterferenceInterval");//干扰时间间隔
                                TextBox12.Text = function.GetXmlNode(nodeList, "Times");//干扰次数
                                DropDownList1.SelectedValue = function.GetXmlNode(nodeList, "TimeUnits");//时间单位
                                RadioButtonList2.SelectedValue = function.GetXmlNode(nodeList, "InterferencePrice");//干扰价格
                                hfNum.Value = function.GetXmlNode(nodeList, "Number");
                                string suser = function.GetXmlNode(nodeList, "User");//参与干扰会员
                                if (!string.IsNullOrEmpty(suser))
                                {
                                    string[] arr = suser.Split(',');
                                    for (int x = 0; x < arr.Length; x++)
                                    {
                                        M_UserInfo mu = bu.GetUserByUserID(DataConverter.CLng(arr[x]));
                                        this.ListBox1.Items.Add(new ListItem(mu.UserName, mu.UserID + ""));
                                    }
                                    for (int y = 0; y < this.ListBox1.Items.Count; y++)
                                    {
                                        this.ListBox1.Items[y].Selected = true;
                                    }
                                }
                            }
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "ShowGuess(3);ShowInterference(" + s + ");", true);
                            break;
                            case 4:
                                break;
                    }
                }
                else
                {
                    this.isnew.Checked = true;
                    this.Sales.Checked = true;
                    this.ModelHtml.Text = this.bfield.GetInputHtml(this.ModelID, this.NodeID);
                    this.btnAdd.Visible = false;
                }
                if (Request.QueryString["groupby"] != null)//
                {
                    if (Request.QueryString["groupby"] == "1")
                    {
                        ShowGroupBuy();
                    }
                }
            }
            Call.SetBreadCrumb(Master, "<li><a href='" + CustomerPageAction.customPath2 + "I/Main.aspx'>工作台</a></li><li><a href='ProductManage.aspx'>商城管理</a></li><li><a href='ProductManage.aspx?NodeID='>" + str1 + "</a></li><li class='active'>" + str2 + "</li>");
        }
        //private string GetFlolar(int fid, int num)
        //{
        //    M_S_Flolar muserflorar = buserflo.GetSelect(fid);
        //    if (muserflorar != null && muserflorar.ID > 0)
        //    {
        //        B_S_Flolar bsflolar = new B_S_Flolar();
        //        M_S_Flolar msflolar = bsflolar.GetSelect(muserflorar.ID);
        //        return " <td height='24' align='center'>" + muserflorar.ID + "</td> <td height='24' align='center'>"
        //               + "<input name='Items' id='Items" + muserflorar.ID + "' type='checkbox' value='" + muserflorar.ID + "'></td>"
        //               + "<td height='24' align='center'>" + msflolar.Flo_Name + "</td><td height='24' align='center'><input "
        //               + "name='pronums" + muserflorar.ID + "' type='text' class='l_input' value='" + num + "' id='pronums" + muserflorar.ID + "'"
        //               + " onchange=\"numChange('" + muserflorar.ID + "')\"  style='width: 54px;' /></td><td height='24' align='center'>"
        //               + "<span class='l_input' id='prices" + muserflorar.ID + "' style='width: 54px;'>￥" + muserflorar.Flo_Price.ToString("0.00") + "</span></td>"
        //               + "<td height='24' align='center'><span class='l_input' id='bookprice" + muserflorar.ID + "' style='width: 54px;'>￥" + muserflorar.Flo_BookPrice.ToString("0.00") + "</span></td>"
        //         + "<td height='24' align='center'><span class='l_input' id='festprice" + muserflorar.ID + "' style='width: 54px;'>￥" + muserflorar.Flo_FestlPrice.ToString("0.00") + "</span></td>";
        //    }
        //    else
        //    {
        //        return "";
        //    }
        //}
        public string getproimg(string type)
        {
            string restring;
            restring = "";

            if (!string.IsNullOrEmpty(type)) { type = type.ToLower(); }
            if (!string.IsNullOrEmpty(type) && (type.IndexOf(".gif") > -1 || type.IndexOf(".jpg") > -1 || type.IndexOf(".png") > -1))
            {
                restring = "<img src=../../" + type + " border=0 width=60 height=45>";
            }
            else
            {
                restring = "<img src=../../UploadFiles/nopic.gif border=0 width=60 height=45>";
            }
            return restring;

        }
        private void ShowSpec(string SpecID)
        {
            if (SpecID == "")
            {
                this.lblSpec.InnerHtml = "<span id='SpecialSpanId0'>无专题<br /></span>";
            }
            else
            {
                string[] SpecArr = SpecID.Split(new char[] { ',' });
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < SpecArr.Length; i++)
                {
                    sb.Append("<span id='SpecialSpanId" + SpecArr[i] + "'>" + this.bspec.GetSpecName(DataConverter.CLng(SpecArr[i])));
                    sb.Append(" <input type=\"button\" class=\"btn btn-primary\" value=\"从此专题中移除\" onclick=\"DelSpecial(" + SpecArr[i] + ");\">");
                    sb.Append("<br /></span>");
                }
                this.lblSpec.InnerHtml = sb.ToString();
            }
        }
        ///// <summary>
        ///// 添加绑定花材
        ///// </summary>
        ///// <param name="id">商品ID</param>
        //private void addBindflo(int id)
        //{
        //    string ids = HiddenField1.Value;  //花材ID
        //    string[] flids = ids.Split(',');
        //    string[] nums = hidNum.Value.Split(',');
        //    if (flids != null && flids.Length > 0 && nums != null && flids.Length == nums.Length)
        //    {
        //        bindflolar.DeleteBySid(id);
        //        for (int i = 0; i < flids.Length; i++)
        //        {
        //            if (DataConverter.CLng(flids[i]) > 0 && DataConverter.CLng(nums[i]) > 0)
        //            {
        //                M_BindFlolar mbin = new M_BindFlolar();
        //                mbin.Addtime = DateTime.Now;
        //                mbin.BindSid = DataConverter.CLng(flids[i]);
        //                mbin.Shopid = id;
        //                mbin.SNum = DataConverter.CLng(nums[i]);
        //                mbin.Userid = -1;
        //                bindflolar.GetInsert(mbin);
        //            }
        //        }
        //    }
        //}
        protected void EBtnSubmit_Click1(object sender, EventArgs e)
        {
            if (Request.Form["ProClass"].Equals("4"))
            {
                if (ColonelStartTimetxt.Text.Trim() == "")
                {
                    function.WriteErrMsg("请输入团购开始时间"); 
                }
                if (ColonelendTimetxt.Text.Trim() == "")
                {
                    function.WriteErrMsg("请输入团购结束时间");
                }
                if (txtColoneDeposit.Text.Trim() == "")
                {
                    function.WriteErrMsg("请输入团购订金");
                }
            }
            ////保存商品
            this.ModelID = DataConverter.CLng(this.HdnModel.Value);
            this.NodeID = DataConverter.CLng(this.HdnNode.Value);
            IList<string> content = new List<string>();
            DataTable dt = this.bfield.GetModelFieldList(this.ModelID).Tables[0];
            Call commonCall = new Call();
            DataTable table = commonCall.GetDTFromPage(dt, this.Page, ViewState, content);
            string adminname = StringHelper.Base64StringDecode(HttpContext.Current.Request.Cookies["ManageState"]["LoginName"]);
            int Statusrs = 0;
            int istrue = 0;
            if (this.istrue.Checked)
            {
                Statusrs = 99;
                istrue = 1;
            }
            M_CommonData CCate = new M_CommonData();
            CCate.NodeID = this.NodeID;
            CCate.ModelID = this.ModelID;
            CCate.TableName = this.bmode.GetModelById(this.ModelID).TableName;           
            CCate.Title = sll.ProcessSen(this.Proname.Text);
            CCate.Status = Statusrs;
            CCate.Inputer = adminname;
            CCate.PdfLink = "";
            CCate.FirstNodeID = GetFriestNode(this.NodeID);
            if (DataConverter.CLng(Dengji.SelectedValue) > 3)
            {
                CCate.EliteLevel = 1;
            }
            else
            {
                CCate.EliteLevel = 0;
            }
            CCate.InfoID = "";
            CCate.SpecialID = "";
            CCate.Template = ModeTemplate.Text;
            CCate.DefaultSkins = 0;

            M_Product CData = new M_Product();

            CData.ID = DataConverter.CLng(ID.Value);
            CData.Class = 0;
            CData.Nodeid = this.NodeID;
            CData.ModelID = DataConverter.CLng(HdnModel.Value);
            CData.Categoryid = DataConverter.CLng(Categoryid.Value);
            CData.AddUser = string.IsNullOrEmpty(txtCountHits.Text) ? adminname : txtCountHits.Text;
            CData.ProCode = (ProCode.Text.Trim() == null) ? this.ProCode.Text : ProCode.Text;
            CData.BarCode = BarCode.Text.Trim();
            CData.Proname = Proname.Text.Trim();
            CData.Kayword = Kayword.Text;
            CData.ProUnit = ProUnit.Text;
            CData.AllClickNum = DataConverter.CLng(Request.Form["AllClickNum"]);
            CData.Weight = DataConverter.CLng(Weight.Text);
            CData.ServerPeriod = DataConverter.CLng(ServerPeriod.Text);
            CData.ServerType = DataConverter.CLng(ServerType.SelectedValue);
            CData.ProClass = DataConverter.CLng(Request.Form["ProClass"]);
            if (CData.ProClass == 4)
            {
                if (!string.IsNullOrEmpty(hfBeginTime.Value.Trim()) && !string.IsNullOrEmpty(hfEndTime.Value))
                {
                    CData.ColonelTime = hfBeginTime.Value + "|" + hfEndTime.Value;
                }
                else
                {
                    CData.ColonelTime = ColonelStartTimetxt.Text + "|" + ColonelendTimetxt.Text;
                    CData.Sold = 0;
                }
            }
            CData.ColoneDeposit = DataConverter.CDouble(txtColoneDeposit.Text);
            CData.Properties = 0;
            CData.PointVal = DataConverter.CLng(txtPoint.Text);
            CData.ItemID = DataConverter.CLng(I_tem.Value);
            if (Sales.Checked)
            {
                CData.Sales = 1;
            }
            CData.Wholesalesinfo = s1.Text + "|" + j1.Text + "," + s2.Text + "|" + j2.Text + "," + s3.Text + "|" + j3.Text;
            CData.Proinfo = Proinfo.Text;
            CData.Procontent = Procontent.Value;
            CData.Clearimg = txt_Clearimg.Text;
            CData.Thumbnails = txt_Thumbnails.Text;
            CData.Producer = Producer.Text;
            CData.Brand = Brand.Text;
            CData.Wholesales = Wholesales.Checked ? 1 : 0;
            CData.Wholesaleone = Wholesaleone.Checked ? 1 : 0;
            CData.Quota = DataConverter.CLng(Quota.Text);
            CData.DownQuota = DataConverter.CLng(DownQuota.Text);
            CData.Stock = (DataConverter.CLng(Stock.Text) == 0) ? DataConverter.CLng(this.Stock.Text) : DataConverter.CLng(Stock.Text);
            CData.StockDown = DataConverter.CLng(StockDown.Text);
            CData.JisuanFs = DataConverter.CLng(JisuanFs.SelectedValue);
            CData.Rate = DataConverter.CDouble(Rate.Text);
            CData.Rateset = DataConverter.CLng(Rateset.SelectedValue);
            CData.Dengji = DataConverter.CLng(Dengji.SelectedValue);
            CData.ShiPrice = DataConverter.CDouble(ShiPrice.Text);
            CData.LinPrice = DataConverter.CDouble(LinPrice.Text);
            CData.Preset = (OtherProject.SelectedValue == null) ? "" : OtherProject.SelectedValue;  //促销
            CData.Integral = DataConverter.CLng(Integral.Text);
            CData.Propeid = DataConverter.CLng(Propeid.Text);
            CData.Recommend = DataConverter.CLng(txtRecommend.Text);
            CData.Largesspirx = DataConverter.CLng(Largesspirx.Text);
            CData.AllClickNum = DataConverter.CLng(txtCountHits.Text);
            CData.UpdateTime = DataConverter.CDate(UpdateTime.Text);
            CData.ModeTemplate = ModeTemplate.Text;
            CData.FirstNodeID = GetFriestNode(this.NodeID);
            CData.bookDay = DataConverter.CLng(txtBookDay.Text);
            CData.BookPrice = DataConverter.CDouble(txtBookPrice.Text);
            CData.FestlPrice = DataConverter.CDouble(txtDayPrice.Text);
            CData.FestPeriod = CheckInDate.Text + "|" + CheckOutDate.Text;
            CData.UserType = DataConverter.CLng(rdoUserPrice.SelectedValue);
            if (rdoFarePrice.SelectedValue == "0")//保存运费信息
            {
                CData.FarePrice = "";
            }
            else 
            {
                CData.FarePrice = this.FareID1.Value + "|" + this.FarePrice1.Text + "," + this.FareID2.Value + "|" + this.FarePrice2.Text + "," + this.FareID3.Value + "|" + this.FarePrice3.Text;
            }
            if (rdoUserPrice.SelectedValue == "0")
            {
                CData.UserPrice = userPrice.Text;
            }
            else
            {
                for (int i = 0; i < repGroup.Items.Count; i++)
                {
                    string gid = (repGroup.Items[i].FindControl("groupID") as HiddenField).Value;
                    string gprice = (repGroup.Items[i].FindControl("GroupPrice") as TextBox).Text;
                    CData.UserPrice += gid + "|" + gprice + ",";
                }
            }
            if (!string.IsNullOrEmpty(this.HiddenUser.Value))
                CData.AddUser = this.HiddenUser.Value;
            else
                CData.AddUser = adminname;
            CData.DownCar = 0;
            CData.ProjectType = DataConverter.CLng(ProjectType.SelectedValue);
            switch (CData.ProjectType)
            {
                case 1:
                    CData.ProjectPronum = 0;
                    CData.ProjectMoney = 0;
                    CData.IntegralNum = DataConverter.CLng(IntegralNum.Text);
                    CData.PesentNames = "";
                    CData.PesentNameid = 0;
                    break;
                case 2:
                    CData.ProjectPronum = DataConverter.CLng(ProjectPronum2.Text);
                    CData.ProjectMoney = 0;
                    CData.IntegralNum = DataConverter.CLng(IntegralNum.Text);
                    CData.PesentNames = "";
                    CData.PesentNameid = 0;
                    break;
                case 3:
                    CData.ProjectPronum = DataConverter.CLng(ProjectPronum3.Text);
                    CData.ProjectMoney = 0;
                    CData.IntegralNum = DataConverter.CLng(IntegralNum.Text);
                    CData.PesentNames = Productsname3.Text;
                    CData.PesentNameid = DataConverter.CLng(HiddenField3.Value);
                    break;
                case 4:
                    CData.ProjectPronum = DataConverter.CLng(ProjectPronum4.Text);
                    CData.ProjectMoney = 0;
                    CData.IntegralNum = DataConverter.CLng(IntegralNum.Text);
                    CData.PesentNames = "";
                    CData.PesentNameid = 0;
                    break;
                case 5:
                    CData.ProjectPronum = DataConverter.CLng(ProjectPronum5.Text);
                    CData.ProjectMoney = 0;
                    CData.IntegralNum = DataConverter.CLng(IntegralNum.Text);
                    CData.PesentNames = Productsname5.Text;
                    CData.PesentNameid = DataConverter.CLng(HiddenField5.Value);
                    break;
                case 6:
                    CData.ProjectPronum = 0;
                    CData.ProjectMoney = DataConverter.CDouble(ProjectMoney6.Text);
                    CData.IntegralNum = DataConverter.CLng(IntegralNum.Text);
                    CData.PesentNames = Productsname6.Text;
                    CData.PesentNameid = DataConverter.CLng(HiddenField6.Value);
                    break;
                case 7:
                    CData.ProjectPronum = 0;
                    CData.ProjectMoney = DataConverter.CDouble(ProjectMoney7.Text);
                    CData.IntegralNum = DataConverter.CLng(IntegralNum.Text);
                    CData.PesentNames = Productsname7.Text;
                    CData.PesentNameid = DataConverter.CLng(HiddenField7.Value);
                    break;
            }


            if (UpdateTime.Text == "")
            {
                CData.UpdateType = 1;
                CData.AddTime = DateTime.Now;
            }
            else
            {
                CData.UpdateType = 2;
                CData.AddTime = DataConverter.CDate(UpdateTime.Text);
            }

            CData.TableName = this.bmode.GetModelById(this.ModelID).TableName;
            CData.Istrue = istrue;
            CData.Isgood = 0;
            CData.MakeHtml = 0;
            CData.ComModelID = DataConverter.CLng(ComModelID.Value);
            if (ishot.Checked)
            {
                CData.Ishot = 1;
            }
            else
            {
                CData.Ishot = 0;
            }
            if (isnew.Checked)
            {
                CData.Isnew = 1;
            }
            else
            {
                CData.Isnew = 0;
            }
            if (isbest.Checked)
            {
                CData.Isbest = 1;
            }
            else
            {
                CData.Isbest = 0;
            }

            if (Allowed.Checked)
            {
                CData.Allowed = 1;
            }
            else
            {
                CData.Allowed = 0;
            }
            StringBuilder sb = new StringBuilder();
            if (Radio1.Checked)
            {
                CData.GuessType = 1;
                CData.GuessXML = "";
            }
            if (Radio2.Checked)
            {
                CData.GuessType = 2;
                sb.Append("<GuessXML>");
                sb.Append("<StartBiddingDate>" + TextBox3.Text + "</StartBiddingDate>");//秒杀时间段（开始）
                sb.Append("<EndBiddingDate>" + TextBox4.Text + "</EndBiddingDate>");//秒杀时间段（结束）
                sb.Append("<SingleNum>" + TextBox7.Text + "</SingleNum>");//购买数量
                sb.Append("<BuyNum>" + TextBox8.Text + "</BuyNum>");//开放秒杀商品数量
                sb.Append("</GuessXML>");
                CData.GuessXML = sb.ToString();
            }
            if (Radio3.Checked)
            {
                CData.GuessType = 3;
                sb.Append("<GuessXML>");
                sb.Append("<StartBiddingDate>" + txtStime.Text + "</StartBiddingDate>");//竞拍时间段（开始）
                sb.Append("<EndBiddingDate>" + txtEtime.Text + "</EndBiddingDate>");//竞拍时间段（结束）
                sb.Append("<GuessPattern>" + RadioButtonList1.SelectedValue + "</GuessPattern>");//竞拍模式
                sb.Append("<Comet>");
                //sb.Append("<Margin>" + TextBox12.Text + "</Margin>");//竞拍保证金
                if (Radio4.Checked)
                    sb.Append("<Cometype>1</Cometype>");//干扰类型  不干扰
                if (Radio5.Checked)
                    sb.Append("<Cometype>2</Cometype>");//干扰类型  按达到人数干扰
                if (Radio6.Checked)
                    sb.Append("<Cometype>3</Cometype>");//干扰类型  按达到金额干扰
                if (Radio7.Checked)
                    sb.Append("<Cometype>4</Cometype>");//干扰类型  按达到倒计时干扰

                sb.Append("<ComeNumber>" + TextBox5.Text + "</ComeNumber>");////达到多少人开始干扰
                sb.Append("<ComeMon>" + TextBox6.Text + "</ComeMon>");////达到多少金额开始干扰
                sb.Append("<StartPrice>" + TextBox11.Text + "</StartPrice>");//起拍价格 
                sb.Append("<Views>" + TextBox9.Text + "</Views>");//干扰次数
                sb.Append("<Times>" + TextBox12.Text + "</Times>");//倒计时干扰

                sb.Append("<InterferenceInterval>" + TextBox10.Text + "</InterferenceInterval>");//干扰时间间隔
                sb.Append("<TimeUnits>" + DropDownList1.SelectedValue + "</TimeUnits>");//时间单位
                sb.Append("<InterferencePrice>" + RadioButtonList2.SelectedValue + "</InterferencePrice>");//干扰价格
                sb.Append("<User>" + ListBox1.SelectedValue + "</User>");//参与干扰会员
                sb.Append("</Comet>");
                if (string.IsNullOrEmpty(hfNum.Value))
                {
                    sb.Append("<Number>Comp_" + Convert.ToString(DateTime.Now.Year) + Convert.ToString(DateTime.Now.Month) + Convert.ToString(DateTime.Now.Day) + Convert.ToString(DateTime.Now.Hour) + Convert.ToString(DateTime.Now.Minute) + Convert.ToString(DateTime.Now.Second) + Convert.ToString(DateTime.Now.Millisecond) + "</Number>");//生成一个编号
                }
                else
                {
                    sb.Append("<Number>" + hfNum.Value + "</Number>");
                }
                sb.Append("</GuessXML>");
                CData.GuessXML = sb.ToString();
            }
            string ComePaht = System.Web.HttpContext.Current.Server.MapPath("/Config/ComeSendList.config");//商城竞拍
            if (ClickType.Value == "update")
            {
                //获取绑定商品
                B_BindPro bd = new B_BindPro();
                bd.Delete_Where("BindProID = " + CData.ID + "");
                string item = Request.Form["item"];
                if (!string.IsNullOrEmpty(item))
                {
                    if (item.IndexOf(",") > -1)//多个
                    {
                        string[] itemarr = item.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                        for (int it = 0; it < itemarr.Length; it++)
                        {
                            M_BindPro bdinfo = new M_BindPro();
                            bdinfo.ID = 0;
                            bdinfo.BindProID = DataConverter.CLng(CData.ID);
                            bdinfo.ProID = DataConverter.CLng(itemarr[it]);
                            bdinfo.ProName = bll.GetproductByid(bdinfo.ProID).Proname;
                            bdinfo.Jiage = bll.GetproductByid(bdinfo.ProID).LinPrice;
                            bdinfo.Pronum = DataConverter.CLng(Request.Form["Pronum" + itemarr[it].ToString()]);
                            bd.GetInsert(bdinfo);
                        }
                    }
                    else //单个
                    {
                        M_BindPro bdinfo = new M_BindPro();
                        bdinfo.ID = 0;
                        bdinfo.BindProID = DataConverter.CLng(CData.ID);
                        bdinfo.ProID = DataConverter.CLng(item);
                        bdinfo.ProName = bll.GetproductByid(bdinfo.ProID).Proname;
                        bdinfo.Jiage = bll.GetproductByid(bdinfo.ProID).LinPrice;
                        bdinfo.Pronum = DataConverter.CLng(Request.Form["Pronum" + item]);
                        bd.GetInsert(bdinfo);
                    }
                    CData.Priority = 1;
                    CData.Largess = 0;
                }
                else
                {
                    CData.Priority = 0;
                    CData.Largess = Largess.Checked ? 1 : 0;
                }
                string SpecID = HdnSpec.Value;
                if (!string.IsNullOrEmpty(SpecID))
                {
                    this.bspec.UpdateSpec(SpecID, DataConverter.CLng(ComModelID.Value));
                }
                this.bll.Update(table, CData, CCate);
                if (Radio3.Checked)
                {
                    AddRunlist ar = new AddRunlist();
                    ar.UpdateCome(CData.GuessXML, CData.ID);
                }
                //if (!string.IsNullOrEmpty(HiddenField1.Value))
                //{
                //    addBindflo(DataConverter.CLng(ID.Value));
                //}
                Response.Redirect("ContentShow.aspx?id=" + ID.Value + "&ModelId=" + ModelID + "&NodeId=" + NodeID);
            }
            else
            {
                int ModelID = this.bll.Add(table, CData, CCate);

                string specialid = this.HdnSpec.Value;

                if (!string.IsNullOrEmpty(specialid))
                {
                    string[] arr = specialid.Split(new char[] { ',' });
                    M_SpecInfo info = new M_SpecInfo();
                    info.InfoID = DataConverter.CLng(ModelID);
                    for (int i = 0; i < arr.Length; i++)
                    {
                        info.SpecialID = DataConverter.CLng(arr[i]);
                        this.bspec.Add(info);
                    }
                }

                DataTable pptable = bfield.SelectTableName("ZL_Commodities", "where ComModelID=" + ModelID + "");

                //获取绑定商品
                B_BindPro bd = new B_BindPro();
                string item = Request.Form["item"];
                if (!string.IsNullOrEmpty(item))
                {
                    if (item.IndexOf(",") > -1)//多个
                    {
                        string[] itemarr = item.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                        for (int it = 0; it < itemarr.Length; it++)
                        {
                            M_BindPro bdinfo = new M_BindPro();
                            bdinfo.ID = 0;
                            bdinfo.BindProID = DataConverter.CLng(pptable.Rows[0]["ID"]);
                            bdinfo.ProID = DataConverter.CLng(itemarr[it]);
                            bdinfo.ProName = bll.GetproductByid(bdinfo.ProID).Proname;
                            bdinfo.Jiage = bll.GetproductByid(bdinfo.ProID).LinPrice;
                            bdinfo.Pronum = DataConverter.CLng(Request.Form["Pronum" + itemarr[it].ToString()]);
                            bd.GetInsert(bdinfo);
                        }

                    }
                    else //单个
                    {
                        M_BindPro bdinfo = new M_BindPro();
                        bdinfo.ID = 0;
                        bdinfo.BindProID = DataConverter.CLng(pptable.Rows[0]["ID"]);
                        bdinfo.ProID = DataConverter.CLng(item);
                        bdinfo.ProName = pptable.Rows[0]["Proname"].ToString();
                        bdinfo.Jiage = DataConverter.CDouble(pptable.Rows[0]["LinPrice"].ToString());
                        bdinfo.Pronum = DataConverter.CLng(Request.Form["Pronum" + item]);
                        bd.GetInsert(bdinfo);
                    }
                    CData.Priority = 1;
                }
                else
                {
                    CData.Priority = 0;
                }
                CData.ID = DataConverter.CLng(pptable.Rows[0]["ID"]);
                CData.Nodeid = NodeID;
                bll.updateinfo(CData);

                M_Stock SDatac = new M_Stock();
                SDatac.id = 0;
                SDatac.proid = DataConverter.CLng(pptable.Rows[0]["ID"].ToString());
                SDatac.stocktype = 0;
                SDatac.proname = pptable.Rows[0]["Proname"].ToString();
                SDatac.danju = "[" + this.Proname.Text + "]商品发布初始库存";
                SDatac.adduser = adminname;
                SDatac.addtime = DateTime.Now;
                SDatac.content = "添加商品:" + this.Proname.Text + "入库";
                //SDatac.Pronum = DataConverter.CLng(this.Stock.Text);
                Sll.AddStock(SDatac);

                if (Radio3.Checked)
                {
                    AddRunlist ar = new AddRunlist();
                    ar.AddCome(CData.GuessXML, CData.ID);
                }
                if (ClickType.Value.Equals("add"))
                {
                    ViewState["cData"] = CData;
                }
                else
                {
                    Response.Redirect("ContentShow.aspx?id=" + CData.ID + "&ModelId=" + ModelID + "&NodeId=" + NodeID);
                }
            }
            if (dt != null)
            {
                dt.Dispose();
            }
        }
        protected void Editdown_Click(object sender, EventArgs e)
        {
            if (Radio1.Checked)
            {
                AddRunlist arr = new AddRunlist();
            }
        }
        //添加为新商品
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            ClickType.Value = "add";
            EBtnSubmit_Click1(sender, e);
            M_Product pr = (M_Product)ViewState["cData"];
            Response.Redirect("ContentShow.aspx?id=" + pr.ID + "&ModelId=" + pr.ModelID + "&NodeId=" + pr.Nodeid);            
        }
        /// <summary>
        /// 获得第一级节点ID
        /// </summary>
        /// <param name="NodeID"></param>
        /// <returns></returns>
        public int GetFriestNode(int NodeID)
        {
            GetNo(NodeID);
            return FNodeID;
        }
        protected int FNodeID = 0;
        public void GetNo(int NodeID)
        {
            M_Node nodeinfo = bnode.GetNodeXML(NodeID);
            int ParentID = nodeinfo.ParentID;
            if (DataConverter.CLng(nodeinfo.ParentID) > 0)
            {
                GetNo(nodeinfo.ParentID);
            }
            else
            {
                FNodeID = nodeinfo.NodeID;
            }
        }
        int pid;     
        private void ShowGroupBuy()
        {
            M_UserProduct pinfo = BUP.GetproductByid(pid);
            ColonelStartTimetxt.Text = pinfo.AddTime.ToString();
            ColonelStartTimetxt.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            //this.ProClass.SelectedValue = "4";
        }
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        
        protected void TGButtion_Click(object sender, EventArgs e)
        {
            this.NumberText.Text = "";
            this.TGPrice.Text = "";
            this.ColonelendTimetxt.Text = "";
            ColonelStartTimetxt.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        }
       /// <summary>
       /// 确定
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>    
        protected void Button14_Click(object sender, EventArgs e)
        {
            string number = this.NumberText.Text;
            string price = this.TGPrice.Text;
            if (number !="" && price != "")
            {
                M_ZL_GroupBuy GroupBuy = new M_ZL_GroupBuy();
                GroupBuy.Number = DataConverter.CLng(number);
                GroupBuy.Price = DataConverter.CDouble(price);
                int id =DataConverter.CLng( this.ID.Value);
                GroupBuy.ShopID = DataConverter.CLng(id);              
                zl_groupbuy.GetInsert(GroupBuy);
                function.WriteSuccessMsg("添加成功!");
            }
            else 
            {
                function.WriteSuccessMsg("添加失败!请人数或价格!");
            }
        }

        protected void rdoUserPrice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdoUserPrice.SelectedValue == "0")
            {
                userP.Visible = true;
                divGroup.Visible = false;
            }
            else
            {
                userP.Visible = false;
                divGroup.Visible = true;
            }
        }

        protected void rdoFarePrice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdoFarePrice.SelectedValue == "0")
            {
                farediv.Visible = false;
            }
            else
            {
                farediv.Visible = true;
            }
        }
        /// <summary>
        /// 绑定用户组
        /// </summary>
        private void BindGroup()
        {
            DataTable dt = bgroup.GetGroupList();
            if (dt != null && dt.Rows.Count > 0)
            {
                repGroup.DataSource = dt.DefaultView;
                repGroup.DataBind();
            }
        }

    }

}