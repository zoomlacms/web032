<%@ page language="C#" autoeventwireup="true" inherits="User_Exam_ClassView, App_Web_lu2t5oba" masterpagefile="~/User/Default.master" enableEventValidation="false" viewStateEncryptionMode="Never" %>
<asp:Content runat="server" ContentPlaceHolderID="head">
<title>班级列表</title>
<style>
    .classlist{padding:5px 20px;}
    .classlist img{width:100%;height:100px;}
    .classlist button{width:100%;}
    .classlist .class_title{font-size:20px; font-weight:500;}
    .classlist .class_info{padding:5px; color:#999;}
    .classlist div{margin-bottom:5px;}
    .line30{line-height:30px;}
</style>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="Content">
    <div id="pageflag" data-nav="edu" data-ban="ke"></div>
    <div class="container margin_t5">
        <ol class="breadcrumb">
        <li>您现在的位置：<a title="网站首页" href="/">逐浪CMS</a></li>
        <li><a href="/User/">用户中心</a></li>
        <li>班级列表</li>
        </ol>
    </div>
    <div class="container">
    <ZL:ExRepeater ID="RPT" runat="server" PageSize="12"  PagePre="<div class='clearfix'></div><div class='text-center'>" PageEnd="</div>">
        <ItemTemplate>
            <div class="col-md-3 classlist">
                <div class="text-center class_title"><%#Eval("RoomName") %></div>
                <div><img src="<%#Eval("Monitor") %>" onerror="this.src='/UploadFiles/nopic.gif'" /></div>
                <div class="class_info"><%#Eval("ClassInfo") %></div>
                <div><%#GetButton() %></div>
            </div>
        </ItemTemplate>
        <FooterTemplate></FooterTemplate>
    </ZL:ExRepeater>
    </div>
    <div style="display:none;" id="remind_div">
        <div class="panel panel-primary">
        <div class="panel-heading">班级信息</div>
          <div class="panel-body">
           <div class="col-md-3 text-right line30">班级教师:</div>
            <div class="col-md-9 line30">
                <span id="tearch_span"></span>
            </div><div class="clearfix"></div>
            <div class="col-md-3 text-right line30">班级宣言:</div>
            <div class="col-md-9 line30">
                <span id="class_span"></span>
            </div><div class="clearfix"></div>
            <div class="col-md-3 text-right line30">申请理由:</div>
            <div class="col-md-9 line30 margin_t5">
                <asp:TextBox ID="Remind_T" runat="server" TextMode="MultiLine" CssClass="form-control text_300" Height="150"></asp:TextBox>
            </div><div class="clearfix"></div>
            
          </div>
        </div>
        <div class="text-center margin_t5">
                <asp:Button ID="Audit_Btn" CssClass="btn btn-primary" Text="确定" runat="server" OnClick="Audit_Btn_Click" />
                <button type="button" class="btn btn-primary" onclick="comdiag.CloseModal();">关闭</button>
                <asp:HiddenField ID="RoomID_Hid" runat="server" />
            </div> 
    </div>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ScriptContent">
    <script type="text/javascript" src="/JS/Controls/ZL_Dialog.js"></script>
    <script type="text/javascript" src="/JS/ICMS/ZL_Common.js"></script>
    <script>
        function ShowRemark(obj) {
            comdiag.title = "申请理由";
            comdiag.width = "none";
            comdiag.content = "remind_div";
            comdiag.ShowModal();
            $("#Remind_T").val('');
            $("#RoomID_Hid").val($(obj).data('id'));
            $("#tearch_span").text($(obj).data('tearch'));
            $("#class_span").text($(obj).data('info'));
        }
    </script>
</asp:Content>



