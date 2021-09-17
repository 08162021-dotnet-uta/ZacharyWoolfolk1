const welcomediv = document.querySelector('.welcomediv');

if (!sessionStorage.user) {
    location.href = "index.html";
}
else {
    let user = JSON.parse(sessionStorage.getItem('user'));
    console.log(user);
    welcomediv.innerHTML = `${user.res.firstName} ${user.res.lastName}.`;

    GetStoreList();
}

function GetStoreList() {

}
