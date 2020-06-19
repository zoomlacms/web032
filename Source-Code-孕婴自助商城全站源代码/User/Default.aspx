﻿<%@ page language="C#" autoeventwireup="true" inherits="User_Default, App_Web_rydlxubx" clientidmode="Static" enableEventValidation="false" viewStateEncryptionMode="Never" %><!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta http-equiv="X-UA-Compatible" content="IE=edge">
<meta name="viewport" content="width=device-width, initial-scale=1.0">
<title>会员中心</title>
<link type="text/css" rel="stylesheet" href="/dist/css/bootstrap.min.css" />
<!--[if lt IE 9]>
<script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
<script src="https://oss.maxcdn.com/libs/respond.js/1.3.0/respond.min.js"></script>
<![endif]-->
<link rel="stylesheet" href="/dist/css/font-awesome.min.css"/>
<link type="text/css" rel="stylesheet" href="/App_Themes/User.css" />
<script type="text/javascript" src="/JS/jquery-1.11.0.min.js"></script>
<script type="text/javascript" src="/dist/js/bootstrap.min.js"></script> 
</head>
<body>
<form id="form1" runat="server">
<div class="navbar-fixed-top u_fixed">
<div class="u_top">
<div class="container">
<div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
<a href="/" target="_blank"><img src="<%Call.Label("{$LogoUrl/}"); %>" class="img-responsive" alt="<%Call.Label("{$SiteName/}"); %>" /></a>
</div>
<div class="col-lg-8 col-md-8 col-sm-8 col-xs-12 u_search">
<div class="u_top_btn">
<ul class="list-inline pull-right">
<li><div class="u_search_form"><input type="text" name="key" id="key" class="form-control" placeholder="快速搜索" onKeyDown="return IsEnter(this);" /><i class="glyphicon glyphicon-search" id="sub_btn" title="可按回车键快速检索"></i></div></li>
<li class="text-center"><i class="fa fa-user"></i><asp:Label ID="uName" runat="server"></asp:Label></li>
<li class="text-center"><a href="/User/Info/UserBase.aspx"><i class="glyphicon glyphicon-cog"></i></a></li>
<li class="text-center"><a href="/User/LogOut.aspx">退出</a></li>
</ul>
</div>
</div> 
</div>
</div>
<div class="u_nav">
<nav class="navbar navbar-default">
  <div class="container">
    <!-- Brand and toggle get grouped for better mobile display -->
    <div class="navbar-header">
      <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
        <span class="sr-only">Toggle navigation</span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
      </button>
      <a class="navbar-brand visible-xs" href="#">快速导航</a>
    </div>
    <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
      <ul class="nav navbar-nav">
        <li class="active"><a href="/User/">首页</a></li>
        <li><a href="/User/Content/MyContent.aspx">内容</a></li>
        <li><a href="/User/UserShop/ProductList.aspx">商城</a></li>
        <li><a href="/User/UserZone/Default.aspx">社区</a></li>
      </ul>
    </div>
  </div>
</nav>
</div>
</div>
<div class="u_fix_height"></div>
<div class="u_info">
<div class="container">
<div class="col-lg-2 col-md-2 col-sm-2 col-xs-12 u_face">
<a href="/User/Info/UserInfo.aspx"><asp:Image ID="imgUserPic" AlternateText="" onerror="this.src='/images/userface/noface.gif'" runat="server" /></a>
</div>
<div class="col-lg-10 col-md-10 col-sm-10 col-xs-12 u_syn">
<ul class="list-unstyled">
<li>
<ul class="list-unstyled">
<li><i class="glyphicon glyphicon-user"></i>会员名称：<asp:Label ID="UserNameLb" runat="server" Text=""></asp:Label></li>
<li>等级：<span id="LvIcon_Span" runat="server"></span> <asp:Label ID="UserLvLb" runat="server" Text=""></asp:Label></li>
<li>加入时间：<asp:Label ID="UserRegTimeLb" runat="server" Text=""></asp:Label></li>
</ul>
</li>
<li><i class="glyphicon glyphicon-map-marker"></i>地址：<asp:Label ID="UserAddressLb" runat="server" Text=""></asp:Label></li>
<li><i class="glyphicon glyphicon-edit"></i>个性签名：<asp:Label ID="UserSignLb" runat="server" Text=""></asp:Label></li>
<li>
<ul class="list-unstyled">
<li><i class="glyphicon glyphicon-usd"></i><a href="/PayOnline/SelectPayPlat.aspx" target="_blank">余额：<asp:Label ID="UserYeLb" runat="server" Text=""></asp:Label></a></li>
<li>银币：<asp:Label ID="UserJbLb" runat="server" Text=""></asp:Label></li><li>积分：<asp:Label ID="UserJfLb" runat="server" Text=""></asp:Label></li>
</ul>
</li>
</ul>
</div>
</div>
</div>
<div class="u_site margin_t5">
<div class="container">
<ol class="breadcrumb">
<li>您现在的位置：<a title="网站首页" href="/"><%= Call.SiteName%></a></li>
<li><a href="/User/">会员中心</a></li>
</ol>
</div>
</div> 
<div class="container">  
<div class="u_menu">
    <asp:Literal ID="UserApp_Li" runat="server" EnableViewState="false"></asp:Literal>
<div class="clearfix"></div>
</div>
</div> 
<div class="u_menu_more text-center" hidden>
<a href="javascript:;" id="more_btn"><i class="fa fa-angle-double-down"></i></a>
</div>
<div class="user_menu_sub"> 
    <ul class="list-unstyled text-center">
        <asp:Literal runat="server" ID="onther_lit" EnableViewState="false"></asp:Literal>
    </ul>
<div class="clearfix"></div>
</div>  
<div class="u_footer text-center fixed_bottom">
<div class="footer_border hidden-xs">
</div>
<%Call.Label("{$Copyright/}"); %>
</div>
</form>
</body>
</html>
<script> 
$().ready(function (e) {//菜单颜色配置
	var colorArr=new Array('#c47f3e','#669933','#27a9e3','#f05033','#990066','#9999FF','#E48632','#990000','#22afc2','#6633FF','#9900FF','#1FA67A');
	var count=$(".user_menu_sub li").length;
	for(var i=0; i<count; i++){
		$(".user_menu").eq(i).css("background",colorArr[i%12]);	
	}
    if ($(".user_menu_sub li").length < 1)
        $(".u_menu_more").remove();
})
$("#mimenu_btn").click(function(e) { 
	if($(".user_mimenu_left").width()>0){ 
 		$(".user_mimenu_left ul").fadeOut(100);
		$(".user_mimenu_left").animate({width:0},200); 	
	}
	else{ 
		$(".user_mimenu_left").animate({width:150},300); 
		$(".user_mimenu_left ul").fadeIn();
	}
});
//会员菜单更多显示/隐藏
$("#more_btn").click(function(e) {
	if($(".user_menu_sub").css("display")=="none"){  
	    $(".user_menu_sub").slideDown();
		$(this).find("i").removeClass("fa-angle-double-down");
		$(this).find("i").addClass("fa-angle-double-up");
	}
	else {  
	    $(".user_menu_sub").slideUp(200); 
		$(this).find("i").removeClass("fa-angle-double-up");
		$(this).find("i").addClass("fa-angle-double-down");
	}
});
//会员搜索
$("#sub_btn").click(function(e) { 
    if($("#key").val()=="")
		alert("搜索关键字为空!");
	else
		window.location="/User/SearchResult.aspx?key="+escape($("#key").val());	
});
//搜索回车事件
function IsEnter(obj) {
	if (event.keyCode == 13) {
		$("#sub_btn").click(); return false;
	}
}
//判断div元素是否满屏，不满则自动补充高度
//$().ready(function(e) {
//    if ($(".u_footer").position().top + $(".u_footer").outerHeight() < window.innerHeight)
//       $(".u_footer").addClass("navbar-fixed-bottom");
//		$(".u_footer").height(window.innerHeight-$(".u_footer").position().top-3);
//}); 
</script>