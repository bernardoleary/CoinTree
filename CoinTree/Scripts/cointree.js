function autoLoad() {
    $.ajax({
        type: 'GET',
        url: window.location.protocol + '//' + window.location.hostname + ':' + location.port + '/api/price',
        success: function (data) {
            $('#currentPrice').html('Asking price: ' + data.current.ask);
            $('#percentageChange').html('Percentage update: ' + data.diff.percentagediffask);
            priceData = data;
            customerPriceUpdate();
        }
    });
}
function customerPriceUpdate() {
    $('#customerPriceStatus').html(
        parseFloat(priceData.current.ask) >
            parseFloat($('#customerPrice').val()) ? 'Price is too low sorry.' : '');
}
autoLoad();
setInterval(autoLoad, 30000);
var priceData;