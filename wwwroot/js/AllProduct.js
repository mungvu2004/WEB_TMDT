document.addEventListener("DOMContentLoaded", function () {
    var curren = 'Tshirt'; // Đặt loại sản phẩm mặc định là 'Tshirt'
    var product = document.querySelectorAll('.list_shirt');
    var navbar = document.querySelectorAll('.navbar_li');

    console.log('Products:', product);
    console.log('Navbar items:', navbar);

    function showProduct(type) {
        console.log('showProduct called with type:', type);
        if (curren === type) {
            return curren;
        }
        product.forEach(elm => {
            if (elm.classList.contains(type)) {
                elm.classList.remove('display');
                elm.classList.add('block');
            } else {
                elm.classList.add('display');
                elm.classList.remove('block');
            }
        });
        curren = type;
    }

    // Hiển thị sản phẩm mặc định
    showProduct(curren);

    navbar.forEach(item => {
        item.addEventListener('click', function () {
            var type = item.getAttribute('data-type');
            console.log('Navbar item clicked:', type);
            showProduct(type);
        });
    });
});
