var str = `<div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".sidebar-collapse">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" href="index.html">人事管理系统</a>
            </div>

            <ul class="nav navbar-top-links navbar-right"> 
                <!-- /.dropdown -->
                <li class="dropdown">
                    <a class="dropdown-toggle" data-toggle="dropdown" href="#" aria-expanded="false">
                        <i class="fa fa-user fa-fw"></i> <i class="fa fa-caret-down"></i> ${localStorage.getItem('userName')}
                    </a>
                    <ul class="dropdown-menu dropdown-user">
                        <li><a href="#"><i class="fa fa-user fa-fw"></i> 个人信息</a>
                        <li ><a href="#" id="outLogin"><i class="fa fa-sign-out fa-fw"></i> 退出登录</a>
                        </li>
                    </ul>
                    <!-- /.dropdown-user -->
                </li>
                <!-- /.dropdown -->
            </ul>`

$(function () {
    if(!localStorage.getItem('userName'))
    {
        localStorage.clear();
        alert("登录状态失效,请重新登录");
        location.href="login.html";
    }
  $('.headBar').append(str)

  $(`#outLogin`).click(function(){
    console.log("asdasd")
    localStorage.clear();
    location.href="login.html";
 })
// func(xxx)//执行函数
})


