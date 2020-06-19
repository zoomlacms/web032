<%@ page language="C#" autoeventwireup="true" inherits="User_OrderProList, App_Web_jmufvrzf" masterpagefile="~/User/Default.master" enableEventValidation="false" viewStateEncryptionMode="Never" %>

<asp:Content runat="server" ContentPlaceHolderID="head">
    <title>订单商品列表</title>
    <style>
        .SumDiv li {
            list-style: none;
            float: left;
            margin-right: 50px;
            line-height: 10px;
        }
    </style>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="Content">
    <ol class="breadcrumb">
        <li>您现在的位置：<a title="网站首页" href="/"><%= Call.SiteName%></a></li>
        <li><a title="会员中心" href="/User/Default.aspx">会员中心</a></li>
        <li><a href="/User/PreViewOrder.aspx">我的订单</a></li>
        <li class="active">商品列表</li>
    </ol>
    <div class="panel panel-default">
        <div class="panel-body">
            <ZL:ExGridView runat="server" ID="EGV" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" EnableTheming="False"
                CssClass="table table-striped table-bordered table-hover" EmptyDataText="该订单或购物车下没有商品!!"
                OnPageIndexChanging="EGV_PageIndexChanging" OnRowCommand="EGV_RowCommand">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="ID" />
                    <asp:TemplateField HeaderText="商品名">
                        <ItemTemplate><a href=""><%#Eval("ProName") %></a></ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="商品数" DataField="Pronum" />
                    <asp:TemplateField HeaderText="金额">
                        <ItemTemplate><%#Eval("AllMoney","{0:F2}") %></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="日期">
                        <ItemTemplate><%#Eval("AddTime","{0:yyyy年MM月dd日 HH:mm}") %></ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <PagerStyle HorizontalAlign="Center" />
                <RowStyle Height="24px" HorizontalAlign="Center" />
            </ZL:ExGridView>
        </div>
        <div class="panel-footer">
            <ul class="SumDiv">
                <li>合计：<asp:Label ID="ojiage01" runat="server" Text=""></asp:Label>元</li>
                <li>运费：<asp:Label ID="oyunfei01" runat="server" Text=""></asp:Label>元</li>
                <li>实际金额：<span id="price_s"></span></li>
                <li>已付款：<asp:Label ID="labelmoney01" runat="server" Text=""></asp:Label>元</li>
                <li>快递单号：<asp:Label ID="label9" runat="server" Text=""></asp:Label><br />
                                <asp:LinkButton runat="server" CssClass="btn btn-primary" ID="ULB_Track" Text="查看快递详细信息>>" Visible="false"></asp:LinkButton></li>
            </ul>
        </div>
    </div>
    <script>
        $().ready(function () {
            $("#price_s").text($("#ojiage01").text() + "+" + $("#oyunfei01").text() +  "=" + (parseFloat($("#ojiage01").text()) + parseFloat($("#oyunfei01").text()) ));
        });
    </script>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ScriptContent"></asp:Content>
