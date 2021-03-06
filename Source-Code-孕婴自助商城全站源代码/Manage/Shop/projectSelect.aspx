﻿<%@ page language="C#" autoeventwireup="true" inherits="manage_Shop_projectSelect, App_Web_s4kkmov4" enableviewstatemac="false" masterpagefile="~/Manage/I/Default.master" enableEventValidation="false" viewStateEncryptionMode="Never" %>
<asp:Content runat="server" ContentPlaceHolderID="head">
        <title>选择商品</title>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="Content">   
            <table class="table table-striped table-bordered table-hover">
                <tr class="title">
                    <td>
                        <b>产品列表：</b>
                           <div class="input-group nav_searchDiv">
                            <asp:TextBox runat="server" ID="TxtKeyWord" class="form-control" placeholder="请输入需要搜索的内容" />
                            <span class="input-group-btn">
                                <asp:LinkButton runat="server" CssClass="btn btn-default" ID="BtnSearch" OnClick="BtnSearch_Click"><span class="glyphicon glyphicon-search"></span></asp:LinkButton>
                            </span>
                        </div>

                    </td>
                </tr>
                <tr>
                    <td>
              <table class="table table-striped table-bordered table-hover">
                                     <tr class="tdbgleft">
             <td width="5%" height="24" align="center"><strong>ID</strong></td>
             <td width="5%" height="24" align="center">
             <asp:CheckBox ID="CheckBox1" name="CheckBox1" runat="server" onclick="CheckAll(this);" /></td>
                           <td width="25%" height="24" align="center"><strong>促销方案名称名称</strong></td>
              <td width="25%" height="24" align="center"><strong>价格区间</strong></td>
              <td width="25%" height="24" align="center"><strong>有效期</strong></td>
            </tr>
             <asp:Repeater ID="Pagetable" runat="server">
               <ItemTemplate>    
                  <tr class="tdbg">
                  <td height="24" align="center"><%#Eval("ID") %></td>
                  <td height="24" align="center"><input name="Item" id="Item<%#Eval("ID") %>" type="checkbox" value="<%#Eval("ID") %>"></td>
                  <td height="24" align="left"><%#Eval("Promoname")%><input type="hidden" id="Pronames<%#Eval("ID") %>" value="<%#Eval("Promoname") %>" /></td>
                  <td height="24" align="center"><%#Eval("Pricetop","{0:C}") %> ≤金额＜<%#Eval("Priceend", "{0:C}")%> </td>
                  <td height="24" align="center"><%#Eval("Promostart", "{0:yyyy-MM-dd}")%> 至 <%#Eval("Promoend","{0:yyyy-MM-dd}") %> </td>
                  </tr>
               </ItemTemplate>
            </asp:Repeater>
            <tr class="tdbg">
                <td class="tdbgleft" colspan="6" align="center">共 <asp:Label ID="Allnum" runat="server" Text=""></asp:Label> 条信息  <asp:Label ID="Toppage" runat="server" Text="" /> <asp:Label ID="Nextpage" runat="server" Text="" /> <asp:Label ID="Downpage" runat="server" Text="" /> <asp:Label ID="Endpage" runat="server" Text="" />  页次：<asp:Label ID="Nowpage" runat="server" Text="" />/<asp:Label ID="PageSize" runat="server" Text="" />页  <asp:Label ID="pagess" runat="server" Text="" />条信息/页  转到第<asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True">
              </asp:DropDownList>页
                </td>
            </tr>
            
             </table> 
             </td>
             </tr>
                 <tr>
                     <td colspan="2" align="center">
                         <asp:Button ID="Button1" class="btn btn-primary" runat="server" Text="添加捆绑" OnClientClick="GetCheckvalue();return false;" />
                         <asp:Button ID="Button2" class="btn btn-primary" runat="server" Text="取消添加" OnClientClick="window.close();return false;" /></td>
                 </tr>
             </table> 
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ScriptContent">
    <script type="text/javascript">
        function CheckAll(spanChk)//CheckBox全选
        {
            var oItem = spanChk.children;
            var theBox = (spanChk.type == "checkbox") ? spanChk : spanChk.children.item[0];
            xState = theBox.checked;
            elm = theBox.form.elements;
            for (i = 0; i < elm.length; i++)
                if (elm[i].type == "checkbox" && elm[i].id != theBox.id) {
                    if (elm[i].checked != xState)
                        elm[i].click();
                }
        }
        function GetCheckvalue() {
            var spanChk = window.document.getElementById("CheckBox1");
            var elm = document.form1.elements;
            var listbox = "";
            var listheight = 0;
            var listnum = 0;
            var boxlist = 0;
            var innterhtml = "";
            var hiddenidvalue = opener.document.getElementById("OtherProject"); //获取已经存在的ID值

            //循环本页选择的项目
            for (i = 0; i < elm.length; i++) {
                if (elm[i].type == "checkbox" && elm[i].id != spanChk.id) {
                    boxlist = boxlist + 1;
                    if (elm[i].checked == true) {
                        var tempvalue = "," + elm[i].value + ",";//初始ID
                        listheight = listheight + 1;
                        var Pronamesvalue = document.getElementById("Pronames" + elm[i].value).value;
                        //循环父页的Option值;
                        var addthis = true;
                        if (hiddenidvalue.options.length > 0) {
                            for (var ii = hiddenidvalue.options.length - 1; ii >= 0; ii--) {
                                if (hiddenidvalue[ii].text == document.getElementById("Pronames" + elm[i].value).value) {
                                    addthis = addthis && false;
                                }
                            }

                            if (addthis == true) {
                                var oOption = opener.document.createElement("option");
                                oOption.text = Pronamesvalue;
                                oOption.value = elm[i].value;
                                opener.document.getElementById("OtherProject").add(oOption);
                            }
                        }
                        else {
                            var oOption = opener.document.createElement("option");
                            oOption.text = Pronamesvalue;
                            oOption.value = elm[i].value;
                            opener.document.getElementById("OtherProject").add(oOption);
                        }
                    }
                }
            }

            for (var ii = hiddenidvalue.options.length - 1; ii >= 0; ii--) {
                opener.document.form1.OtherProject.options[ii].selected = true;
            }
            window.close();
        }
</script>
</asp:Content>