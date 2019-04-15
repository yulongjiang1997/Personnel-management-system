var html = `<ul class="nav" id="main-menu">

<li>
    <a id="index" href="index.html"><i class="fa fa-dashboard"></i>仪表盘</a>
</li>
<li>
    <a href="adminInfo.html" id="adminInfo"><i class="fa fa-edit"></i>管理员列表</a>
</li>
<li>
    <a href="#"><i class="fa fa-sitemap"></i>职工管理<span class="fa arrow"></span></a>
    <ul class="nav nav nav-second-level collapse in">
        <li>
            <a href="userInfo.html" id="userInfo" class="left10" id="admin">员工基本信息</a>
        </li>
        <li>
            <a href="deparment.html" id="deparment" class="left10" id="admin">部门管理</a>
        </li>
        <li>
            <a href="position.html" id="position" class="left10" id="admin">职位管理</a>
        </li>
        <li>
            <a href="attendance.html" id="attendance" class="left10" id="admin">考勤管理</a>
        </li>
        <li>
            <a href="attendanceTime.html"  id="attendanceTime" class="left10" id="admin">考勤时间管理</a>
        </li>
    </ul>
</li>
<li>
    <a href="salary.html" id="salary"><i class="fa fa-desktop"></i>工资管理</a>
</li>
<li>
    <a href="#"><i class="fa fa-bar-chart-o"></i>商品管理<span class="fa arrow"></span></a>
    <ul class="nav nav nav-second-level collapse in">
        <li>
            <a href="product.html"  id="product"  class="left10" id="admin">商品信息</a>
        </li>
        <li>
            <a href="stock.html" id="stock"  class="left10" id="admin">库存管理</a>
        </li>
        <li>
            <a href="stockInAndOutRecord.html" id="stockInAndOutRecord" class="left10" id="admin">出入库明细</a>
        </li>
    </ul>
</li>
<li>
    <a href="#" ><i class="fa fa-qrcode"></i>日程管理<span class="fa arrow"></span></a>
    <ul class="nav nav nav-second-level collapse in">
    <li>
        <a href="personalSchedule.html" id="personalSchedule" class="left10">员工日程</a>
    </li>
    <li>
        <a href="companySchedule.html" id="companySchedule" class="left10">公司日程</a>
    </li>
</ul>
</li>

<li>
    <a href="log.html" id="log"><i class="fa fa-table"></i>日志记录</a>
</li>
</ul>`

$(function () {
  $('.sidebar-collapse').append(html)
  var name=pageName();
  $(`.nav #${name}`).addClass("active-menu")
// func(xxx)//执行函数
})




function pageName()
{
  var a = location.href;
  var b = a.split("/");
  var c = b.slice(b.length-1, b.length).toString(String).split(".");
  return c.slice(0, 1);
}
