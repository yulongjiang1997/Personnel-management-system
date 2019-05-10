function initTable() {
    console.log(12)
    var url = '/api/StaffInfo/QueryPagin'
    var data = {
        page: 1,
        number: 100
    }
    util.ajaxPost(data, url).then(res => {
        res.items.forEach(element => {
            $('#content').append(`
      <tr data-id="${element.id}">
      <td class="userName">${element.name}</td>
      <td class="phone">${element.phone}</td>
      <td class="email">${element.email}</td>
      <td class="positionName">${element.positionName}</td>
      <td class="entryTime">${element.entryTime.replace(`T`, ` `)}</td>
      <td class="resignationTime">${element.resignationTime === null ? `` : element.resignationTime.replace(`T`, ` `)}</td>
      <td class="workingStatus">${element.workingStatus === 1 ? `离职` : `在职`}</td>
      <td class="lastUpTime">${element.lastUpTime.replace(`T`, ` `)}</td>
      <td >
        <div style="display:flex;justify-content:space-around">
        <svg  class="edit icon cPointer" aria-hidden="true" style="font-size:20px">
        <use xlink:href="#icon-edit"></use>
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
    initTable();
})


$('#addUser').click(function () {
    var title = '添加员工'
    var htmlCode = `
   <div class="panel-body" id="newPurchase">
   <form class="form-horizontal" id="form-validate"  role="form" autocomplete="off">
       <div class="form-group">

       <div class="form-group">
       <label class="col-lg-2 control-label" for="userName">员工姓名</label>
       <div class="col-lg-10">
           <input class="form-control" id="userName" type="text" />
       </div>
       </div>

       <div class="form-group">
       <label class="col-lg-2 control-label" for="phone">手机号码</label>
       <div class="col-lg-10">
           <input class="form-control" id="phone" type="text" />
       </div>
       </div>

       <div class="form-group">
                <label class="col-lg-2 control-label" for="positionSelect">职位名称</label>
                <div class="col-lg-10">
                    <select class="form-control" id="positionSelect">
                        <option value="" disabled="" class="hide" selected="">请选择职位</option>

                    </select>
                </div>
            </div>

        <div class="form-group">
       <label class="col-lg-2 control-label" for="entryTime">入职时间</label>
       <div class="col-lg-10">
           <input class="form-control" id="entryTime" type="text" />
       </div>
       </div>

        <div class="form-group">
       <label class="col-lg-2 control-label" for="email">邮箱</label>
       <div class="col-lg-10">
           <input class="form-control" id="email" type="text" />
       </div>
       </div>



         </div>
   
            <div class="form-group">
                      <div class="col-lg-offset-2" style="padding-left:15px">
                          <div style="display:inline-block" class="customBtnWrapper">
              <button type="button" class="btn btn-default customButton mr10" id="addUserBtn">
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


    var purl = '/api/position/QueryPagin'
    var pdata = {
        page: 1,
        number: 100,
        departmentId: $("#departmentSelect").val()
    }
    util.ajaxPost(pdata, purl).then(res => {
        res.items.forEach(element => {
            $('#positionSelect').append(`
                 <option value="${element.id}">${element.name}</option>`)
        })
    }).catch(err => {
        console.log(err)
    })


    $('#cancel').click(function () {
        $.alert._close()
    })

    $('#addUserBtn').click(function () {
        alert(1)
        var url = '/api/StaffInfo/Create'
        var data = {
            name: $('#userName').val(),
            phone: $('#phone').val(),
            entryTime: $('#entryTime').val(),
            email: $('#email').val(),
            positionId: $('#positionSelect').val(),
            workingStatus: 0,
        }
        util.ajaxPost(data, url).then(res => {
            if (res.result) {
                alert('添加成功')
                location.reload();
            } else {
                alert('添加失败')
            }
        })
    })
})





$("body").on('click', '.edit', function () {
    var base = this;
    var trData = $(this).parents('tr')
    var title = '编辑商品信息'
    var htmlCode = `
   <div class="panel-body" id="newPurchase">
   <form class="form-horizontal" id="form-validate"  role="form" autocomplete="off">
       <div class="form-group">

       <div class="form-group">
       <label class="col-lg-2 control-label" for="userName">员工姓名</label>
       <div class="col-lg-10">
           <input class="form-control" id="userName" type="text" value="${trData.find(".userName").text()}"/>
       </div>
       </div>

       <div class="form-group">
       <label class="col-lg-2 control-label" for="phone">手机号码</label>
       <div class="col-lg-10">
           <input class="form-control" id="phone" type="text" value="${trData.find(".phone").text()}"/>
       </div>
       </div>

       <div class="form-group">
                <label class="col-lg-2 control-label" for="positionSelect">职位名称</label>
                <div class="col-lg-10">
                    <select class="form-control" id="positionSelect">
                        <option value="" disabled="" class="hide" selected="">请选择职位</option>

                    </select>
                </div>
            </div>

        <div class="form-group">
                <label class="col-lg-2 control-label" for="editWorkingStatus">在职状态</label>
                <div class="col-lg-10">
                    <select class="form-control" id="editWorkingStatus">
                    </select>
                </div>
            </div>

        <div class="form-group">
       <label class="col-lg-2 control-label" for="entryTime">入职时间</label>
       <div class="col-lg-10">
           <input class="form-control" id="entryTime" type="text" value="${trData.find(".entryTime").text()}"/>
       </div>
       </div>

        <div class="form-group">
       <label class="col-lg-2 control-label" for="email">邮箱</label>
       <div class="col-lg-10">
           <input class="form-control" id="email" type="text"  value="${trData.find(".email").text()}"/>
       </div>
       </div>

         </div>
   
            <div class="form-group">
                      <div class="col-lg-offset-2" style="padding-left:15px">
                          <div style="display:inline-block" class="customBtnWrapper">
              <button type="button" class="btn btn-default customButton mr10" id="editUserBtn">
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

    $('#cancel').click(function () {
        $.alert._close()
    })

    $("#editWorkingStatus").append(`
            <option value="0" ${trData.find(".workingStatus").text() == `在职` ? `selected` : ``} >在职</option>
            <option value="1" ${trData.find(".workingStatus").text() == `离职` ? `selected` : ``}>离职</option>
    `);
           

    var purl = '/api/Position/QueryPagin'
    var pdata = {
        page: 1,
        number: 100,
        departmentId: $("#departmentSelect").val()
    }
    util.ajaxPost(pdata, purl).then(res => {
        res.items.forEach(element => {
            $('#positionSelect').append(`
 <option value="${element.id}" ${element.name == trData.find(".positionName").text() ? `selected=""` : ""}>${element.name}</option>`)
        })
    }).catch(err => {
        console.log(err)
    })

    $('#editUserBtn').click(function () {
        var id = $(base).parents('tr').attr('data-id')
        var url = `/api/StaffInfo/Edit`
        var data = {
            name: $('#userName').val(),
            phone: $('#phone').val(),
            entryTime: $('#entryTime').val(),
            email: $('#email').val(),
            positionId: $('#positionSelect').val(),
            workingStatus: $('#editWorkingStatus').val(),
            lastUpTime: trData.find(".lastUpTime").text()
        }
        util.ajaxPut(id, url, data).then(res => {
            if (res.result) {
                alert('修改成功')
                location.reload();
            } else {
                alert('修改失败')
            }
        })
    })
})