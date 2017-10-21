function auto_load(){
    $.ajax({
        type: 'GET',
        url: window.location.protocol + '//' + window.location.hostname + ':' + location.port + '/api/price',
        success: function (data) {
            $('#currentPrice').html(data.current.ask)
            $('#previousPrice').html(data.previous.ask)
        }
    });
}
auto_load();
setInterval(auto_load,30000);