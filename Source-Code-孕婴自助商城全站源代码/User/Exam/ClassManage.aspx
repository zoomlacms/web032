<%@ page language="C#" autoeventwireup="true" inherits="manage_Question_ClassManage, App_Web_pwji0luf" enableviewstatemac="false" masterpagefile="~/User/Default.master" enableEventValidation="false" viewStateEncryptionMode="Never" %>
<asp:Content runat="server" ContentPlaceHolderID="head">
        <title>班级管理</title>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="Content">
<div id="pageflag" data-nav="edu" data-ban="ke"></div>
<div class="container margin_t5">
        <ol class="breadcrumb">
    	<li>您现在的位置：<a title="网站首页" href="/">逐浪CMS</a></li>
        <li><a href="/User/">用户中心</a></li>
        <li class="active">班级管理 [<a href="AddClass.aspx">添加班级</a>]</li>
        </ol>
</div>
    <div class="container btn_green">
        <ul class="nav nav-tabs" visible="false" id="StuClass_Div" runat="server" role="tablist">
        <li role="presentation" data-tab="-1"><a href="ClassManage.aspx" >已申请班级</a></li>
        <li role="presentation" data-tab="1"><a href="ClassManage.aspx?audit=1">已通过班级</a></li>
        <li role="presentation" data-tab="0"><a href="ClassManage.aspx?audit=0">未通过班级</a></li>
        </ul>

        <table class="table table-striped table-bordered table-hover" id="EGV">
        <tr>
            <td class="td_s">
            </td>
            <td>班级名称</td>
            <td>班级微标</td>
            <td>负责人</td>
            <td>建立时间</td>
            <td>成员人数</td>
            <td class="title">操作</td>
        </tr>
        <ZL:ExRepeater ID="Repeater1" PageSize="10" runat="server" PagePre="<tr><td><input type='checkbox' id='chkAll'/></td><td colspan='10'><div class='text-center'>" PageEnd="</div></td></tr>">
            <ItemTemplate>
                <tr id="<%#Eval("RoomID") %>" ondblclick="ShowTabs(this.id)">
                    <td>
                        <input name="Item" type="checkbox" value='<%#Eval("RoomID") %>' />
                    </td>
                    <td>
                        <%#Eval("RoomName")%>
                    </td>
                    <td>
                        <img src="<%#Eval("Monitor") %>" style="width:30px; height:30px;" onerror="this.src='/UploadFiles/nopic.gif'" />
                    </td>
                    <td>
                        <%#Eval("Teacher")%>
                    </td>
                    <td>
                        <%#Eval("Creation")%>
                    </td>
                    <td>
                        <%#Eval("StuCount") %>
                    </td>
                    <td>
                        <%#GetOP() %>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate></FooterTemplate>
        </ZL:ExRepeater>
        
    </table>
        <asp:Button ID="Del_Btn" class="btn btn-primary" Style="width: 110px;" runat="server" OnClientClick="return confirm('不可恢复性删除数据,你确定将该数据删除吗？');" Text="批量删除" onclick="Button3_Click" />
</div>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ScriptContent">
    <script type="text/javascript">
        $().ready(function () {
            $("#chkAll").click(function () {
                $("[name='Item']").each(function (i, v) {
                    $(v)[0].checked = $("#chkAll")[0].checked;
                });
            });
        });
        function InitTab(id) {
            $("[data-tab]").removeClass('active');
            $("[data-tab='" + id + "']").addClass('active');
        }
    </script>
</asp:Content>