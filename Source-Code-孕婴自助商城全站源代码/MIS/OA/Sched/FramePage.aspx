﻿<%@ page language="C#" autoeventwireup="true" inherits="MIS_OA_FramePage, App_Web_olplgzmi" masterpagefile="~/User/Empty.master" enableEventValidation="false" viewStateEncryptionMode="Never" %>
<asp:Content runat="server" ContentPlaceHolderID="head">
<title>排班</title>
<script type="text/javascript">
    function selGroup(v) {
        $("#main_right").attr("src", "/Mis/OA/Sched/PBManage.aspx?gid=" + v);
    }
</script>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="Content">
  <div class="mainDiv">
    <div id="site_main">
        <div id="leftDiv" style="float:left;width:14%;">
            <iframe src="/Mis/OA/Mail/SelGroup.aspx?Type=null" style="width:100%;height:760px;" frameborder="0"></iframe>
        </div>
        <div id="rightDiv" style="float:right;width:84%;">
         <iframe id="main_right" src="/Mis/OA/Sched/PBManage.aspx" style="width:100%;height:760px;" frameborder="0"></iframe>
</div><!--RighDiv-->
</div>

      <div style="clear:both;"></div>
</div><!--MainDiv-->
</asp:Content>
