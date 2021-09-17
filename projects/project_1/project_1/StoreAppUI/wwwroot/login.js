const loginform = document.querySelector(".loginform");

loginform.addEventListener('submit', (e) => {
    e.preventDefault();
    const fname = loginform.fname.value;
    const lname = loginform.lname.value;

    //GET fetch request
    fetch(`customer/login/${fname}/${lname}`)
        .then(res => {
            if (!res.ok) {
                console.log('Login failed')
                throw new Error(`Network response was not ok (${res.status})`);
            }
            return res.json();
        })
        .then(res => {
            console.log(res);
            //store the id, if found, in the sessionStorage
            sessionStorage.setItem('user', JSON.stringify({ res }));
            console.log(sessionStorage.user);

            location.href = "welcomeuser.html";
        })
    .catch (err => console.log(`There was an error ${err}`));
});