


document.getElementById("persoregister").addEventListener("submit", function (e) { //Tüm dökümanlarda ki ilgili id elementlerin eventlerinin dinlenmesi yontemi
    const isim = document.getElementById("isim").value;
    const yas = document.getElementById("yas").value;
    const departman = document.getElementById("departman").value; // Note ==> Gelen veri int ailesinden ise ifadeyi Number() ile sayısal veriye cevirleyiz. Default string donuyor.
    if (isim == "" || (yas == "" || yas == 0) || departman == 0 ) {
        alert("Lütfen ilgili yerleri doldurunuz.");

        /*buradan devam et kayıt işlemi yaptır*/
    }

    if (isim != "" && (yas != "" && yas != 0) && departman != 0) {
       
        addTable(isim, departman, yas);
        AddLocalStorage(isim, yas, departman);
        clearText();
    }
    e.preventDefault(); // Submit butonu doğal davranışında ilgili actiona gitmek ister ve sayfa yenilenir. Bunu engelliyoruz.
});


function clearText() { //Bagımsız metot kullanıp, html içinde onclick eventine baglama yontemi 
    document.getElementById("isim").value = "";
    document.getElementById("yas").value = "";
    document.getElementById("departman").value = 0;
}
function addTable(isim,departman,yas) {
    
    const virtualtb = document.getElementById("virtualtable"); // Eklemek istediğin dive konumlan (ID üzerinden konumlanma)


    if (!virtualtb.innerHTML.includes("table"))//virtualtb bir dom elemanı değildir evet ama bizde bunu documentten aramıyoruz yani içerisine bu şekilde erişebiliriz.
    {

        const table = document.createElement("table"); // Olusturmak istediğin elementi create le.
        table.innerHTML = `
                             <thead class="table" >
                                 <tr>
                                     <th class="px-5"> İsim </th>
                                     <th class="px-5"> Departman </th>
                                     <th class="px-5"> Yaş </th>
                                 </tr>
                             </thead>
                                 <tbody>
                                     <tr>
                                         <td class="px-5">${isim} </td>                                        
                                         <td class="px-5">${departman}</td>
                                         <td class="px-5">${yas} </td>
                                         <td> <button class="btn btn-danger delete" style="height: 25px; padding-top: 0; padding-bottom: 0;" >X</button> </td>
                                        
                                     </tr>
                                 </tbody>
                         `
        virtualtb.appendChild(table); //Olusturulan table, konumlanılan divin childine eklenir.
    }

        else {
            const tblbdy = virtualtb.querySelector("tbody");//Tag üzerinden konumlanma. Virtualtb nin tbody tagine konuçlandım. Documen üzerinden gitmedim çünkü virtualtb bir dom elemanı değil.
            const tablerow = document.createElement("tr"); // Olusturmak istediğin elementi create le.
            tablerow.innerHTML = `  
                                   <td class="px-5">${isim} </td>
                                   <td class="px-5">${departman}</td>
                                   <td class="px-5">${yas}</td>
                                   <td> <button class="btn btn-danger delete" style="height: 25px; padding-top: 0; padding-bottom: 0;" >X</button> </td>
                                            
                                  `
            tblbdy.appendChild(tablerow); //Olusturulan table, konumlanılan tbody nin childine eklenir.
        }

}


document.getElementById("virtualtable").addEventListener("click", function (e) //Bu sekilde surekli click eventini dinliyor
                                                                               //Bunu bir metodun icerisinde sadece, butonun
                                                                               //onclick ozelligine metot ekledigimiz zaman ekledigimiz metodun icerisinde yazabiliriz . Bu olay sureki event dinlemek icin metot icinde yazilmaz
                                                                               //Eger ilk basta sadece ilgili butona focuslansaydık target ile click i tetikleyeni aramaya calismicaktık cunku bir tane tetiklenebilen element var.


{
    if (e.target.classList.contains("delete")) { //Burada click eventini kimin tetiklediğini target keywordu ile ayıklama islemini yapıyoruz.                               
        if (document.getElementById("virtualtable").querySelectorAll("tr").length > 2) {  
            e.target.parentElement.parentElement.remove();
        }
        else {
            e.target.parentElement.parentElement.parentElement.parentElement.remove();
        }   
    }

});


function AddLocalStorage(isim, yas, departman) { // Kullanicinin browserine ufak veriler saklama icin kullanilir. Bu sekilde en son kayıt edilen personel bilgilerini tekrar getirebiliriz.
                                                 // Baska bir uygulama olarak bir login ekranında kullanıcı adi ve sifreyi tekrar girilmesine gerek kalmadan ilgili inputlara basabiliriz.

  //localStorage.setItem(isim, "isim"); Tek atma yontemi genelde tercih edilmez, json ile toplu veri tutulmasi daha mantikli

    let addjson = { "Ad": isim, "Yas": yas, "Pozisyon": departman } // Note=> {"key":[{"key":value,"key":value},{"key":value,"key":value}]}
                                                                    //        seklinde birden fazla kullanici icin dizi json olusturulabilir.
                                                                    //        Json bir objedir. Key i degisken olarak belirtmek icin [] operanti kullan.
    
    localStorage.setItem(1, JSON.stringify(addjson)); // keyi benzersiz kılmak icin new Date() metodunu kullanabiliriz.
                                                      // json verimizi value olarak gecebilmemiz icin json oldugunu belirtmemiz gerekiyor.

}

document.addEventListener("DOMContentLoaded", function(){ //Formun yuklenme eventini dinliyor

    if (localStorage.getItem(1) != null) {

        let getjson = JSON.parse(localStorage.getItem(1)); // Default olarak string doner, json donebilmemiz icin JSON.parse ile parse etmemiz gerekmektedir. Aksi taktirde object donecektir
                                                           // Ardından json icerisinde ki ilgili keyleri donebiliriz.

        document.getElementById("isim").value = getjson.Ad;
        document.getElementById("yas").value = getjson.Yas;
        document.getElementById("departman").value = getjson.Pozisyon;

    }

});


