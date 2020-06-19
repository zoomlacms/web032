﻿<%@ page language="C#" autoeventwireup="true" inherits="Zoomla.Website.manage.Shop.ProductManage, App_Web_s4kkmov4" masterpagefile="~/Manage/I/Default.master" enableEventValidation="false" viewStateEncryptionMode="Never" %>
<asp:Content runat="server" ContentPlaceHolderID="head">
<title>商品列表</title>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="Content">
<ol id="BreadNav" class="breadcrumb navbar-fixed-top">
    <li><a href='<%=CustomerPageAction.customPath2 %>Main.aspx'>工作台</a></li>
    <li><a href='ProductManage.aspx'>商城管理</a></li>
    <li class='active'><a href='ProductManage.aspx'>商品列表</a></li>
    <li class='active'><a href='<%=Request.RawUrl %>'>
        <asp:Label ID="NodeName_L" runat="server"></asp:Label></a></li>
    <div class="pull-right hidden-xs" style="padding-right: 10px;">
            <span><a href="/Class_<%:NodeID<=0?2:NodeID %>/Default.aspx" target="_blank" title="前台浏览"><span class="glyphicon glyphicon-eye-open"></span></a>
                <span onclick="opentitle('<%:NodeID %>','配置本节点');" class="glyphicon glyphicon-cog" title="配置本节点" style="cursor: pointer; margin-left: 5px;"></span></span></div>
</ol>
      <div class="clearfix"></div>
        <div class="btn-group" style="margin-top:2px;margin-bottom:2px;">
            <a class="btn btn-info" href="ProductManage.aspx?<%:"NodeID="+NodeID+"&StoreID="+StoreID+"&quicksouch=1"%>">商品列表</a>
            <a class="btn btn-info" href="ProductManage.aspx?<%:"NodeID="+NodeID+"&StoreID="+StoreID+"&flag=Elite"%>">推荐商品</a>
            <a class="btn btn-info" href="ProductManage.aspx?<%:"StoreID="+StoreID+"&quicksouch=15"%>">所有礼品</a>
            <a class="btn btn-info" href="ProductManage.aspx?<%:"StoreID="+StoreID+"&quicksouch=16"%>">已审核商品</a>
            <a class="btn btn-info" href="ProductManage.aspx?<%:"StoreID="+StoreID+"&quicksouch=17"%>">待审核商品</a>
            <a class="btn btn-info" href="PromotionBalance.aspx">推广管理</a>
            <a class="btn btn-info" href="ProductManage.aspx?<%:"NodeID="+NodeID+"&StoreID="+StoreID+"&quicksouch=18"%>">用户商品</a>
            <a class="btn btn-info" href="ProductManage.aspx?<%:"NodeID="+NodeID+"&StoreID="+StoreID+"&quicksouch=19"%>">合作商品</a>
        </div>
        <div class="clearfix"></div>
    <div style="background: #ddd; padding: 4px; margin-bottom:2px; border-radius: 4px; line-height: 35px; padding-left: 15px;">
        商品操作：<asp:Literal runat="server" ID="lblAddContent" ></asp:Literal>
        <span class="pull-right visible-xs visible-sm">
            <input type="button" class="btn btn-success m_modal" onclick="opentitle(<%:NodeID %>,'配置本节点');" value="节点选择" /></span>
        <div id="help" class="pull-right text-center pad_r10" style="padding-right:10px;">
            <span>商品数：</span><span class="pad_r10" runat="server" id="countsp"></span>
            <a href="javascript::" id="sel_btn" class="help_btn"><i class="fa fa-search"></i></a></div>
        <div id="sel_box" style="top:inherit;" class="padding5">
            <div style="display:inline-block;">
                    <asp:DropDownList ID="souchtable" CssClass="form-control" Width="120" runat="server">
                        <asp:ListItem Value="0">请选择</asp:ListItem>
                        <asp:ListItem Value="1" Selected="True">商品名称</asp:ListItem>
                        <asp:ListItem Value="2">商品简介</asp:ListItem>
                        <asp:ListItem Value="3">商品介绍</asp:ListItem>
                        <asp:ListItem Value="4">厂商</asp:ListItem>
                        <asp:ListItem Value="5">品牌/商标</asp:ListItem>
                        <asp:ListItem Value="6">条形码</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div style="display:inline-block;width:230px;">
                    <div class="input-group" style="position:relative;margin-bottom:-12px;">
                        <asp:TextBox ID="souchkey" placeholder="商品名称" runat="server" CssClass="form-control text_md" />
                        <span class="input-group-btn">
                            <asp:Button ID="souchok" runat="server" Text="搜索" class="btn btn-primary" OnClick="souchok_Click" />
                        </span>
                    </div>
                </div>
                <div style="display:inline-block;">
                    <asp:DropDownList ID="txtbyfilde" CssClass="form-control text_s" runat="server" OnSelectedIndexChanged="txtbyfilde_SelectedIndexChanged"></asp:DropDownList>
                    <asp:DropDownList ID="txtbyOrder" CssClass="form-control text_s" runat="server" OnSelectedIndexChanged="txtbyOrder_SelectedIndexChanged"></asp:DropDownList>
                </div>
                <div style="display:inline-block;">
                    <asp:DropDownList ID="quicksouch" style="width:120px;" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="quicksouch_SelectedIndexChanged">
                        <asp:ListItem Value="1">所有商品</asp:ListItem>
                        <asp:ListItem Value="2">正在销售的商品</asp:ListItem>
                        <asp:ListItem Value="3">未销售的商品</asp:ListItem>
                        <asp:ListItem Value="4">正常销售的商品</asp:ListItem>
                        <asp:ListItem Value="5">特价处理的商品</asp:ListItem>
                        <asp:ListItem Value="6">所有热销的商品</asp:ListItem>
                        <asp:ListItem Value="7">所有新品</asp:ListItem>
                        <asp:ListItem Value="8">所有精品商品</asp:ListItem>
                        <asp:ListItem Value="9">有促销活动的商品</asp:ListItem>
                        <asp:ListItem Value="10">实际库存报警的商品</asp:ListItem>
                        <asp:ListItem Value="11">预定库存报警的商品</asp:ListItem>
                        <asp:ListItem Value="12">已售完的商品</asp:ListItem>
                        <asp:ListItem Value="14">所有捆绑销售商品</asp:ListItem>
                        <asp:ListItem Value="15">所有礼品</asp:ListItem>
                        <asp:ListItem Value="16">已审核商品</asp:ListItem>
                        <asp:ListItem Value="17">待审核商品</asp:ListItem>
                    </asp:DropDownList>
                </div>
               <asp:DropDownList ID="SelProvince" Visible="false" runat="server" AutoPostBack="true" CssClass="form-control" Width="120" OnSelectedIndexChanged="SelProvince_SelectedIndexChanged"></asp:DropDownList>
               <asp:DropDownList ID="SelCity" Visible="false" runat="server" AutoPostBack="true" CssClass="form-control" Width="120" OnSelectedIndexChanged="SelCity_SelectedIndexChanged"></asp:DropDownList>
        </div>
    </div>
    <script type="text/javascript">
        function ShowImport() {
            $("#divImp").show("middle");
        }
    </script>
       <div id="divImp" class="divline">
            导入商城：<asp:FileUpload ID="FileUpload1" runat="server" style="display:inline;"/>
            <asp:Button ID="btImport" runat="server" Text="导 入" OnClick="btImport_Click" class="btn btn-default" />
            <asp:LinkButton ID="lbtnSaveTempter" runat="server" OnClick="lbtnSaveTempter_Click" CausesValidation="true">
            <span style="color:#0E529D;">下载<asp:Label runat="server" ID="NodeName_L1"></asp:Label> 的<asp:Label runat="server" ID="Item_L1"></asp:Label> 模型CSV导入模板</span>
            </asp:LinkButton>(下载后用EXCEL打开从第二行开始按规范填写并保存即可)
        </div>
        <ZL:ExGridView ID="EGV" runat="server" AutoGenerateColumns="False" DataKeyNames="id" PageSize="10" OnRowDataBound="Egv_RowDataBound" OnPageIndexChanging="Egv_PageIndexChanging" IsHoldState="false" OnRowCommand="Egv_RowCommand" AllowPaging="True" AllowSorting="True" CssClass="table table-striped table-bordered table-hover" EnableTheming="False" EnableModelValidation="True" EmptyDataText="无相关数据！！">
            <Columns>
                <asp:TemplateField HeaderStyle-Width="3%">
                    <ItemTemplate>
                        <input type="checkbox" name="idchk" value='<%#Eval("id") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="ID" HeaderStyle-Width="3%" DataField="ID" />
                <asp:TemplateField HeaderText="商品图片">
                    <HeaderStyle CssClass="td_m" />
                    <ItemTemplate>
                        <a href="ShowProduct.aspx?menu=edit&ModelID=<%#Eval("ModelID") %>&NodeID=<%#Eval("Nodeid") %>&id=<%#Eval("id")%>">
                            <img src="<%#getproimg() %>" class="img_50" onerror="this.src='/Images/nopic.gif'" />
                        </a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="商品名称">
                    <ItemTemplate>
                        <%#GetNode() %>
                        <a href="ShowProduct.aspx?menu=edit&ModelID=<%#Eval("ModelID") %>&NodeID=<%#Eval("Nodeid") %>&id=<%#Eval("id")%>" ondblclick="javascript:localhost.href('ShowProduct.aspx?menu=edit&ModelID={0}&NodeID={1}&id={2}'),<%#Eval("ModelID") %>,<%#Eval("Nodeid") %>,<%#Eval("id")%>"><%#(Eval("Priority", "{0}") == "1") && (Convert.ToInt32(Eval("Propeid","{0}")) > 0) ? "<font color=maroon>[绑]</font>  " : ""%><%#Eval("proname")%></a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="录入者" DataField="AddUser" HeaderStyle-Width="5%" />
                <asp:BoundField HeaderText="单位" DataField="ProUnit" HeaderStyle-Width="5%" />
                <asp:TemplateField HeaderText="库存">
                    <ItemTemplate>
                        <%#Stockshow(DataBinder.Eval(Container,"DataItem.id","{0}"))%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="价格">
                    <ItemTemplate>
                        <%#GetPrice()%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="类型">
                    <ItemTemplate>
                        <%#formatnewstype(Eval("ProClass",""))%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="商品属性">
                    <ItemTemplate>
                        <%#forisbest(DataBinder.Eval(Container,"DataItem.isbest","{0}"))%>
                        <%#forishot(DataBinder.Eval(Container,"DataItem.ishot","{0}"))%>
                        <%#forisnew(DataBinder.Eval(Container,"DataItem.isnew","{0}"))%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="销售中">
                    <ItemTemplate>
                        <%#formattype(DataBinder.Eval(Container,"DataItem.Sales","{0}"))%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="状态">
                    <ItemTemplate>
                        <%#GetStatus() %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="排序">
                    <ItemTemplate>
                        <asp:LinkButton ID="UpMove" CssClass="option_style" CommandName="UpMove" CommandArgument='<%# Eval("ID") %>' runat="server" >↑上移 </asp:LinkButton>
                        <asp:LinkButton ID="DownMove" CssClass="option_style" CommandName="DownMove" CommandArgument='<%# Eval("ID") %>' runat="server" >下移↓</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="操作">
                    <ItemTemplate> 
                        <a class="option_style" href="<%#GetShopUrl() %>" target="_blank" title="预览"><i class="fa fa-eye"></i></a>  
                        <a class="option_style" href="AddProduct.aspx?menu=edit&ModelID=<%#Eval("ModelID") %>&NodeID=<%#Eval("Nodeid") %>&id=<%#Eval("id")%>"><i class="glyphicon glyphicon-pencil" title="编辑"></i>编辑</a>  
                        <asp:LinkButton ID="Del1" runat="server" CssClass="option_style" CommandName="Del1" CommandArgument='<%# Eval("id") %>' OnClientClick="return confirm('确定要将商品移入回收站吗');" ><i class="glyphicon glyphicon-trash" title="删除"></i>删除</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </ZL:ExGridView>
        <table>
            <tr>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="开始销售" OnClick="Button1_Click" CssClass="btn btn-primary" />
                    <asp:Button ID="Button2" runat="server" Text="设为热卖" OnClick="Button2_Click" CssClass="btn btn-primary" />
                    <asp:Button ID="Button6" runat="server" Text="设为精品" OnClick="Button6_Click" CssClass="btn btn-primary" />
                    <asp:Button ID="Button5" runat="server" Text="设为新品" OnClick="Button5_Click" CssClass="btn btn-primary" />
                    <asp:Button ID="Button3" runat="server" Text="批量删除" CssClass="btn btn-primary" OnClick="Button3_Click" OnClientClick="return confirm('确定要将商品移入回收站吗'); " />
                    <asp:Button ID="Button4" runat="server" Text="停止销售" OnClick="Button4_Click" CssClass="btn btn-primary" />
                    <div style="height: 10px;"></div>
                    &nbsp;<asp:Button ID="Button7" runat="server" Text="取消热卖" OnClick="Button7_Click" CssClass="btn btn-primary" />
                    <asp:Button ID="Button8" runat="server" Text="取消精品" OnClick="Button8_Click" CssClass="btn btn-primary" />
                    <asp:Button ID="Button9" runat="server" Text="取消新品" OnClick="Button9_Click" CssClass="btn btn-primary" />
                    <asp:Button ID="Button10" runat="server" Text="批量移动" OnClick="btnMove_Click" UseSubmitBehavior="true" CssClass="btn btn-primary" />
                    <asp:Button ID="Button11" runat="server" Text="批量审核" UseSubmitBehavior="true" OnClick="Button11_Click" class="btn btn-primary" />
                    <asp:Button ID="Button12" runat="server" Text="取消审核" UseSubmitBehavior="true" OnClick="Button12_Click" class="btn btn-primary" />
                    <%--<asp:Button ID="MtrlsMrktng" runat="server" class="C_input" Text="商品推广" onclick="MtrlsMrktng_Click"/>--%>
                </td>
            </tr>
            <tr>
                <td>
                <strong>商品属性中的各项含义：</strong>
                <span style="color: blue;">精</span>----推荐精品， 
                <span style="color: red;">热</span>----热门商品， 
                <span style="color: green;">新</span>----推荐新品， 
                <span style="color: blue;">图</span>----有商品缩略图， 
                <span style="color: maroon;">绑</span>----捆绑商品销售
                </td>
            </tr>
        </table>
        <asp:HiddenField ID="HiddenField1" runat="server" />
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ScriptContent">
    <script type="text/javascript" src="/JS/ICMS/ZL_Common.js"></script>
    <script type="text/javascript" src="/JS/Controls/ZL_Dialog.js"></script>
    <script>
        var diag = new ZL_Dialog();
        function opentitle(nid, title) {
            if (!nid||nid == 0) alert("尚未选择节点");
            else {
                var url = "../Content/EditNode.aspx?NodeID=" + nid;
                diag.url = url;
                diag.title = title;
                diag.ShowModal();
            }
        }
        HideColumn("1,4,5,6,7,8,9,10,11,12");
        $("#sel_btn").click(function (e) {
            if ($("#sel_box").css("display") == "none") {
                $(this).addClass("active");
                $("#sel_box").slideDown(300);
            }
            else {
                $(this).removeClass("active");
                $("#sel_box").slideUp(200);
            }
        });
    </script>
    <style>
        .divline{padding: 5px; border: 1px solid rgb(221, 221, 221); border-radius: 4px; margin-bottom: 10px;display:none;}
        .divline li {float: left;margin-left: 8px;}
    </style>
</asp:Content>
