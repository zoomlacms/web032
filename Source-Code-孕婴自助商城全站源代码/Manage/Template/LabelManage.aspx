<%@ page language="C#" autoeventwireup="true" inherits="Manage_I_Content_LabelManage, App_Web_r0b1olnt" masterpagefile="~/Manage/I/Default.master" enableEventValidation="false" viewStateEncryptionMode="Never" %>
<asp:Content runat="server" ContentPlaceHolderID="head">
<title>标签管理</title>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="Content">
<div id="BreadDiv" class="container-fluid mysite">
<div class="row">
<ol id="BreadNav" class="breadcrumb navbar-fixed-top"  style="padding-top:2px; padding-bottom:1px;">
    <li><a href="<%=CustomerPageAction.customPath2 %>Main.aspx">工作台</a></li>
    <li><a href="<%=CustomerPageAction.customPath2 %>Config/SiteOption.aspx">系统设置</a></li>
    <li class="active"><a href="LabelManage.aspx">标签管理</a></li>
    <div class="input-group nobefore">
        <a href="javascript:;" class="btn btn-info dropdown-toggle" data-toggle="dropdown" aria-expanded="false"><i class="fa fa-plus-circle"></i> 添加标签</a>
            <ul class="dropdown-menu" role="menu" style="min-width:100px; width:100px;">
                <li><a href="LabelSql.aspx"><i class="fa fa-circle-o"></i> 动态标签</a></li>
                <li><a href="LabelHtml.aspx"><i class="fa fa-code"></i> 静态标签</a></li>
                <li><a href="PageLabel.aspx"><i class="fa fa-file-excel-o"></i> 分页标签</a></li><li><a href="LabelExport.aspx" title="从旧版标签升级"><i class="fa fa-arrow-circle-up"></i> 旧版升级</a></li>
            </ul> 
    </div>
    <div id="help" class="pull-right text-center"><a href="javascript::" id="sel_btn" class="help_btn"><i class="fa fa-search"></i></a><a onclick="help_show('21')" title="帮助" class="help_btn"><span class="glyphicon glyphicon-question-sign"></span></a></div>
</ol>
</div>
</div>
<div id="sel_box" class="padding5">
<div class="input-group sel_box">
    <asp:TextBox runat="server" ID="TxtLableName" class="form-control" onkeydown="return GetEnterCode('click','HidSearch');" placeholder="检索当前位置" />
    <span class="input-group-btn">
            <asp:LinkButton runat="server" CssClass="btn btn-default" ID="Search_Btn" OnClick="BtnSearch_Click">搜索</asp:LinkButton>
            <asp:Button runat="server" ID="BtnSearch" OnClick="BtnSearch_Click" style="display:none;" />
    </span>
</div>
</div>
<div class="v3_navtabs v3_all_label">
<ul class="nav nav-tabs" id="navtabs_ul">
<asp:Literal ID="lblLabel" runat="server" Text="Label"></asp:Literal>
</ul>
<a id="hid_right"><i class="glyphicon glyphicon-menu-left"></i></a>
<a id="hid_left"><i class="glyphicon glyphicon-menu-right"></i></a>
</div>
<table class="table table-striped table-bordered table-hover" align="center">
    <tr class="gridtitle" align="center">
        <td width="5%">选择</td>
        <td width="30%">名称</td>
        <td style="width: 20%">标签分类</td>
        <td width="20%">标签类别</td>
        <td style="width: 25%">操作</td>
    </tr>
    <asp:Repeater ID="repFile" runat="server" OnItemCommand="repFileReName_ItemCommand">
        <ItemTemplate>
            <tr ondblclick="ckl('<%# Eval("LabelName") %>')">
                <td align="center">
                    <asp:CheckBox ID="chkSel" runat="server" />
                    <asp:Label ID="LabelHiddenID" runat="server" Text='<%#Eval("LabelID")%>' Visible="false"></asp:Label>
                </td>
                <td align="left" style="padding-left: 2px;">
                    <%# GetLabelLink(Eval("LabelID", "{0}"), Eval("LabelName", "{0}"), Eval("LabelType", "{0}"))%>
                </td>
                <td align="center">
                    <a href="LabelManage.aspx?Cate=<%# GetLabelCate(Eval("LabelCate").ToString()) %>">
                        <%#Eval("LabelCate") %></a>
                </td>
                <td align="center">
                    <%#GetLabelType(Eval("LabelType").ToString()) %>
                </td>
                <td align="center" id="select">&nbsp;
                        
        <asp:LinkButton ID="LinkButton1" CssClass="option_style" runat="server" CommandName="Edit" CommandArgument='<%# Eval("LabelName") %>'><i class="glyphicon glyphicon-pencil" title="修改"></i></asp:LinkButton>
        <asp:LinkButton ID="LinkButton3" CssClass="option_style" runat="server" CommandName="Copy" CommandArgument='<%# Eval("LabelName") %>'
            OnClientClick="return confirm('确实要复制此标签吗？');"><i class="fa fa-paste" title="复制"></i></asp:LinkButton>
                                     
        <asp:LinkButton ID="LinkButton4" CssClass="option_style" runat="server" CommandName="Download" CommandArgument='<%# Eval("LabelName") %>'><i class="fa  fa-download" title="下载"></i></asp:LinkButton>
        <asp:LinkButton ID="LinkButton2" CssClass="option_style" runat="server" CommandName="Del" CommandArgument='<%# Eval("LabelName") %>'
            OnClientClick="return confirm('确实要删除此标签吗？');"><i class="glyphicon glyphicon-trash" title="删除"></i></asp:LinkButton>
        <a class="option_style" href="LabelCallTab.aspx?labelName=<%#Eval("LabelName") %>"><i class="fa fa-share-alt"></i>引用</a>
                </td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
</table>
<div style="text-align: center; width: 100%">
    <table width="100%">
        <tr>
            <td class="tdbg">共
    <asp:Label ID="Allnum" runat="server" Text=""></asp:Label>
                条信息
    <asp:Label ID="Toppage" runat="server" Text="" />
                <asp:Label ID="Nextpage" runat="server" Text="" />
                <asp:Label ID="Downpage" runat="server" Text="" />
                <asp:Label ID="Endpage" runat="server" Text="" />
                页次：<asp:Label ID="Nowpage" runat="server" Text="" />/<asp:Label ID="PageSize" runat="server"
                    Text="" />页
    <asp:TextBox ID="txtPage" runat="server" AutoPostBack="true" class="l_input" OnTextChanged="txtPage_TextChanged"
        Width="30px"></asp:TextBox>条信息/页 转到第<asp:DropDownList ID="DropDownList2" runat="server"
            AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
        </asp:DropDownList>
                页
            </td>
        </tr>
    </table>
</div>
<asp:CheckBox ID="CheckBox2" runat="server" AutoPostBack="True" Font-Size="9pt" OnCheckedChanged="CheckBox2_CheckedChanged"
    Text="全选" />
<asp:Button ID="Button1" runat="server" Text="批量导出" class="btn btn-primary" Style="width: 100px;"
    OnClick="btnExport_Click" OnClientClick="return confirm('你确定要导出选中标签吗？')" Visible="false" />
<asp:Button ID="Button3" runat="server" Text="批量导入" Visible="false" OnClientClick="location.href='LabelImport.aspx';return false;" class="btn btn-primary" Style="width: 100px;"
    UseSubmitBehavior="true" />
<asp:Button ID="Button2" runat="server" Text="批量删除" OnClick="btnDeleteAll_Click" OnClientClick="return confirm('你确定要将所有选择标签删除吗？')" class="btn btn-primary" Style="width: 100px;" UseSubmitBehavior="true" />
<asp:HiddenField ID="HiddenField1" runat="server" />
<asp:HiddenField ID="HiddenField2" runat="server" />
<asp:HiddenField ID="HiddenField3" runat="server" />
</table>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ScriptContent">
<script type="text/javascript" src="/js/Common.js"></script>
<script type="text/javascript">
function showmenu(e, vmenu, mod, tops) {
    if (tops == null) {
        tops = menuOffY;
    }
    if (!vmenu) { return false; } //如果空则不显示
    var which = vmenu
    menuobj = $("popmenu")
    menuobj.innerHTML = which
    menuobj.contentwidth = menuobj.offsetWidth
    eventX = e.clientX
    eventY = e.clientY
    var rightedge = document.body.clientWidth - eventX
    var bottomedge = document.body.clientHeight - eventY
    var getlength
    if (rightedge < menuobj.contentwidth) {
        getlength = ie4 ? document.body.scrollLeft + eventX - menuobj.contentwidth + menuOffX : ns6 ? window.pageXOffset + eventX - menuobj.contentwidth : eventX - menuobj.contentwidth
    } else {
        getlength = ie4 ? ie_x(event.srcElement) + menuOffX : ns6 ? window.pageXOffset + eventX : eventX
    }
    menuobj.style.left = getlength + 'px'

    if (bottomedge < menuobj.contentheight && mod != 0) {
        getlength = ie4 ? document.body.scrollTop + eventY - menuobj.contentheight - event.offsetY + tops - 23 : ns6 ? window.pageYOffset + eventY - menuobj.contentheight - 10 : eventY - menuobj.contentheight
    }
    else {
        getlength = ie4 ? ie_y(event.srcElement) + tops : ns6 ? window.pageYOffset + eventY + 10 : eventY
    }
    menuobj.style.top = getlength + 'px'

    menuobj.style.visibility = "visible"
}
$(document).ready(function (e) {
    //$("#slt").click(function () {
    //    $("#select").slideToggle("slow");
    //}); 
});
function displayToolbar() {
    $("#toolbar1").toggle("fast");
}
function ckl(LabelName) {
    window.location.href = "LabelHtml.aspx?LabelName=" + LabelName;
}
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
var marleft = 0;
var movewidth = 0;
var $ul = $("#navtabs_ul");
$("#hid_right").click(function (e) {
    movewidth = $(".v3_navtabs").innerWidth() - 60;
    if (marleft + movewidth < $ul.width()) {
        marleft += movewidth; 
        $ul.animate({ "marginLeft": -marleft + "px" }, 300);
    }
});
$("#hid_left").click(function (e) {
    movewidth = $(".v3_navtabs").innerWidth() - 60;
    if (marleft >= movewidth) {
        marleft -= movewidth;
        $ul.animate({ "marginLeft": -marleft + "px" }, 300);
    }
    else
        $ul.animate({ "marginLeft": "0px" }, 300);
});
</script>
</asp:Content>