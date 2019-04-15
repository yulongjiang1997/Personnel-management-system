function initTable () {
  console.log(12)
  var url = '/api/Position/QueryPagin'
  var data = {
    page: 1,
    number: 100
  }
  util.ajaxPost(data, url).then(res => {
    res.items.forEach(element => {
      $('#content').append(`
      <tr data-id="${element.id}">
      <td class="positionName">${element.name}</td>
      <td class="departmentName">${element.departmentName}</td>
      <td class="createTime">${element.createTime.replace('T',' ')}</td>
      <td class="lastUpTime">${element.lastUpTime.replace('T',' ')}</td>
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

$('#addPosition').click(function () {
  console.log(1)
  var title = '添加职位'
  var htmlCode = `
<div class="panel-body" id="newPosition">
    <form class="form-horizontal" id="form-validate" role="form" autocomplete="off">
        <div class="form-group">

            <div class="form-group">
                <label class="col-lg-2 control-label" for="positionName">职位名称</label>
                <div class="col-lg-10">
                    <input class="form-control" id="positionName" type="text" />
                </div>
            </div>

            <div class="form-group">
                <label class="col-lg-2 control-label" for="departmentSelect">部门名称</label>
                <div class="col-lg-10">
                    <select class="form-control" id="departmentSelect">
                        <option value="" disabled="" class="hide" selected="">请选择部门</option>

                    </select>
                </div>
            </div>

            <div class="form-group">
                <div class="col-lg-offset-2" style="padding-left:15px">
                    <div style="display:inline-block" class="customBtnWrapper">
                        <button type="button" class="btn btn-default customButton mr10" id="addPositionBtn">
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

  var url = '/api/Department/QueryPagin'
  var data = {
    page: 1,
    number: 100
  }
  util.ajaxPost(data, url).then(res => {
    res.items.forEach(element => {
      $('#departmentSelect').append(`
    <option value="${element.id}">${element.name}</option>`)
    })
  }).catch(err => {
    console.log(err)
  })

  $.jConfirm(title, htmlCode, '100%', 450)

  $('#cancel').click(function () {
    $.alert._close()
  })

  $('#addPositionBtn').click(function () {
    var url = '/api/Position/Create'
    var data = {
      name: $('#positionName').val(),
      departmentId: $('#departmentSelect').val()
    }
    util.ajaxPost(data, url).then(res => {
      if (res.result) {
        alert('添加成功')
        location.reload()
      }else {
        alert(res.message)
      }
    })
  })
})

$('body').on('click', '.delete', function () {
  var url = '/api/Position/Delete'
  util.ajaxDelete($(this).parents('tr').attr('data-id'), url).then(res => {
    if (res) {
      alert('删除成功')
      location.reload()
    }else {
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
   <form class="form-horizontal" id="form-validate"  role="form" autocomplete="off">
   <div class="form-group">
   <div class="form-group">
   <label class="col-lg-2 control-label" for="positionName">职位名称</label>
   <div class="col-lg-10">
       <input class="form-control" id="positionName"  type="text"  value="${trData.find(".positionName").text()}" />
   </div>
</div>

<div class="form-group">
   <label class="col-lg-2 control-label" for="departmentSelect">部门名称</label>
   <div class="col-lg-10">
       <select class="form-control" id="departmentSelect">
           <option value="" disabled="" class="hide" selected="">请选择部门</option>

       </select>
   </div>
</div>

     </div>
  <div class="form-group">
                      <div class="col-lg-offset-2" style="padding-left:15px">
                          <div style="display:inline-block" class="customBtnWrapper">
              <button type="button" class="btn btn-default customButton mr10" id="editDepartmentBtn">
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

  var url = '/api/Department/QueryPagin'
  var data = {
    page: 1,
    number: 100
  }
  util.ajaxPost(data, url).then(res => {
    res.items.forEach(element => {
      console.log(element.name + '   ' + trData.find('.departmentName').text())
      $('#departmentSelect').append(`
    <option value="${element.id}" ${element.name==trData.find(".departmentName").text()?`selected=""`:""}>${element.name}</option>`)
    })
  }).catch(err => {
    console.log(err)
  })

  $('#cancel').click(function () {
    $.alert._close()
  })

  $('#editDepartmentBtn').click(function () {
    var url = '/api/Position/Edit'
    var data = {
      name: $('#positionName').val(),
      departmentId: $('#departmentSelect').val(),
      lastUpTime: trData.find('.lastUpTime').text()
    }
    util.ajaxPut($(base).parents('tr').attr('data-id'), url, data).then(res => {
      if (res.result) {
        alert('修改成功')
        location.reload()
      }else {
        alert('修改失败')
      }
    })
  })
})
