<%@ page language="C#" autoeventwireup="true" inherits="manage_Question_AddClass, App_Web_pwji0luf" enableviewstatemac="false" masterpagefile="~/User/Default.master" enableEventValidation="false" viewStateEncryptionMode="Never" %>
<%@ Register Src="~/Manage/I/ASCX/SFileUp.ascx" TagName="SFileUp" TagPrefix="ZL" %>
<asp:Content runat="server" ContentPlaceHolderID="head">
        <link type="text/css" href="/dist/css/bootstrap-switch.min.css" rel="stylesheet" />
        <title>编辑班级</title>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="Content">
<div id="pageflag" data-nav="edu" data-ban="ke"></div>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:HiddenField runat="server" ID="classid_Hid" />
    <div class="container margin_t5">
         <ol class="breadcrumb">
    	<li>您现在的位置：<a title="网站首页" href="/">逐浪CMS</a></li>
        <li><a href="/User/">用户中心</a></li>
        <li><a href="ClassManage.aspx">班级管理</a></li>
        <li class="active">编辑班级</li> 
        </ol>
</div>
    <div class="container btn_green">
    <table class="table table-striped table-bordered table-hover">
        <tbody id="Tabs0">
            <tr>
                <td class="td_m text-right">
                    班级名称:
                </td>
                <td>
                    <asp:TextBox ID="ClassName_T" runat="server" class="form-control text_md" ></asp:TextBox>
                    <font color="red">*</font>
                </td>
            </tr>
            <tr>
                <td class="text-right">班级微标:</td>
                <td>
                    <ZL:SFileUp ID="SFile_Up" FType="Img" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="text-right">班级宣言:</td>
                <td>
                    <asp:TextBox ID="ClassDeailt_T" runat="server" CssClass="form-control text_300" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
        </tbody>
        <tr class="tdbgbottom">
            <td colspan="2">
                <asp:Button ID="EBtnSubmit" class="btn btn-primary" Text="添加班级" runat="server" OnClick="EBtnSubmit_Click" />
                &nbsp;
                <a href="ClassManage.aspx" class="btn btn-primary">返回列表</a>
            </td>
        </tr>
    </table>
    </div>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ScriptContent">
    <script type="text/javascript" src="/dist/js/bootstrap-switch.js"></script>
    <script src="/JS/DatePicker/WdatePicker.js"></script>
    <script type="text/javascript" src="/JS/Controls/ZL_Dialog.js"></script>
    <script type="text/javascript">
        var typediag = new ZL_Dialog();
        function Openwin() {
            typediag.title = "选择分类";
            typediag.url = "SelectCourse.aspx";
            typediag.ShowModel();
        }
    </script>
</asp:Content>