// Clone in 2 steps
$(".btn-clone").click(function () {

    var tr = $("#" + $(this).attr("data-rnd") + "-tr").clone(true, true);
    //e.preventDefault();
    $('#table-edit-product').append(tr.clone(true, true));

    // totaly 18 elements, and we need to start renaming clone - starting from 9th element
    var rnd = $(this).attr("data-rnd");
    var totalIndex = $('[id^="' + rnd + '"]').length;
    var timePrefixNow = $.now();
    // find 18 elements
    $('[id^="' + rnd + '"]').each(function (index) {
        if (index >= totalIndex / 2) {
            // new random id
            $(this).attr("id", timePrefixNow + $(this).attr("id"));
        }
        //console.log(index + ": " + $(this).attr("id"));
    });

    // find amd change clone's data-rnd
    var totalIndex2 = $('[data-rnd^="' + rnd + '"]').length;
    $('[data-rnd^="' + rnd + '"]').each(function (index) {
        if (index >= totalIndex2 / 2) {
            // new random id
            $(this).attr("data-rnd", timePrefixNow + $(this).attr("data-rnd"));
        }
    });

    // find and change record ID
    var cloneId = timePrefixNow + rnd + '-Id';
    $('[id^="' + cloneId + '"]').each(function (index) {
        $('[id^="' + cloneId + '"]').val('');
    });

});
