document.getElementById("persoregister").addEventListener("submit", function (e) {
    const isim = document.getElementById("isim").value;
    const soyisim = document.getElementById("soyisim").value;
    if (isim == "" || soyisim == "") {
        alert("Lütfen ilgili yerleri doldurunuz.");

        /*buradan devam et kayıt işlemi yaptır*/
    }
  
});

function clear(){
    document.getElementById("isim").value == "";
    document.getElementById("soyisim").value == "";
}