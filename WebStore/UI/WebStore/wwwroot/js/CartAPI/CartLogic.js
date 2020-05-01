let Cart = {
    _properties: {
        getCartViewLink: "",
        addToCartLink: ""
    },
    init: function (properties) {
        $.extend(Cart._properties, properties);

        $(".add-to-cart").click(addToCart);
    },
    addToCart: function (event) {
        event.preventDefault();

        let button = $(this);
        const id = button.data('id'); // data-id="..."

        $.get(Cart._properties.addToCart + '/' + id)
            .done(function () {
                Cart.showToolTip(button);
                Cart.refreshCartView();
            })
            .fail(function () { console.log(`addToCart fail ${id}`) });
    },
    showToolTip: function (button) {
        button.tooltip({ title: 'Добавлено в корзину' }).tooltip('show');
        setTimeout(function () {
            button.tooltip('destroy');
        }, 500);
    },
    refreshCartView: function () {
        let container = $('#catr-container');
        $.get(Cart._properties.getCartViewLink)
            .done(function (cartHtml) {
                container.html(cartHtml);
            })
            .fail(function () { console.log(`refreshCartView fail ${id}`) });
    }
}