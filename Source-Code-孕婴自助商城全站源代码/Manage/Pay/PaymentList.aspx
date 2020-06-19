<%@ page language="C#" autoeventwireup="true" inherits="ZoomLa.WebSite.Manage.I.Pay.PaymentList, App_Web_pzg2iurs" masterpagefile="~/Manage/I/Default.master" enableEventValidation="false" viewStateEncryptionMode="Never" %>
<asp:Content runat="server" ContentPlaceHolderID="head">
    <title>充值信息管理</title>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="Content">
    <ol id="BreadNav" class="breadcrumb navbar-fixed-top">
        <li><a href=" <%=CustomerPageAction.customPath2 %>Main.aspx">工作台</a></li><li><a href="<%=CustomerPageAction.customPath2 %>Config/SiteInfo.aspx">系统设置</a></li><li><a href='PayPlatManage.aspx'>在线支付平台</a></li><li class="active">支付信息管理</li>
        <div id="help" class="pull-right text-center"><a href="javascript::" id="sel_btn" class="help_btn"><i class="fa fa-search"></i></a></div>
        <div id="sel_box" class="padding5">
            <div class="input-group" style="width: 280px;margin-left:5px;float:left;">
                <asp:DropDownList ID="Search_Drop" runat="server" CssClass="form-control" Style="width: 90px;border-right:none;">
		          <asp:ListItem Selected="True" Value="1">会员名</asp:ListItem>
		          <asp:ListItem Value="2">订单号</asp:ListItem>
		        </asp:DropDownList>
		        <asp:TextBox ID="Search_T" runat="server" CssClass="form-control" style="width:150px;border-right:none;"></asp:TextBox>
                <span class="input-group-btn">
		        <asp:LinkButton runat="server" ID="Search_Btn" OnClick="Serarch_Btn_Click" CssClass="btn btn-default"><span class="glyphicon glyphicon-search"></span></asp:LinkButton>
		        </span>
            </div>
            <div class="pull-left" style="margin-left:10px;">
                金额搜索:
                <asp:TextBox ID="MinMoney_T" runat="server" CssClass="form-control text_x"></asp:TextBox>
                -
                <asp:TextBox ID="MaxMoney_T" runat="server" CssClass="form-control text_x"></asp:TextBox>
                <asp:LinkButton ID="SearchMoney_Btn" CssClass="btn btn-default" OnClick="SearchMoney_Btn_Click" runat="server"><span class="glyphicon glyphicon-search"></span> </asp:LinkButton>
            </div>
        </div>
    </ol>
    <table class="table table-striped table-bordered table-hover">
        <tr>
            <td><asp:LinkButton ID="IDAsc" OnClick="IDAsc_Click" runat="server">ID</asp:LinkButton></td><td>会员名</td><td>订单号</td><td>支付平台</td><td><asp:LinkButton ID="PriceAsc" OnClick="PriceAsc_Click" runat="server">金额</asp:LinkButton></td><td>实际金额</td><td>交易状态</td><td>处理结果</td><td><asp:LinkButton ID="DateAsc" OnClick="DateAsc_Click" runat="server">完成时间<span class="glyphicon glyphicon-arrow-up"></span></asp:LinkButton></td> 
        </tr>
        <ZL:ExRepeater ID="RPT" runat="server" PageSize="20" PagePre="<tr><td colspan='10'><div class='text-center'>" PageEnd="</div></td></tr>">
        <ItemTemplate>
            <tr>
                <td><%#Eval("PaymentID") %></td>
                <td>
                    <a href="PaymentList.aspx?userid=<%#Eval("UserID") %>"><%#Eval("UserName") %></a>
                </td>
                <td>
                    <%#Eval("PaymentNum") %>
                </td>
                <td>
                    <%#Eval("PayPlatName") %>
                </td>
                <td>
                    <%#Eval("MoneyPay","{0:f2}") %>
                </td>
                <td>
                    <%#Eval("MoneyTrue","{0:f2}") %>
                </td>
                <td>
                    <%#GetStatus(Eval("Status","{0}")) %>
                </td>
                <td>
                    <%#GetCStatus(Eval("CStatus","{0}")) %>
                </td>
                <td>
                    <%#Eval("SuccessTime")%>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate></FooterTemplate>
    </ZL:ExRepeater>
    </table>
    <script>
        $(function () {
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
        });
    </script>
</asp:Content>
