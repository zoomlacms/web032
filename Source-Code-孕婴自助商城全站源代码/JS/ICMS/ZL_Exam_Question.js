
//大题管理
var curScope = null;
var app = angular.module("app", []).controller("appController", function ($scope, $compile) {
    curScope = $scope;
    var listStr = document.getElementById("Qinfo_Hid").value;
    if (listStr != "") { $scope.list = JSON.parse(listStr); }
    else { $scope.list = []; }
    $scope.add = function (questList) {
        if (!questList || questList.length < 1) return;
        for (var i = 0; i < questList.length; i++) {
            $scope.list.pushNoDup(questList[i], "p_id");
        }
    }
    $scope.remove = function (id) {
        $scope.list.forEach(function (v, i, _) {
            if (v.p_id == id) {
                _.splice(i, 1);
            }
        });
    }
    $scope.getTypeStr = function (type) {
        switch (type) {
            case 0:
                return "单选题";
            case 1:
                return "多选填";
            case 2:
                return "填空题";
            case 3:
                return "解析题";
            case 10:
                return "大题";
            default:
                return type;
        }
    }
});
function SelQuestion(questList) {
    if (comdiag) { CloseComDiag(); }
    if (!questList || questList.length < 1) return;
    curScope.$apply(function ($compile) {
        for (var i = 0; i < questList.length; i++) {
            curScope.list.pushNoDup(questList[i], "p_id");
        }
    });
    ZL_Regex.B_Num(".int");
}
function BigCheck() {
    var ids = curScope.list.GetIDS("p_id");
    if (ids.length > 0) {
        $("#Qids_Hid").val(ids);
        $("#Qinfo_Hid").val(JSON.stringify(curScope.list));
    } else { alert("请还没有选择小题!"); return false; }
    return true;
}
function ShowAdd() {
    comdiag.reload = true;
    ShowComDiag("/User/Exam/AddEnglishQuestion.aspx?issmall=1", "添加小题");
}
function ShowSel() {
    var url = "/User/Exam/SelQuestion.aspx?type=1&islage=1&selids=," + $("#Qids_Hid").val() + ",";
    ShowComDiag(url, "选择题目")
}
//--------------------------------------------
var diag = new ZL_Dialog();
function ShowDiag() {//后期增加对公式的支持,已有实现思路
    diag.title = "设定内容";
    diag.maxbtn = false;
    diag.backdrop = true;
    diag.url = "/Manage/Exam/Addoption.html";
    diag.ShowModal();
}
function CloseDiag() { diag.CloseModal(); }
var tabarr = [];//关键字数组
$(function () {
    if ($("#NodeID_Hid").val() || $("#NodeID_Hid").val() > 0)
    { SetQuestType($("#NodeID_Hid").val()); }

});
function InitQuestEvent() {
    $(".Quesst_Dr button").click(function () {
        $(this).next().toggle();
    });
}
function CheckData() {
    //if ($("#QuestType_Hid").val() == "") {
    //    alert('请选择试题类别!');
    //    return false;
    //}
    if (ZL_Regex.isEmpty($("#txtP_title").val())) { alert("标题不能为空"); return false; }
    var qtype = $("input[name=qtype_rad]:checked").val();
    if (qtype == 10) {
        if (!BigCheck()) { return false; }
    }
    GetOptions();
    return true;
}
//选择试题类别
function SelQuestType(obj, id) {
    $(".Quesst_Dr button .curquest").html($(obj).text());
    $("#NodeID_Hid").val(id);
    $(obj).closest('ul').hide();
}
function SetQuestType(id) {
    $(".Quesst_Dr button .curquest").html($(".Quesst_Dr ul [data-id='" + id + "']").text());
}
//-----------------KeyWord
function InitKeyWord(value) {
    tabarr = [];
    $("#OAkeyword").html('');
    if ($("#OAkeyword").length > 0) {
        $("#OAkeyword").tabControl({
            maxTabCount: 5,
            tabW: 80,
            onAddTab: function (value) {
                tabarr.push(value);
            },
            onRemoveTab: function (removeval) {
                for (var i = 0; i < tabarr.length; i++) {
                    if (tabarr[i] == removeval) {
                        tabarr.splice(i, 1);
                    }
                }
            }
        }, value);
    }//关键词
}
function ShowKeyWords() {
    comdiag.reload = true;
    comdiag.maxbtn = false;
    comdiag.width = "none";
    ShowComDiag("/Common/SelKeyWords.aspx?type=2", "选择关键字");
}
function GetKeyWords(keystr) {
    tabarr = tabarr.concat(keystr.split(','));
    var values = "";
    var length = tabarr.length <= 5 ? tabarr.length : 5;
    for (var i = 0; i < length; i++) {
        values += tabarr[i] + ",";
    }
    InitKeyWord(values);
    CloseComDiag();
}