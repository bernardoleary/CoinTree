function auto_load(){
    $.ajax({
        type: 'GET',
        url: window.location.protocol + '//' + window.location.hostname + ':' + location.port + '/api/price',
        success: function (data) { $('#price').html(data.ask) }
    });
}
auto_load();
setInterval(auto_load,30000);