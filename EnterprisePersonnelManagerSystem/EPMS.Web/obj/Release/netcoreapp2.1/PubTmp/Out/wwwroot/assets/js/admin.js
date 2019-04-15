function initTable () {
  console.log(12)
  var url = '/api/Admin/QueryPagin'
  var data = {
  }
  util.ajaxPost(data, url).then(res => {
    res.forEach(element => {
      $('#content').append(`
    <tr data-id="${element.id}">
    <td class="name">${element.name}</td>
    <td class="account">${element.account}</td>
    <td class="email">${element.email}</td>
    <td>${element.createTime.replace('T',' ').split('.')[0]}</td>
    <td class="lastUpTime">${element.lastUpTime.replace('T',' ').split('.')[0]}</td>
    ${localStorage.getItem("check")==='true'?`<td>
    <div style="display:flex;justify-content:space-around">
    <svg  class="edit icon cPointer" aria-hidden="true" style="font-size:20px">
    <use xlink:href="#icon-edit"></use>
  </svg>
  <svg class="delete icon cPointer" aria-hidden="true" style="font-size:20px">
    <use xlink:href="#icon-delete"></use>
  </svg>
    </div>

  </td>`:''}

    </tr>
    `)
    })
  }).catch(err => {
    console.log(err)
  })
}

$(function () {
    $("#tableHead").append(`<tr>
    <th>姓名</th>
    <th>账号</th>
    <th>邮箱</th>
    <th>添加时间</th>
    <th>修改时间</th>
    ${localStorage.getItem("check")==='true'?"<th>操作</th>":''}
    </tr>`);
   $(".panel-heading").append(`${localStorage.getItem("check")==='true'?"<span>管理员账号信息</span>":''}`);
  initTable();
})


$("body").on('click','.edit',function () {
  var base=this;
  var trData=$(this).parents('tr')
  var title = '编辑管理员信息'
  var htmlCode = `
 <div class="panel-body" id="newPurchase">
 <form class="form-horizontal" id="form-validate"  role="form" autocomplete="off">
     <div class="form-group">
     <div class="form-group">
         <label class="col-lg-2 control-label" for="account">账号</label>
         <div class="col-lg-10">
             <input class="form-control" id="account" name="account" type="text" value="${trData.find(".account").text()}" />
         </div>
     </div>
     <div class="form-group">
     <label class="col-lg-2 control-label" for="name">姓名</label>
     <div class="col-lg-10">
         <input class="form-control" id="name" name="name" type="text"  value="${trData.find(".name").text()}"/>
     </div>
 </div>
 <div class="form-group">
 <label class="col-lg-2 control-label" for="email">邮箱</label>
 <div class="col-lg-10">
     <input class="form-control" id="email" name="email" type="text"  value="${trData.find(".email").text()}" />
 </div>
</div>
<div class="form-group">
<label class="col-lg-2 control-label" for="password">密码</label>
<div class="col-lg-10">
    <input class="form-control" id="password" name="password" type="text" />
</div>
</div>
<div class="form-group">
                    <div class="col-lg-offset-2" style="padding-left:15px">
                        <div style="display:inline-block" class="customBtnWrapper">
            <button type="button" class="btn btn-default customButton mr10" id="editAdminBtn">
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

  $('#editAdminBtn').click(function () {
    var url = '/api/Admin/Edit'
    var data = {
      account: $('#account').val(),
      name: $('#name').val(),
      password: $('#password').val(),
      email: $('#email').val(),
      lastUpTime:trData.find(".lastUpTime").text()
    }
    util.ajaxPut($(base).parents('tr').attr('data-id'),url, data).then(res => {
      if (res.result) {
        alert('修改成功')
        location.reload();
      }else {
        alert('修改失败')
      }
    })
  })
})


$("body").on('click','.delete',function () {
  var url='/api/Admin/Delete';
  util.ajaxDelete($(this).parents('tr').attr('data-id'),url).then(res=>{
    if(res){
      alert("删除成功");
      location.reload();
    }
    else{
      alert("删除失败")
    }
  })
})


$('#addAdmin').click(function () {
  var title = '添加管理员'
  var htmlCode = `
 <div class="panel-body" id="newPurchase">
 <form class="form-horizontal" id="form-validate"  role="form" autocomplete="off">
     <div class="form-group">
     <div class="form-group">
         <label class="col-lg-2 control-label" for="account">账号</label>
         <div class="col-lg-10">
             <input class="form-control" id="account" name="account" type="text" />
         </div>
     </div>
     <div class="form-group">
     <label class="col-lg-2 control-label" for="name">姓名</label>
     <div class="col-lg-10">
         <input class="form-control" id="name" name="name" type="text" />
     </div>
 </div>
 <div class="form-group">
 <label class="col-lg-2 control-label" for="email">邮箱</label>
 <div class="col-lg-10">
     <input class="form-control" id="email" name="email" type="text" />
 </div>
</div>
<div class="form-group">
<label class="col-lg-2 control-label" for="password">密码</label>
<div class="col-lg-10">
    <input class="form-control" id="password" name="password" type="text" />
</div>
</div>
<div class="form-group">
                    <div class="col-lg-offset-2" style="padding-left:15px">
                        <div style="display:inline-block" class="customBtnWrapper">
            <button type="button" class="btn btn-default customButton mr10" id="addAdminBtn">
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

  $('#addAdminBtn').click(function () {
    var url = '/api/Admin/Create'
    var data = {
      account: $('#account').val(),
      name: $('#name').val(),
      password: $('#password').val(),
      email: $('#email').val()
    }
    util.ajaxPost(data, url).then(res => {
      if (res.obj) {
        alert('添加成功')
        location.reload();
      }else {
        alert('添加失败')
      }
    })
  })
// $("#wrapper").append(htmlCode)
})
