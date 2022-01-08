$(document).ready(function () {
    $("#register").click(function () {
        var Username = $("#Username").val();
        var Password = $("#Password").val();
        if (Username != "" && Password != "") {
            $.ajax({
                type: "POST",
                url: "/Register/Index",
                data: { Username: Username, Password: Password },
                success: function (result) {
                    if (result == false) {
                        var arr = Array.from(Username.toLowerCase());

                        for (var c = 0; c < arr.length; c++) {
                            if (arr.charCodeAt(c) < 65 || 90 < arr.charCodeAt(c)) {
                                alert('İsminiz sadece harf içerebilir.');
                            }
                        }
                        if (Password.length < 6) {
                            alert('Parola en az 6 karakterli olmalıdır!');
                        }
                        
                        alert('Başarıyla kaydoldunuz!');
                        window.location.href = "/Admin/Index";
                    }
                    else {
                        alert('Böyle bir kullanıcı zaten var');
                        window.location.href = "/Register/Index";
                    }
                },
                error: function (result) {
                    console.log('error');
                    alert('Bir şeyler yanlış gitti!');
                }
            });
        }
        else {
            alert('Bütün alanların doldurulması zorunludur!');
        }
    });
});