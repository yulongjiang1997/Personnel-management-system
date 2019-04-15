function initTable () {
    console.log(12)
    var url = '/api/Product/QueryPagin'
    var data = {
      page:1,
      number:100
    }
    util.ajaxPost(data, url).then(res => {
      res.items.forEach(element => {
        $('#content').append(`
      <tr data-id="${element.id}">
      <td class="productName">${element.name}</td>
      <td class="number">${element.number}</td>
      <td class="price">${element.price}</td>
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

  $('#addProduct').click(function () {
    var title = '添加商品'
    var htmlCode = `
   <div class="panel-body" id="newPurchase">
   <form class="form-horizontal" id="form-validate"  role="form" autocomplete="off">
       <div class="form-group">

       <div class="form-group">
       <label class="col-lg-2 control-label" for="productName">商品名称</label>
       <div class="col-lg-10">
           <input class="form-control" id="productName" type="text" />
       </div>
       </div>

       <div class="form-group">
       <label class="col-lg-2 control-label" for="number">商品编号</label>
       <div class="col-lg-10">
           <input class="form-control" id="number" type="text" />
       </div>
       </div>

        <div class="form-group">
       <label class="col-lg-2 control-label" for="price">商品价格</label>
       <div class="col-lg-10">
           <input class="form-control" id="price" type="text" />
       </div>
       </div>

         </div>
   
  <div class="form-group">
                      <div class="col-lg-offset-2" style="padding-left:15px">
                          <div style="display:inline-block" class="customBtnWrapper">
              <button type="button" class="btn btn-default customButton mr10" id="addProductBtn">
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
  
    $('#addProductBtn').click(function () {
      var url = '/api/Product/Create'
      var data = {
        number: $('#number').val(),
        name: $('#productName').val(),
        price: $('#price').val(),
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
    var url='/api/Product/Delete';
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
    var title = '编辑商品信息'
    var htmlCode = `
   <div class="panel-body" id="newPurchase">
   <form class="form-horizontal" id="form-validate"  role="form" autocomplete="off">
   <div class="form-group">

   <div class="form-group">
   <label class="col-lg-2 control-label" for="productName">商品名称</label>
   <div class="col-lg-10">
       <input class="form-control" id="productName" type="text" value="${trData.find(".productName").text()}" />
   </div>
   </div>

   <div class="form-group">
   <label class="col-lg-2 control-label" for="number" >商品编号</label>
   <div class="col-lg-10">
       <input class="form-control" id="number" type="text" value="${trData.find(".number").text()}"/>
   </div>
   </div>

    <div class="form-group">
   <label class="col-lg-2 control-label" for="price" >商品价格</label>
   <div class="col-lg-10">
       <input class="form-control" id="price" type="text" value="${trData.find(".price").text()}"/>
   </div>
   </div>

     </div>
  <div class="form-group">
                      <div class="col-lg-offset-2" style="padding-left:15px">
                          <div style="display:inline-block" class="customBtnWrapper">
              <button type="button" class="btn btn-default customButton mr10" id="editProductBtn">
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
  
    $('#editProductBtn').click(function () {
      var url = '/api/Product/Edit'
      var data = {
        number: $('#number').val(),
        name: $('#productName').val(),
        price: $('#price').val(),
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