<%@ page language="C#" autoeventwireup="true" inherits="ZoomLa.WebSite.Manage.login, App_Web_ubxhlfyy" enableviewstatemac="false" clientidmode="Static" enableEventValidation="false" viewStateEncryptionMode="Never" %>
<%@ Register Src="~/Manage/I/ASCX/IE6.ascx" TagName="IE6" TagPrefix="IE6" %><!DOCTYPE HTML>
<html lang="zh-CN">
<head>
<title>管理登录</title>
<meta http-equiv="X-UA-Compatible" content="IE=edge">
<meta name="viewport" content="width=device-width, initial-scale=1.0">
<meta name="renderer" content="webkit">
<link href="/dist/css/bootstrap.min.css" rel="stylesheet"/>
<!--[if lt IE 9]>
	<script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
	<script src="https://oss.maxcdn.com/libs/respond.js/1.3.0/respond.min.js"></script>
<![endif]-->
<link href="/dist/css/font-awesome.min.css" rel="stylesheet"/>
<script type="text/javascript" src="/JS/jquery-1.11.0.min.js"></script>
<script src="/dist/js/bootstrap.min.js"></script>
<script type="text/javascript" src="/JS/ICMS/ZL_Common.js"></script>
<script type="text/javascript" src="/JS/ZL_ValidateCode.js"></script>
<link rel="stylesheet" href="/App_Themes/V3.css?id=20150520" />
<style>
.popover{width:300px; text-align:center;}
</style>
</head>
<body>
<form id="Login" runat="server"><IE6:IE6 runat="server" />
<center style="background:url(<%=Call.GetRandomImg()%>);background-position: center;left:0;top:0;right:0;bottom:0; position: absolute; background-repeat:no-repeat;background-size:cover;">
<div class="manage_login">
<ul class="list-unstyled">
<li class="manage_logo"><img src="<%:Call.LogoUrl%>" class="img-thumbnail" alt="<%:Call.SiteName%>_后台管理系统" /></li>
<li><i class="fa fa-user"></i>
<asp:TextBox ID="TxtUserName" TabIndex="1" runat="server" size="20"  class="form-control input-control" autocomplete="off" 
placeholder="帐户" onkeydown="return GetEnterCode('focus','TxtPassword');"/></li>
<li><i class="fa fa-lock"></i>
<asp:TextBox ID="TxtPassword" runat="server" TabIndex="2" TextMode="Password" MaxLength="18" 
    class="form-control input-control" autocomplete="off" placeholder="密码" onkeydown="return GetEnter();" /><br />
<asp:RequiredFieldValidator ID="p1" runat="server" ControlToValidate="TxtPassword" Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="密码不能为空!" />
</li>
<li id="safecode" runat="server"><asp:TextBox ID="TxtAdminValidateCode"  runat="server" MaxLength="6" class="form-control input-control" size="20" /></li>
<li id="CodeLi" runat="server" visible="false">
   <asp:TextBox ID="VCode" runat="server" class="form-control input-control" MaxLength="6" TabIndex="3" autocomplete="off" onkeydown="return GetEnterCode('click','IbtnEnter');"/>
   <img id="VCode_img" runat="server" title="点击刷新验证码" class="code" style="float:right; width:130px; height:34px; "/>
   <input type="hidden" id="VCode_hid" name="VCode_hid" />
   <div class="clearfix"></div>
</li>
<li id="ZnCode_Li" runat="server" visible="false">
<asp:TextBox ID="ZnCode_T" CssClass="form-control input-control" runat="server" placeholder="动态口令"></asp:TextBox>
</li>
<li><asp:Button runat="server" ID="IbtnEnter" CssClass="btn btn-info apply_btn" Text="登录" OnClientClick="return ajaxlogin()" OnClick="IbtnEnter_Click"/></li>
<li><a href="AccountForm.aspx" visible="false" id="test_Link" runat="server" class="btn btn-default apply_btn" target="_blank">申请测试帐号</a></li> 
<li> 
<a href="/" target="_blank" title="首页"><span class="glyphicon glyphicon-home"></span></a>
<a href="/Help.html" target="_blank" title="帮助"><span class="glyphicon glyphicon-globe"></span></a>
<a href="http://help.zoomla.cn/data/" target="_blank" title="数据字典"><span class="glyphicon glyphicon-book"></span></a> &copy Zoomla!CMS Software Co., LTD All Rights Reserved
</li>
</ul>
</div>
</center>
<nav class="navbar navbar-default navbar-fixed-bottom logfoot" role="navigation"></nav>
<script>
    $(function () {
        $("#TxtUserName").focus();
        if ($("#Apple_Hid").val() == "1") location = "default.aspx";
        $("#VCode").ValidateCode();
        if (self != top) { top.location = self.location; }
    })
    function GetEnter() {
        return $("#VCode").length > 0 ? GetEnterCode('focus', 'VCode') : GetEnterCode('click', 'IbtnEnter');
    }
    var loginflag = false;
    function ajaxlogin() {
        if (!loginflag) {
            $("#IbtnEnter").attr('disabled', 'disabled');
            $("#IbtnEnter").val('登录中..');
            $.post("", { action: 'login', user: $("#TxtUserName").val(), pwd: $("#TxtPassword").val(), VCode_hid: $("#VCode_hid").val(), vcode: $("#VCode").val(), zncode: $("#ZnCode_T").val() },
                function (data) {
                    $("#IbtnEnter").removeAttr('disabled');
                    if (data != "True") {
                        $("#IbtnEnter").val('登录');
                        $("#IbtnEnter").popover({
                            animation: true,
                            placement: 'bottom',
                            content: '<span style="color:red;"><span class="glyphicon glyphicon-info-sign"></span> ' + data + '!</span>',
                            html: true,
                            trigger: 'manual',
                            delay: { show: 10000, hide: 100 }
                        });
                        $("#IbtnEnter").popover('show');
                        setTimeout(function () { $("#IbtnEnter").popover('destroy'); }, 2000);
                    } else {
                        loginflag = true;
                        $("#IbtnEnter").click();
                    }
                });
            return loginflag;
        }
    }
</script>
</form>
</body>
</html>