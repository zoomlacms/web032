<%@ page language="C#" autoeventwireup="true" inherits="App_APPTlp_TlpList, App_Web_omwe1ggy" masterpagefile="~/Common/Commenu.master" enableEventValidation="false" viewStateEncryptionMode="Never" %>
<asp:Content runat="server" ContentPlaceHolderID="head">
<title>模板选择</title>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="Content">
    <div style="height:60px;"></div>
        <div class="template tlplist">
            <ul class="list-unstyled">
                <ZL:ExRepeater runat="server" ID="RPT" PageSize="14" PagePre="<div class='clearfix'></div><div class='text-center'>" PageEnd="</div>">
                    <ItemTemplate>
                        <li class="padding5">
                            <div class="Template_box">
                                <div class="tempthumil"><a href="<%#"Design.aspx?vpath="+Eval("VPath","").TrimEnd('/')+"/index.html" %>" title="点击在线设计">
                                    <img class="imghover" onerror="this.onerror=null;this.src='/Images/nopic.gif'" style="width: 100%;" src="<%#Eval("VPath")+"/View.png" %>"></a></div>
                                <span class="pull-left padding5"><a href="javascript:;"><%#Eval("TlpName") %></a></span>
                                <span class="pull-right">
                                    <a href='<%#Eval("VPath")+"/View.png" %>' class="lightbox" title="查看大图">
                                        <i class="fa fa-search-plus"></i></a></span></span>
                                <div class="clearfix"></div>
                                <div class="temp_foot">
                                    <i class="fa fa-user"></i><%#Eval("TlpName") %>
                                    <a href="<%#"Design.aspx?vpath="+Eval("VPath","").TrimEnd('/')+"/index.html" %>">在线设计</a>
                                </div>
                            </div>
                        </li>
                    </ItemTemplate>
                    <FooterTemplate></FooterTemplate>
                </ZL:ExRepeater>
            </ul>
        </div>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="Script">
    <link href="/App_Themes/V3.css" rel="stylesheet" />
    <style type="text/css">
        .Template_box {padding:0px;}
        .temp_foot {border-top:1px solid #ddd;background:#fafafa;height:2em;line-height:2em;padding-left:5px;}
        .tlplist li{width:auto;height:auto;}

    </style>
</asp:Content>