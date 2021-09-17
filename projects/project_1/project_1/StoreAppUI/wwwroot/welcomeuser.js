const welcomediv = document.querySelector('.welcomediv');
const storeform = document.querySelector(".storeform");



    if (!sessionStorage.user) {
        location.href = "index.html";
    }
    else {
        let user = JSON.parse(sessionStorage.getItem('user'));
        console.log(user);
        welcomediv.innerHTML = `${user.res.firstName} ${user.res.lastName}.`;

        GetStoreList();
}

//storeform.addEventListener('submit', (e) => {
//    e.preventDefault();
//    const location1 = storeform;
//    sessionStorage.setItem('store', JSON.stringify({ location1 }));
//    console.log(sessionStorage.store);
//});

    function GetStoreList() {
        fetch("location/Locationlist")
            .then(res => res.json())
            .then(data => {
                console.log(data)
                const lol = document.querySelector('.listofstores');
                for (let x = 0; x < data.length; x++) {
                    lol.innerHTML += `<a href="#" onclick="SeeProducts(${data[x].storeId})">${data[x].location1}</a><br>`;
                }
                //.then(res => {
                //    console.log(res);
                //    //store the id, if found, in the sessionStorage
                //    sessionStorage.setItem('user', JSON.stringify({ res }));
                //    console.log(sessionStorage.user);
            });
}

function SeeProducts(id) {
    console.log(id);
    sessionStorage.setItem('store', JSON.stringify(id));
    location.href = "products.html";
}

