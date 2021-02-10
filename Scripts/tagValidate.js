$(document).ready(function () {

    $(".form-control").change(function () {
        var Tag = $(this).attr("data-model");
        var Value = $(this).val();
        var ValidationFunction = $(this).attr("data-validation-function");
        validate(Tag, Value, ValidationFunction)
    });
});

function validate(Tag, Value, ValidationFunction) {

    var objData = new Object();
    objData = { Tag, Value, ValidationFunction };
    var arrobjData = [objData];
    
    $.ajax({
        method: 'POST',
        url: 'https://localhost:44381/api/Validation/',
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(arrobjData),
        success: function (data) {
            var ErrField = $("[data-model=" + Tag + "]");
            ErrField.siblings('small').html('');
            data.forEach((val) => {
                ErrField.html(`*${val.VError}`);
            })
        },
        error: function (err) {
            console.log(err);
        }
    });
}