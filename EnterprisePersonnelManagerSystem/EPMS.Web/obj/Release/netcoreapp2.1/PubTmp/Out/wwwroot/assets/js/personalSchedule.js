function initTable() {
    console.log(12)
    var url = '/api/PersonalSchedule/QueryPagin'
    var data = {
        page: 1,
        number: 100
    }
    util.ajaxPost(data, url).then(res => {
        res.items.forEach(element => {
            $('#content').append(`
      <tr data-id="${element.id}">
      <td class="userName">${element.userName}</td>
      <td class="eventName">${element.eventName}</td>
      <td class="eventDetails">${element.eventDetails}</td>
      <td class="scheduleTime">${element.scheduleTime.replace('T', ' ')}</td>
      <td class="createTime">${element.createTime.replace('T', ' ').split(`.`)[0]}</td>
      <td class="lastUpTime">${element.lastUpTime.replace('T', ' ').split(`.`)[0]}</td>
      <td >
        <div style="display:flex;justify-content:space-around">
        <svg  class="edit icon cPointer" aria-hidden="true" style="font-size:20px">
        <use xlink:href="#icon-edit"></use>
      </svg>
      <svg class="delete icon cPointer" aria-hidden="true" style="font-size:20px">
        <use xlink:href="#icon-delete"></use>
      </svg>
        </div>
  
      </td>
      </tr>
      `)
        })
    }).catch(err => {
        console.log(err)
    })
}

$(function () {
    initTable()
})

$('#addPersonalSchedule').click(function () {
    console.log(1)
    var title = '添加个人日程'
    var htmlCode = `
<div class="panel-body" id="newPosition">
    <form class="form-horizontal" id="form-validate" role="form" autocomplete="off">
        <div class="form-group">

<div class="form-group">
   <label class="col-lg-2 control-label" for="userSelect">员工姓名</label>
   <div class="col-lg-10">
       <select class="form-control" id="userSelect">
           <option value="" disabled="" class="hide" selected="">请选择员工</option>

       </select>
   </div>
</div>

            <div class="form-group">
                <label class="col-lg-2 control-label" for="eventName">日程名称</label>
                <div class="col-lg-10">
                    <input class="form-control" id="eventName" type="text" />
                </div>
            </div>

            <div class="form-group">
                <label class="col-lg-2 control-label" for="eventDetails">日程详情</label>
                <div class="col-lg-10">
                    <input class="form-control" id="eventDetails" type="text" />
                </div>
            </div>

                <div class="form-group">
                <label class="col-lg-2 control-label" for="scheduleTime">日程时间</label>
                <div class="col-lg-10">
                    <input class="form-control" id="scheduleTime" type="text" />
                </div>
            </div>

            <div class="form-group">
                <div class="col-lg-offset-2" style="padding-left:15px">
                    <div style="display:inline-block" class="customBtnWrapper">
                        <button type="button" class="btn btn-default customButton mr10" id="addPersonalScheduleBtn">
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
</div>`

    $.jConfirm(title, htmlCode, '100%', 450)

    var url = '/api/StaffInfo/QueryPagin'
    var data = {
        page: 1,
        number: 100
    }
    util.ajaxPost(data, url).then(res => {
        res.items.forEach(element => {
            $('#userSelect').append(`
    <option value="${element.id}">${element.name}</option>`)
        })
    }).catch(err => {
        console.log(err)
    })

    $('#cancel').click(function () {
        $.alert._close()
    })

    $('#addPersonalScheduleBtn').click(function () {
        var url = '/api/PersonalSchedule/Create'
        var data = {
            eventName: $('#eventName').val(),
            staffId: $('#userSelect').val(),
            eventDetails: $('#eventDetails').val(),
            scheduleTime: $('#scheduleTime').val(),
        }
        util.ajaxPost(data, url).then(res => {
            if (res.result) {
                alert('添加成功')
                location.reload()
            } else {
                alert(res.message)
            }
        })
    })
})

$('body').on('click', '.delete', function () {
    var url = '/api/PersonalSchedule/Delete'
    util.ajaxDelete($(this).parents('tr').attr('data-id'), url).then(res => {
        if (res) {
            alert('删除成功')
            location.reload()
        } else {
            alert('删除失败')
        }
    })
})

$('body').on('click', '.edit', function () {
    var base = this
    var trData = $(this).parents('tr')
    var title = '编辑职位信息'
    var htmlCode = `
<div class="panel-body" id="newPosition">
    <form class="form-horizontal" id="form-validate" role="form" autocomplete="off">
        <div class="form-group">

<div class="form-group">
   <label class="col-lg-2 control-label" for="userSelect">员工姓名</label>
   <div class="col-lg-10">
       <select class="form-control" id="userSelect">
           <option value="" disabled="" class="hide" selected="">请选择员工</option>

       </select>
   </div>
</div>

            <div class="form-group">
                <label class="col-lg-2 control-label" for="eventName">日程名称</label>
                <div class="col-lg-10">
                    <input class="form-control" id="eventName" type="text" value="${trData.find(".eventName").text()}"/>
                </div>
            </div>

            <div class="form-group">
                <label class="col-lg-2 control-label" for="eventDetails">日程详情</label>
                <div class="col-lg-10">
                    <input class="form-control" id="eventDetails" type="text" value="${trData.find(".eventDetails").text()}"/>
                </div>
            </div>

                <div class="form-group">
                <label class="col-lg-2 control-label" for="scheduleTime">日程时间</label>
                <div class="col-lg-10">
                    <input class="form-control" id="scheduleTime" type="text" value="${trData.find(".scheduleTime").text()}"/>
                </div>
            </div>

            <div class="form-group">
                <div class="col-lg-offset-2" style="padding-left:15px">
                    <div style="display:inline-block" class="customBtnWrapper">
                        <button type="button" class="btn btn-default customButton mr10" id="editPersonalScheduleBtn">
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
</div>`
    $.jConfirm(title, htmlCode, '100%', 450)

    var url = '/api/StaffInfo/QueryPagin'
    var data = {
        page: 1,
        number: 100
    }
    util.ajaxPost(data, url).then(res => {
        res.items.forEach(element => {
            $('#userSelect').append(`
    <option value="${element.id}" ${element.name == trData.find(".userName").text() ? `selected=""` : ""}>${element.name}</option>`)
        })
    }).catch(err => {
        console.log(err)
    })

    $('#cancel').click(function () {
        $.alert._close()
    })

    $('#editPersonalScheduleBtn').click(function () {
        var url = '/api/PersonalSchedule/Edit'
        var data = {
            eventName: $('#eventName').val(),
            staffId: $('#userSelect').val(),
            eventDetails: $('#eventDetails').val(),
            scheduleTime: $('#scheduleTime').val(),
        }
        util.ajaxPut($(base).parents('tr').attr('data-id'), url, data).then(res => {
            if (res.result) {
                alert('修改成功')
                location.reload()
            } else {
                alert('修改失败')
            }
        })
    })
})
