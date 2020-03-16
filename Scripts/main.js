$('input').on('keydown', function (e) {
    if (e.keyCode == 9) {
        $(this).focus();
        e.preventDefault();
    }
});