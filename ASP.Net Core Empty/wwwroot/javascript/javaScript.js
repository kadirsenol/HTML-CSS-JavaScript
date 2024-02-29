

//Tüm dökümanlarda ki ilgili id elementlerin eventlerinin dinlenmesi yontemi
document.getElementById("persoregister").addEventListener("submit", function (e) {
    const isim = document.getElementById("isim").value;
    const yas = Number(document.getElementById("yas").value);
    const departman = Number(document.getElementById("departman").value);
    if (isim == "" || yas == 0 || departman==0) {
        alert("Lütfen ilgili yerleri doldurunuz.");

        /*buradan devam et kayıt işlemi yaptır*/
    }
    
    if (isim != "" && yas > 0 && departman > 0) {
       
        addTable(isim,yas,departman,e);
        clearText();
    }
    e.preventDefault(); // Submit butonu doğal davranışında ilgili actiona gitmek ister ve sayfa yenilenir. Bunu engelliyoruz.
});

//Bagımsız metot kullanıp, html içinde onclick eventine baglama yontemi 
function clearText(){
    document.getElementById("isim").value = "";
    document.getElementById("yas").value = 0;
    document.getElementById("departman").value = 0;
}
function addTable(isim,departman,yas,e) {
    
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
                                         <td class="px-5">${yas}</td>
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


