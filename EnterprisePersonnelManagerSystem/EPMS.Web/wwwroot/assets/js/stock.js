function initTable () {
  console.log(12)
  var url = '/api/Stock/QueryPagin'
  var data = {
    page:1,
    number:100
  }
  util.ajaxPost(data, url).then(res => {
    res.items.forEach(element => {
      $('#content').append(`
    <tr data-id="${element.id}">
    <td class="productName">${element.productName}</td>
    <td class="number">${element.number}</td>
    <td class="lastUpTime">${element.lastUpTime.replace('T',' ').split('.')[0]}</td>
    <td >
      <div style="display:flex;justify-content:space-around">

      <div  title="入库">
      <svg  class="in icon cPointer" aria-hidden="true" style="font-size:20px">
      <use xlink:href="#icon-in"></use>
      </svg>
      </div>

      <div  title="出库">
      <svg  class="out icon cPointer" aria-hidden="true" style="font-size:20px" >
      <use xlink:href="#icon-out"></use>
      </svg>
      </div>

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

function inAndOut(type){

    var base=this;
    console.log(this)
    var trData=$(this).parents('tr')
    var title = type===0?"入库":"出库"
    var htmlCode = `
   <div class="panel-body" id="newPurchase">
   <form class="form-horizontal" id="form-validate"  role="form" autocomplete="off">
   <div class="form-group">
   <div class="form-group">
       <label class="col-lg-2 control-label" for="productSelect">商品名称</label>
       <div class="col-lg-10">
       <select class="form-control" id="productSelect" >
          
       </select>
   </div>
   </div>
   <div class="form-group">
   <label class="col-lg-2 control-label" for="addnumber">${type===0?"入库数量":"出库数量"}</label>
   <div class="col-lg-10">
       <input class="form-control" id="addnumber" type="text" />
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
  
    var turl = '/api/Product/QueryPagin'
    var tdata = {
      page:1,
      number:100
    }
    util.ajaxPost(tdata, turl).then(res => {
      res.items.forEach(elm=>{
        $("#productSelect").append(`<option value="${elm.id}" selected="">${elm.name}</option>`)
      })
    }).catch(err => {
      console.log(err)
    })
  
  
    $('#cancel').click(function () {
      $.alert._close()
    })
  
    $('#editProductBtn').click(function () {
      var url = '/api/Stock/InAndOut'
      var data = {
        productId: $('#productSelect').val(),
        number: $('#addnumber').val(),
        inOrOut:type,
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
  }


$("body").on('click','.in',function(){
  inAndOut.bind(this,0)()
  // console.log(this)
})
// inAndOut.bind(this,0))
$("body").on('click','.out',function(){
  inAndOut.bind(this,1)()
})


$("body").on('click','.delete',function () {
  var url='/api/Stock/Delete';
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


$('#addStock').click(function () {
    
  var title = '添加库存'
  var htmlCode = `
 <div class="panel-body" id="newPurchase">
 <form class="form-horizontal" id="form-validate"  role="form" autocomplete="off">
     <div class="form-group">
     <div class="form-group">
         <label class="col-lg-2 control-label" for="productSelect">商品名称</label>
         <div class="col-lg-10">
         <select class="form-control" id="productSelect" >
             <option value="" disabled="" class="hide" selected="">请选择商品</option>
            
         </select>
     </div>
     </div>
     <div class="form-group">
     <label class="col-lg-2 control-label" for="addnumber">入库数量</label>
     <div class="col-lg-10">
         <input class="form-control" id="addnumber" type="text" />
     </div>
 </div>
 
<div class="form-group">
                    <div class="col-lg-offset-2" style="padding-left:15px">
                        <div style="display:inline-block" class="customBtnWrapper">
            <button type="button" class="btn btn-default customButton mr10" id="addStockBtn">
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
  var turl = '/api/Product/QueryPagin'
  var tdata = {
    page:1,
    number:100
  }
  util.ajaxPost(tdata, turl).then(res => {
    res.items.forEach(elm=>{
      $("#productSelect").append(`<option value="${elm.id}">${elm.name}</option>`)
    })
  }).catch(err => {
    console.log(err)
  })
  $('#cancel').click(function () {
    $.alert._close()
  })

  $('#addStockBtn').click(function () {
    var url = '/api/Stock/Create'
    var data = {
      productId: $('#productSelect').val(),
      number: $('#addnumber').val(),
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
// $("#wrapper").append(htmlCode)
})
