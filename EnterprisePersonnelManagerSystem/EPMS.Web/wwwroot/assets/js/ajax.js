// var baseUrl = "http://118.24.18.189:8888";
 //var baseUrl = "http://127.0.0.1:5000";
var baseUrl = "http://192.168.1.6:5000";

var util = (function () {
    return {
        ajaxPost(data, url) {
            return new Promise((resolve, reject) => {
                $.ajax({
                    url: baseUrl + url,
                    type: "POST",
                    contentType: "application/json",
                    handers: {
                        token: localStorage.getItem('token') || '',
                        userId: localStorage.getItem('userId') || ''
                    },
                    data: JSON.stringify(data),
                    success(res) {
                        console.log("POSTSuccess")
                        resolve(res)
                    },
                    error: function (err) {
                        console.log("POSTerror")
                        reject(err)
                    }

                })
            })
        },

        ajaxGet(url) {
            return new Promise((resolve, reject) => {
                $.ajax({
                    url: baseUrl + url,
                    type: "GET",
                    contentType: "application/json",
                    handers: {
                        token: localStorage.getItem('token') || '',
                        userId: localStorage.getItem('userId') || ''
                    },
                    success(res) {
                        console.log("GETSuccess")
                        resolve(res)
                    },
                    error: function (err) {
                        console.log("GETSuccesserror")
                        reject(err)
                    }

                })
            })
        },

        ajaxDelete(id, url) {
            return new Promise((resolve, reject) => {
                $.ajax({
                    url: baseUrl + url+"?id="+id,
                    type: "Delete",
                    contentType: "application/json",
                    handers: {
                        token: localStorage.getItem('token') || '',
                        userId: localStorage.getItem('userId') || ''
                    },
                    success(res) {
                        console.log("DeleteSuccess")
                        resolve(res)
                    },
                    error: function (err) {
                        console.log("errorSuccess")
                        reject(err)
                    }

                })
            })
        },

        ajaxPut(id,url,data) {
            return new Promise((resolve, reject) => {
                console.log(id)
                $.ajax({
                    url: baseUrl + url+"?id="+id,
                    type: "Put",
                    contentType: "application/json",
                    handers: {
                        token: localStorage.getItem('token') || '',
                        userId: localStorage.getItem('userId') || ''
                    },
                    data: JSON.stringify(data),
                    success(res) {
                        console.log("123")
                        resolve(res)
                    },
                    error: function (err) {
                        console.log("3456")
                        reject(err)
                    }

                })
            })
        }


    }
})()