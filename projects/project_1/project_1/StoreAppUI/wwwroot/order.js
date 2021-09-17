const custId = JSON.parse(sessionStorage.getItem('user')).customerId;
const prodId = JSON.parse(sessionStorage.getItem('product'));
const locId = JSON.parse(sessionStorage.getItem('store'));
const prodPrice = JSON.parse(sessionStorage.getItem('price'));
let date = new Date();


const orderData = { CustomerId: custId, ProductId: prodId, StoreId: locId, OrderDate: date.toJSON(), ProductQuantity: 1, CompletionTime: 1, TotalAmount: prodPrice }

//POST fetch request
fetch(`order/placeorder`, {
    method: 'POST',
    headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json'
    },
    body: JSON.stringify(orderData)
})
    .then(response => {
        if (!response.ok) {
            console.log('Purchase failed');
            throw new Error(`Network response was not ok (${response.status})`);
        }
        return response.json();
    })
    .then(jsonres => {
        console.log(jsonres);
        const o = document.querySelector('.order');
        o.innerHTML += `<p>Charge: $${prodPrice}</p><br><p>Please confirm</p>`;
    })
    .catch(err => console.log(`There was an error ${err}`));

function Confirm() {
    location.href = "thankyou.html";
}