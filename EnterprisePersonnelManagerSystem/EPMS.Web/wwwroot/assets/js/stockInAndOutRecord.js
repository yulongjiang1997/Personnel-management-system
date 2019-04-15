function initTable () {
    console.log(12)
    var url = '/api/Stock/QueryInAndOutRecordPagin'
    var data = {
      page:1,
      number:100
    }
    util.ajaxPost(data, url).then(res => {
      res.items.forEach(element => {
        $('#content').append(`
      <tr data-id="${element.id}">
      <td class="stockProductName">${element.stockProductName}</td>
      <td class="number">${element.number}</td>
      <td class="inAndOutStockType">${element.inAndOutStockType===0?"入库":"出库"}</td>
      <td class="surplusStock">${element.surplusStock}</td>
      <td class="createTime">${element.createTime.replace('T',' ').split('.')[0]}</td>
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