//var baseUrl = "http://118.24.18.189:8888";
var baseUrl = "http://10.0.0.17:5000";

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
                        console.log("123")
                        resolve(res)
                    },
                    error: function (err) {
                        console.log("3456")
                        reject(err)
                    }

                })
            })
        },

        ajaxGet() {
            $.ajax({

            })
        },

        ajaxDelete() {
            $.ajax({

            })
        }

        , ajaxPut() {
            $.ajax({

            })
        }


    }
})()