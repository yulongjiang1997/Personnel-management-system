function initTable() {
    console.log(12);
    var url = '/api/Attendance/QueryPagin';
    var data = {
        page: 1,
        number: 100
    }
    util.ajaxPost(data,url).then(res => {
        res.items.forEach(element => {
            $('#content').append(`
      <tr data-id="${element.id}">
      <td class="userName">${element.staffInfoName}</td>
      <td class="workingTime">${element.workingTime?element.workingTime.replace('T', ' '):``}</td>
      <td class="offworkTime">${element.offworkTime?element.offworkTime.replace('T', ' '):``}</td>
      <td class="isLate">${element.isLate ? `是` : `否`}</td>
      <td class="isLeaveEarly">${element.isLeaveEarly ? `是` : `否`}</td>
      </tr>
      `)
        })
    }).catch(err => {
        console.log(err);
    });
}

$(function () {
    initTable();
});

$('#addAttendanceRecord').click(function () {
    console.log(1);
    var title = '添加考勤记录';
    var htmlCode = `
<div class="panel-body" id="newPosition">
    <form class="form-horizontal" id="form-validate" role="form" autocomplete="off">
        <div class="form-group">

            <div class="form-group">
                <label class="col-lg-2 control-label" for="createTime">打卡时间</label>
                <div class="col-lg-10">
                    <input class="form-control" id="createTime" type="text" />
                </div>
            </div>

            <div class="form-group">
                <label class="col-lg-2 control-label" for="staffSelect">员工姓名</label>
                <div class="col-lg-10">
                    <select class="form-control" id="staffSelect">
                        <option value="" disabled="" class="hide" selected="">请选择员工</option>

                    </select>
                </div>
            </div>

            <div class="form-group">
                <div class="col-lg-offset-2" style="padding-left:15px">
                    <div style="display:inline-block" class="customBtnWrapper">
                        <button type="button" class="btn btn-default customButton mr10" id="addAttendanceRecordBtn">
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

    var url = '/api/StaffInfo/QueryPagin'
    var data = {
        page: 1,
        number: 100
    }
    util.ajaxPost(data, url).then(res => {
        res.items.forEach(element => {
            $('#staffSelect').append(`
    <option value="${element.id}">${element.name}</option>`)
        })
    }).catch(err => {
        console.log(err)
    })

    $('#cancel').click(function () {
        $.alert._close();
    });

    $('#addAttendanceRecordBtn').click(function () {
        var url = '/api/Attendance/Create';
        var data = {
            createTime: $('#createTime').val(),
            staffInfoId: $('#staffSelect').val()
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