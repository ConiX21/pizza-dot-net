
$('#fileupload').fileupload({
    url: '/Utils/UploadFile.ashx?upload=start',
    add: function (e, data) {
        $('#progressbar').show();
        $('#files').removeClass("flash").hide();
        $('#progress .progress-bar').css('width', '0%');
        data.submit();
    },
    progress: function (e, data) {
        var progress = parseInt(data.loaded / data.total * 100, 10);
        $('#progress .progress-bar').css('width', progress + '%');
        $('#progress .progress-bar').text(progress + '%');
    },
    success: function (response, status) {
        $('#files').addClass("flash").show();
        $('#files strong').text(response);
    },
    error: function (error) {
        $('#progress').hide();
        $('#progress div').css('width', '0%');
        console.log('error', error);
    }
});