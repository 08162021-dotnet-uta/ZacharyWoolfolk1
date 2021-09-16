//Call IIFE for list of all customers
(function () {
    fetch("customer/Customerlist")
        .then(res => res.json())
        .then(data => {
            console.log(data)
            const loc = document.querySelector('.listofcustomers');
            for (let x = 0; x < data.length; x++) {
                loc.innerHTML += `<p>The customer is ${data[x].firstName} ${data[x].lastName}.</p>`;
            }
        });
    })();