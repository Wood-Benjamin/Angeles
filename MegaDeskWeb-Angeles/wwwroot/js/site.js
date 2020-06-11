// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

$(document).ready(function () {
    $("#customCombobox1").click(function () {
        //Get ul tag
        var dropDwn = $(this).next();
        //Show Dropdown
        if (dropDwn.is(":visible"))
            dropDwn.hide();
        else
            dropDwn.show();
    })

});

//Dropdown element click
$("#ulcustomCombobox1 li").click(function () {
    //Get div tag
    var cmbBox = $(this).parent().prev();
    //Set div tag text/image
    cmbBox.html($(this).html());
    //alert selected element id
    alert("Selected Id:" + $(this).attr("id"));
    //Hide Dropdown
    $(this).parent().hide();
});


/*
//Hide Dropdown If User click outside
$(document).on('click', function (e) {
    var element, evt = e ? e : event;
    if (evt.srcElement)
        element = evt.srcElement;
    else if (evt.target)
        element = evt.target;
    //Hide if clicked outside
    if (element.className != "customCombobox") {
        $("ul.ulcustomCombobox").hide();
    }
});
*/