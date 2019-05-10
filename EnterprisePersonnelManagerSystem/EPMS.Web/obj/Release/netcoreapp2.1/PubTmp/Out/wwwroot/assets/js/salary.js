function initTable () {
    var url = '/api/Salary/QueryPagin'
    var data = {
      page:1,
      number:100
    }
    util.ajaxPost(data, url).then(res => {
      res.items.forEach(element => {
        $('#contentDetail').append(`
      <tr data-id="${element.id}">
      <td class="staffInfoName">${element.staffInfoName}</td>
      <td class="createTime">${element.createTime.replace('T',' ')}</td>
      <td class="basicSalary">${element.basicSalary}元</td>
      <td class="transportationSubsidy">${element.transportationSubsidy}元</td>
      <td class="mealSubsidy">${element.mealSubsidy}元</td>
      <td class="otherSubsidies">${element.otherSubsidies}元</td>
      <td class="reward">${element.reward}元</td>
      <td class="deduction">${element.deduction}元</td>
      
      <td >
        <div style="display:flex;justify-content:space-around">
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
  initTable();
  // $(function () {
  //   initTable();
  // })

  $('#addSalaryDetail').click(function () {
    var title = '添加工资明细'
    var htmlCode = `
   <div class="panel-body" id="newPurchase">
   <form class="form-horizontal" id="form-validate"  role="form" autocomplete="off">



   <div class="form-group">
   <label class="col-lg-2 control-label" for="userSelect">员工姓名</label>
   <div class="col-lg-10">
       <select class="form-control" id="userSelect">
           <option value="" disabled class="hide" selected>请选择员工</option>

       </select>
   </div>
</div>



       <div class="form-group">
       <label class="col-lg-2 control-label" for="basicSalary">基本工资</label>
       <div class="col-lg-10">
           <input class="form-control" id="basicSalary" type="number" />
       </div>
       </div>

       <div class="form-group">
       <label class="col-lg-2 control-label" for="transportationSubsidy">交通补贴</label>
       <div class="col-lg-10">
           <input class="form-control" id="transportationSubsidy" type="number" />
       </div>
       </div>

        <div class="form-group">
       <label class="col-lg-2 control-label" for="mealSubsidy">餐费补贴</label>
       <div class="col-lg-10">
           <input class="form-control" id="mealSubsidy" type="number" />
       </div>
       </div>

       <div class="form-group">
       <label class="col-lg-2 control-label" for="otherSubsidies">	其他补贴</label>
       <div class="col-lg-10">
           <input class="form-control" id="otherSubsidies" type="text" />
       </div>
       </div>


       <div class="form-group">
       <label class="col-lg-2 control-label" for="reward">奖励</label>
       <div class="col-lg-10">
           <input class="form-control" id="reward" type="text" />
       </div>
       </div>

       <div class="form-group">
       <label class="col-lg-2 control-label" for="deduction">惩罚</label>
       <div class="col-lg-10">
           <input class="form-control" id="deduction" type="text" />
       </div>
       </div>

   
       <div class="form-group">
                      <div class="col-lg-offset-2" style="padding-left:15px">
                          <div style="display:inline-block" class="customBtnWrapper">
              <button type="button" class="btn btn-default customButton mr10" id="addSalary">
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

    $('#cancel').click(function () {
      $.alert._close()
    })

    util.ajaxPost(data, url).then(res => {
      res.items.forEach(element => {
          $('#userSelect').append(`
  <option value="${element.id}">${element.name}</option>`)
      })
  }).catch(err => {
      console.log(err)
  })


  
    $('#addSalary').click(function () {
      var url = '/api/Salary/Create'
      var data = {
        staffInfoId: $('#userSelect').val(),
        basicSalary: $('#basicSalary').val(),
        transportationSubsidy: $('#transportationSubsidy').val(),
        mealSubsidy:$('#mealSubsidy').val(),
        otherSubsidies:$('#otherSubsidies').val(),
        reward: $('#reward').val(),
        deduction: $('#deduction').val(),
      }
      util.ajaxPost(data, url).then(res => {
        if (res.result) {
          alert('添加成功')
          location.reload();
        }else {
          alert('添加失败')
        }
      })
    })
  })
  

  $("body").on('click','.delete',function () {
    var url='/api/Salary/Delete';
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


