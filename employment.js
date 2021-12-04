// JavaScript source code
$(document).ready(function () {

    function getData(pathName) {
        return $.ajax({
            type: 'get',
            url: 'http://solace.ist.rit.edu/~plgics/proxy.php',
            dataType: 'json',
            data: pathName,
            cache: false,
            async: true
        })
    }

    let d1 = getData({ path: '/employment/' });



    $.when(d1).done(function (minorData) {
        console.log(minorData);
        console.log(minorData[0]);

        getData({ path: '/employment/' }).done(function (output, status, jqXHR) {
            console.log(status);
            console.log(jqXHR);
            console.log(output);
        });
    });
});