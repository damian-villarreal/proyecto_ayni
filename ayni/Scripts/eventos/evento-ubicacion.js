$(document).ready(function () {

    //PROVINCIAS
    //console.log("entro a lugares.js");
    //$.ajax({
    //    url: '/Evento/CargaJsonProvincia',
    //    contentType: 'application/json',
    //    method: 'POST',
    //    //data: JSON.stringify({ name: selector }),
    //    success: function (response) {
    //        var jsonResponser = JSON.parse(response);
    //        var slcProvi = $('#Provincia');
    //        slcProvi.html('');
    //        slcProvi.append("<option value='' selected='' disabled=''>Seleccionar</option>\ ");
    //        jsonResponser.forEach(function (p) {
    //            slcProvi.append('<option value=' + p.id + ' >' + p.nombre + '</option>\ ');
    //            console.log(p.nombre);
    //        })
    //    }
    //});


    //MUNICIPIOS
    console.log("entro a dISTRITOS.js");
    $('#Provincia').on('change', function () {
        var selector = $(this).val();
        $("#wait").css("display", "block");
        $.ajax({
            url: '/Evento/CargaJsonMunicipio',
            contentType: 'application/json',
            method: 'POST',
            data: JSON.stringify({ name: selector }),
            success: function (response) {
                var jsonResponser = JSON.parse(response);
                var slcMunicipio = $('#Municipio');
                slcMunicipio.html('');
                slcMunicipio.removeAttr('disabled');
                slcMunicipio.attr('selected', false);
                slcMunicipio.append("<option value='' selected='' disabled=''>Seleccionar</option>\ ");

                jsonResponser.forEach(function (m) {
                    slcMunicipio.append("<option value='" + m.centroide.lat +", "+  m.centroide.lon + "' > "+ m.nombre +" </option>\ ");
                    console.log(m.nombre);
                })
                $("#wait").css("display", "none");
            }
        });
    });
}); 

