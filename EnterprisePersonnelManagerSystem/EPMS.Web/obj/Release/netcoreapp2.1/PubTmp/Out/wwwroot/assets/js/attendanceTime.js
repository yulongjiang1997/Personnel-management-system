function initTable() {
    console.log(12);
    var url = '/api/Attendance/GetAttendanceTime';
    util.ajaxGet(url).then(res => {
        console.log(res)
        $('#content').append(`
      <tr data-id="${res.id}">
      <td class="workingTime">${res.workingTime}</td>
      <td class="offworkTime">${res.offworkTime}</td>
      <td >
        <div style="display:flex;justify-content:space-around">
        <svg  class="edit icon cPointer" aria-hidden="true" style="font-size:20px">
        <use xlink:href="#icon-edit"></use>
      </svg>
        </div>
  
      </td>
      </tr>
      `)
    }).catch(err => {
        console.log(err);
    });
}

$(function () {
    initTable();
});

$('#addAttendanceTime').click(function () {
    console.log(1);
    var title = '添加考勤时间';
    var htmlCode = `
<div class="panel-body" id="newPosition">
    <form class="form-horizontal" id="form-validate" role="form" autocomplete="off">
        <div class="form-group">

            <div class="form-group">
                <label class="col-lg-2 control-label" for="workingTime">上班打卡时间</label>
                <div class="col-lg-10">
                    <input class="form-control" id="workingTime" type="text" />
                </div>
            </div>

            <div class="form-group">
                <label class="col-lg-2 control-label" for="offworkTime">下班打卡时间</label>
                <div class="col-lg-10">
                    <input class="form-control" id="offworkTime" type="text" />
                </div>
            </div>

            <div class="form-group">
                <div class="col-lg-offset-2" style="padding-left:15px">
                    <div style="display:inline-block" class="customBtnWrapper">
                        <button type="button" class="btn btn-default customButton mr10" id="addAttendanceTimeBtn">
                            <span class="btn-text">
                                提交
                            </span>
                        </button>
                    </div>
                    <button type="button" id="cancel" class="btn btn-danger">取消</button>
                </div>
            </div>
        </div>
    </form>
</div>`;


    $.jConfirm(title, htmlCode, '100%', 450);

    $('#cancel').click(function () {
        $.alert._close();
    });

    $('#addAttendanceTimeBtn').click(function () {
        var url = '/api/Attendance/CreateOrEditAttendanceTime';
        var data = {
            workingTime: $('#workingTime').val(),
            offworkTime: $('#offworkTime').val()
        };
        util.ajaxPost(data, url).then(res => {
            if (res.result) {
                alert('添加成功');
                location.reload();
            } else {
                alert(res.message);
            }
        });
    });
});

$('body').on('click', '.edit', function () {
    var base = this;
    var trData = $(this).parents('tr');
    var title = '编辑考勤时间设置';
    var htmlCode = `
   <div class="panel-body" id="newPosition">
    <form class="form-horizontal" id="form-validate" role="form" autocomplete="off">
        <div class="form-group">

            <div class="form-group">
                <label class="col-lg-2 control-label" for="workingTime">上班打卡时间</label>
                <div class="col-lg-10">
                    <input class="form-control" id="workingTime" type="text" value="${trData.find(".workingTime").text()}"/>
                </div>
            </div>

            <div class="form-group">
                <label class="col-lg-2 control-label" for="offworkTime">下班打卡时间</label>
                <div class="col-lg-10">
                    <input class="form-control" id="offworkTime" type="text" value="${trData.find(".offworkTime").text()}" />
                </div>
            </div>

            <div class="form-group">
                <div class="col-lg-offset-2" style="padding-left:15px">
                    <div style="display:inline-block" class="customBtnWrapper">
                        <button type="button" class="btn btn-default customButton mr10" id="editAttendanceTimeBtn">
                            <span class="btn-text">
                                提交
                            </span>
                        </button>
                    </div>
                    <button type="button" id="cancel" class="btn btn-danger">取消</button>
                </div>
            </div>
        </div>
    </form>
</div>`;
    $.jConfirm(title, htmlCode, '100%', 450);

    ;
    $('#cancel').click(function () {
        $.alert._close();
    });

    $('#editAttendanceTimeBtn').click(function () {
        var url = `/api/Attendance/CreateOrEditAttendanceTime?id=${$(base).parents('tr').attr('data-id')}`;
        var data = {
            workingTime: $('#workingTime').val(),
            offworkTime: $('#offworkTime').val(),
        }
        util.ajaxPost(data, url).then(res => {
            if (res.result) {
                alert('修改成功');
                location.reload();
            } else {
                alert('修改失败');
            }
        });
    });
});
