﻿<%@ page language="C#" autoeventwireup="true" inherits="manage_Site_CloudLead, App_Web_yn5a5p2q" masterpagefile="~/Manage/I/Default.master" title="模板云台" enableEventValidation="false" viewStateEncryptionMode="Never" %>
<asp:Content runat="server" ContentPlaceHolderID="head">
<title>模板云台</title>
<style>#site_nav .site03 a { background: url(../../App_Themes/AdminDefaultTheme/images/site/menu_cur.png) left no-repeat; }</style>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="Content"> 
    <div id="mainDiv" class="padding5" style="text-align:center;">
        <iframe id="mainFrame" onload="frameInit(this);"  src="../Template/CloudLead.aspx" style="width:100%; height:800px;" frameborder=0 scrolling=no></iframe>
    </div>
   <script type="text/javascript">
       function frameInit(obj) {//设定高度，并隐藏iframe中的面包屑导航
           obj.height = window.frames["mainFrame"].document.body.scrollHeight*0.95
           $doc = window.frames['mainFrame'].document;
           $($doc).find(".r_navigation").hide();
       }
   </script>
</asp:Content>