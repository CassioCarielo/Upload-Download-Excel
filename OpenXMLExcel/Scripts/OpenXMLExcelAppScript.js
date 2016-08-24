$(document).ready(function () {
    $('#btnSubmit').click(function () {
        alert('1');
        var fileName = $('[name="excelFile"]').val().trim();
        var pos = fileName.lastIndexOf('.');
        var extension = (pos <= 0) ? '' : fileName.substring(pos);
        if (extension != '.xlsx') {
            alert('Please browse a correct excel file to upload');
            return;
        }
        $('form').submit();
    });
});
