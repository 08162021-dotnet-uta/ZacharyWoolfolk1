const registerform = document.querySelector(".registerform");

registerform.addEventListener('submit', (e) => {
    e.preventDefault();
    const fname = registerform.fname.value;
    const lname = registerform.lname.value;
    const userData = {CustomerId: -1, FirstName: fname, LastName: lname}

    //POST fetch request
    fetch(`customer/register`, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(userData)
    })
        .then(response => {
            if (!response.ok) {
                console.log('Login failed')
                throw new Error(`Network response was not ok (${response.status})`);
            }
            return response.json();
        })
        .then(jsonres => {
            console.log(jsonres);
            //store the id, if found, in the sessionStorage
            //sessionStorage.setItem('user', JSON.stringify({ res }));
            //console.log(sessionStorage.user);

            location.href = "welcomeuser.html";
        })
        .catch(err => console.log(`There was an error ${err}`));
});