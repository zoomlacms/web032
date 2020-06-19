<%@ page language="C#" autoeventwireup="true" masterpagefile="~/Common/Common.master" inherits="test_Delivery, App_Web_s4kkmov4" enableEventValidation="false" viewStateEncryptionMode="Never" %>
<asp:Content runat="server" ContentPlaceHolderID="head"><title>订单详情</title></asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="Content">
    
    <div class="container">
        <h3 style="font-weight:bold;">处理订单</h3>
        <table class="mytable">
            <tr><td class="tdbgleft">订单号</td><td><asp:Label runat="server" ID="OrderNo_L"></asp:Label></td></tr>
            <tr><td class="tdbgleft">购买会员</td><td><asp:Label runat="server" ID="UName_L"></asp:Label></td></tr>
            <tr><td class="tdbgleft">下单时间</td><td><asp:Label runat="server" ID="CDate_L"></asp:Label></td></tr>
            <tr><td class="tdbgleft">购买商品</td><td><asp:Label runat="server" ID="ProName_L"></asp:Label></td></tr>
            <tr><td class="tdbgleft">订单备注</td><td><asp:Label runat="server" ID="OrderMessage_L"></asp:Label></td></tr>
            <tr><td class="tdbgleft">配送地址</td><td><asp:Label runat="server" ID="Address_L"></asp:Label></td></tr>
            <tr><td class="tdbgleft">邮编</td><td><asp:Label runat="server" ID="ZipCode_L"></asp:Label></td></tr>
            <tr><td class="tdbgleft">手机</td><td><asp:Label runat="server" ID="Mobile_L"></asp:Label></td></tr>
            <tr><td class="tdbgleft">固定电话</td><td><asp:Label runat="server" ID="Phone_L"></asp:Label></td></tr>
            <tr><td class="tdbgleft">收货人</td><td><asp:Label runat="server" ID="Reuser_L"></asp:Label></td></tr>
            <tr><td class="tdbgleft">快递公司</td><td>
                <asp:DropDownList runat="server" ID="Express_DP" CssClass="form-control text_x" Visible="false">
                    <asp:ListItem Value="韵达快递" Selected="True">韵达快递</asp:ListItem>
                    <asp:ListItem Value="顺风快递">顺风快递</asp:ListItem>
                    <asp:ListItem Value="申通快递">申通快递</asp:ListItem>
                    <asp:ListItem Value="圆通快递">圆通快递</asp:ListItem>
                    <asp:ListItem Value="中通快递">中通快递</asp:ListItem>
                    <asp:ListItem Value="邮政EMS">邮政EMS</asp:ListItem>
                </asp:DropDownList>
                                              </td></tr>
            <tr><td class="tdbgleft">物流单号</td><td>
                <asp:TextBox runat="server" ID="ExpCode_T" CssClass="form-control text_300" ></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ExpCode_T" ID="R2" ForeColor="Red" ErrorMessage="单号不能为空" Display="Dynamic" />
                                              </td></tr>
        </table>
        <div class="margin_t5 text-center">
            <asp:Button runat="server" ID="Save_Btn" Text="保存" OnClick="Save_Btn_Click" CssClass="btn btn-primary" />
            <a href="javascript:;" onclick="parent.CloseDiag();" class="btn btn-default">返回</a>
        </div>
    </div>
    <style type="text/css">
        * {font-family:'Microsoft YaHei';}
        .mytable {width:100%;border:1px solid #ddd;color:gray;}
        .mytable tr td{padding:8px;}
        .tdbgleft {width:100px;text-align:right;}
    </style>
</asp:Content>