function auto_load(){
    $.ajax({
        type: 'GET',
        url: window.location.protocol + '//' + window.location.hostname + ':' + location.port + '/api/price',
        success: function (data) {
            $('#currentPrice').html(data.current.ask);
            $('#percentageChange').html(data.diff.percentagediffask);
        }
    });
}
$('#customerPrice').change(function (event) {
    $('#customerPriceStatus').html(
        parseFloat(priceData.current.ask) >
        parseFloat($('#customerPriceStatus').html) ? 'price too low' : '');
});
auto_load();
setInterval(auto_load, 30000);