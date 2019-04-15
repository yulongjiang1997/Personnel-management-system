function initTable () {
    console.log(12)
    var url = '/api/Department/QueryPagin'
    var data = {
      page:1,
      number:100
    }
    util.ajaxPost(data, url).then(res => {
      res.items.forEach(element => {
        $('#content').append(`
      <tr data-id="${element.id}">
      <td class="departmentName">${element.name}</td>
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
    initTable();
  })

  $('#addDepartment').click(function () {
    console.log(1)
    var title = '添加部门'
    var htmlCode = `
   <div class="panel-body" id="newPurchase">
   <form class="form-horizontal" id="form-validate"  role="form" autocomplete="off">
       <div class="form-group">

       <div class="form-group">
       <label class="col-lg-2 control-label" for="departmentName">部门名称</label>
       <div class="col-lg-10">
           <input class="form-control" id="departmentName" type="text" />
       </div>
       </div>

         </div>
   
  <div class="form-group">
                      <div class="col-lg-offset-2" style="padding-left:15px">
                          <div style="display:inline-block" class="customBtnWrapper">
              <button type="button" class="btn btn-default customButton mr10" id="addDepartmentBtn">
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
  
    $('#addDepartmentBtn').click(function () {
      var url = '/api/Department/Create'
      var data = {
        name: $('#departmentName').val(),
      }
      util.ajaxPost(data, url).then(res => {
        if (res.result) {
          alert('添加成功')
          location.reload();
        }else {
          alert(res.message)
        }
      })
    })
  })


  $("body").on('click','.delete',function () {
    var url='/api/Department/Delete';
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


  $("body").on('click','.edit',function () {
    var base=this;
    var trData=$(this).parents('tr')
    var title = '编辑部门信息'
    var htmlCode = `
   <div class="panel-body" id="newPurchase">
   <form class="form-horizontal" id="form-validate"  role="form" autocomplete="off">
   <div class="form-group">

   <div class="form-group">
   <label class="col-lg-2 control-label" for="departmentName">商品名称</label>
   <div class="col-lg-10">
       <input class="form-control" id="departmentName" type="text" value="${trData.find(".departmentName").text()}" />
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
  
    $('#cancel').click(function () {
      $.alert._close()
    })
  
    $('#editDepartmentBtn').click(function () {
      var url = '/api/Department/Edit'
      var data = {
        name: $('#departmentName').val(),
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