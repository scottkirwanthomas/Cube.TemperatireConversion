// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $("#btnSubmit").click(function (event) {
        event.preventDefault();
        $.ajax({
            url: 'https://localhost:7043/Home/Convert?' + $('form').serialize(),
            type: 'GET',
            error: function (xmlHttpRequest, errorText, thrownError) {
                $('#result').text('An error has occurred, please try again' );
            },
            success: function (data) {
                if (data.status == 'Success') {
                    $('#result').text(data.value);
                }
                else {
                    $('#result').text(data.message);
                }
            }
        });
        
    });
});

