(function ($) {
    $(".shoppingcart a.icon.delete").on('click', function (e) {
        var $button = $(this);
        var $tr = $button.parents("tr:first");
        var $isRemoved = $("input[name$='IsRemoved']", $tr).val("true");
        var $form = $button.parents("form");

        $form.submit();
        e.preventDefault();
    });
})(jQuery)