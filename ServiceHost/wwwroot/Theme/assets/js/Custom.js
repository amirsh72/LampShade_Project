﻿const cookieName = "cart-items"
function addToCart(id, name, price, picture) {
    let products = $.cookie(cookieName);
    if (products === undefined) {
        products = [];
    } else {
        products = JSON.parse(products);
    }
    const count = $("#productCount").val();
    const currentProduct = products.find(x => x.id === id);
    if (currentProduct !== undefined) {
        products.find(x => x.id === id).count = parseInt(currentProduct.count) + parseInt(count);
    } else {
        const product = {
            id,
            name,
          unitPrice:  price,
            picture,
            count
        }
        products.push(product)
    }
    $.cookie(cookieName, JSON.stringify(products), { expires: 2, path: "/" });
    updateCart();
}

function updateCart() {
    let products = $.cookie(cookieName);
    products = JSON.parse(products);
    $("#cart_items_count").text(products.length);
    const cartItemsWrapper = $("#cart_items_wrapper");
    cartItemsWrapper.html('');
    products.forEach(x => {
        const product = `<div class="single-cart-item">
                        <a href="javascript:void(0)" class="remove-icon" onclick="removeFromCart('${x.id}'),window.location.reload()">
                        <i class="ion-android-close"></i>
                        </a>
                        <div class="image">
                        <a href="single-product.html">
                        <img src="/productpictures/${x.picture}"
                         class="img-fluid" alt="">
                        </a>
                        </div>
                        <div class="content">
                        <p class="product-title">
                        <a href="single-product.html">محصول:${x.name}</a>
                        </p>
                        <p class="count"><span>1 x </span> تعداد:${x.count}</p>
                        <p class="count"><span>1 x </span> قیمت واحد:${x.unitPrice}</p>
                        </div>
                        </div>`;
        cartItemsWrapper.append(product);
    });
}

    //function removeFromCart(id) {
    //    let products = $.cookie(cookieName);
    //    products = JSON.parse(products);
    //    const itemToRemove = products.findIndex(x => x.id === id);
    //    products.splice(itemToRemove, 1);
    //    $.cookie(cookieName, JSON.stringify(products), { expires: 2, path: "/" });
    //    updateCart();

    //}

function changeCartItemCount(id, total, count) {
    var products = $.cookie(cookieName);
    products = JSON.parse(products);
    debugger;
    const productIndex = products.findIndex(x => x.id == id);
    products[productIndex].count = count;
    const product = products[productIndex];
    const newprice = parseInt(product.unitPrice) * parseInt(count);
    $(`#${total.Id}`).text(newprice);
    $.cookie(cookieName, JSON.stringify(products), { expires: 2, path: "/" });
    updateCart();

    const settings = {
        "url": "https://localhost:5001/api/inventory",
        "method": "POST",
        "timeout": 0,
        "headers": {
            "Content-Type": "application/json"
        },
        "data": JSON.stringify({ "productId": id, "count": count })
    };

    $.ajax(settings).done(function (data) {
        if (data.isStock == false) {
            const warningsDiv = $('#productStockWarnings');
            if ($(`#${id}`).length == 0) {
                warningsDiv.append(`
                    <div class="alert alert-warning" id="${id}">
                        <i class="fa fa-warning"></i> کالای
                        <strong>${data.productName}</strong>
                        در انبار کمتر از تعداد درخواستی موجود است.
                    </div>
                `);
            }
        } else {
            if ($(`#${id}`).length > 0) {
                $(`#${id}`).remove();
            }
        }
    });
}

