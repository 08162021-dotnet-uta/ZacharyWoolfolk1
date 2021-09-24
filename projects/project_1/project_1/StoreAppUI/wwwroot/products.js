(function () {
    console.log(sessionStorage.getItem('store'));
    fetch(`product/productlistings/${sessionStorage.getItem('store')}`)
        .then(res => res.json())
        .then(data => {
            console.log(data);
            const loc = document.querySelector('.listofproducts');
            for (let x = 0; x < data.length; x++) {
                loc.innerHTML += (`<a href="#" onclick="MakeOrder(${data[x].productId}); sessionStorage.setItem('price', JSON.stringify(${data[x].productPrice}))">${data[x].productName} - ${data[x].productDescription}..........$${data[x].productPrice}  |  ${data[x].inventory} copies available at this location (${data[x].quantityAvailable} total copies available)</a><br>`);
            }
      });
})();

function MakeOrder (id) {
    console.log(id)
    sessionStorage.setItem('product', id);
    location.href = "order.html";
}