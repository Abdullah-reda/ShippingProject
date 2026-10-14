
(function ($) {
    if (!$.validator) {
        console.error("jQuery Validation is not loaded.");
        return;
    }

    $.validator.addMethod(
        "englishtext",
        function (value, element) {
            return this.optional(element) ||
                /^[A-Za-z0-9\s-]+$/.test(value);
        },
        "Enter English letters, numbers, spaces, or hyphens only."
    );

    if ($.validator.unobtrusive) {
        $.validator.unobtrusive.adapters.addBool("englishtext");
    }
})(jQuery);


(function ($) {
    $.validator.addMethod(
        "arabictext",
        function (value, element) {
            return this.optional(element) ||
                /^[\u0600-\u06FF\u0750-\u077F\u08A0-\u08FF\s]+$/.test(value);
        },
        "Please enter Arabic letters only."
    );

    $.validator.unobtrusive.adapters.addBool("arabictext");

})(jQuery);
