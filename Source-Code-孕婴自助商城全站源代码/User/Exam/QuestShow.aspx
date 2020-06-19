<%@ page language="C#" autoeventwireup="true" masterpagefile="~/User/Default.master" inherits="User_Exam_QuestShow, App_Web_pwji0luf" enableEventValidation="false" viewStateEncryptionMode="Never" %>
<asp:Content runat="server" ContentPlaceHolderID="head">
<title>试题预览</title><style>#options p{display:inline-block;} </style>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="Content">
<div id="pageflag" data-nav="edu" data-ban="ke"></div>
<div class="container margin_t5">
<ol class="breadcrumb">
<li>您现在的位置：<a title="网站首页" href="/"><%= Call.SiteName%></a></li>
<li><a href="/user">用户中心</a></li>
<li><a href="QuestList.aspx">试题管理</a></li>
<li class="active">试题预览</li>
</ol>
</div>
<div class="container">
    <table class="table table-striped table-bordered table-hover">
        <tr>
            <td class="td_l">试题标题:</td>
            <td><asp:Label ID="Title_L" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td>所属年级:</td>
            <td><asp:Label ID="Grade_L" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td>试题类别:</td>
            <td>
                <asp:Label ID="QuestType_L" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>难度:</td>
            <td><asp:Label ID="Diff_L" runat="server"></asp:Label> </td>
        </tr>
        <tr>
            <td>题型:</td>
            <td><asp:Label ID="QType_L" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td>关键字:</td>
            <td><asp:Label ID="KeyWord_L" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td>试题内容:</td>
            <td><asp:Literal ID="Content_Li" EnableViewState="false" runat="server"></asp:Literal></td>
        </tr>
        <tr>
            <td>分数:</td>
            <td><asp:Label ID="Socre_L" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td>试题选项数:</td>
            <td><asp:Label ID="QuestNum_L" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td>选项预览:</td>
            <td id="options"></td>
        </tr>
        <tr>
            <td>正确答案(仅用于自动改卷):</td> 
            <td><asp:Label ID="Answer_L" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td>正确答案(教师与学生可见):</td>
            <td><asp:Literal ID="AnswerHtml_Li" EnableViewState="false" runat="server"></asp:Literal></td>
        </tr>
        <tr>
            <td>试题解析:</td>
            <td><asp:Literal ID="Jiexi_Li" EnableViewState="false" runat="server"></asp:Literal></td>
        </tr>
    </table>
    <div class="text-center">
        <a href="AddEngLishQuestion.aspx?p_id=<%=QID %>" class="btn btn-primary">重新修改</a>
        <a href="QuestList.aspx" class="btn btn-primary">返回列表</a>
    </div>
    </div>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ScriptContent">
    <script>
        function PreOptions(arr) {
            if (arr) {
                var html = "";
                for (var i = 0; i < arr.length; i++) {
                    html += "<div><strong>" + arr[i].op + "</strong>: " + arr[i].val + "</div>";
                }
                $("#options").html(html);
            } else {
                $("#options").html('无选项')
            }
           
        }
    </script>
</asp:Content>



