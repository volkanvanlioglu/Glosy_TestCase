$(document).ready(function () {
    $("#login").click(function () {
        var Username = $("#Username").val();
        var Password = $("#Password").val();
        if (Username != "" && Password != "") {
            $.ajax({
                type: "POST",
                url: "/Login/Index",
                data: { Username: Username, Password: Password },
                success: function (result) {
                    if (result == true) {
                        alert('Başarıyla giriş yaptınız!');
                        window.location.href = "/Admin/Index"; //Admin sayfasına otomatik yönlendirmezse adres çubuğuna bu URL'i yazabilirsiniz.
                    }
                    else {
                        alert('Geçersiz kullanıcı adı veya parola!');
                        window.location.href = "/Login/Index";
                    }
                },
                error: function (result) {
                    console.log('error');
                    alert('Hay aksi! Bir şeyler ters gitti!');
                }
            });
        }
        else {
            alert('Bütün alanların doldurulması zorunludur!');
        }
    });
});