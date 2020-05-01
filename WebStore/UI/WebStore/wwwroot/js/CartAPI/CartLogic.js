let Cart = {
    _properties: {
        getCartViewLink: "",
        addToCartLink: "",
        decrementLink: "",
        removeFromCartLink: "",
    },
    init: function (properties) {
        $.extend(Cart._properties, properties);
        Cart.initEvents();
    },
    initEvents: function () {
        $(".add-to-cart").click(Cart.addToCart);
        $(".cart_quantity_up").click(Cart.incremantItem);
        $(".cart_quantity_down").click(Cart.decrementItem);
        $(".cart_quantity_delete").click(Cart.removeFromCart);
        
    },
    addToCart: function (event) {
        event.preventDefault();

        let button = $(this);
        const id = button.data('id'); // data-id="..."

        console.log(`${Cart._properties.addToCartLink}/${id}`)
        $.get(url)
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
        let container = $('#cart-container');
        $.get(Cart._properties.getCartViewLink)
            .done(function (cartHtml) {
                container.html(cartHtml);
            })
            .fail(function () { console.log(`refreshCartView fail ${id}`) });
    },

    incremantItem: function (event) {
        event.preventDefault();

        let button = $(this);
        const id = button.data('id'); // data-id="..."
    },

    decrementItem: function (event) {
        event.preventDefault();

        let button = $(this);
        const id = button.data('id'); // data-id="..."
    },

    removeFromCart: function (event) {
        event.preventDefault();

        let button = $(this);
        const id = button.data('id'); // data-id="..."
    },
}