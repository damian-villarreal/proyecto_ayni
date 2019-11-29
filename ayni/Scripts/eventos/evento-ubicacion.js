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
            url: '/Evento/CargaJsonLocalidad',
            contentType: 'application/json',
            method: 'POST',
            data: JSON.stringify({ name: selector }),
            success: function (response) {
                var jsonResponser = JSON.parse(response);
                var slcLocalidad = $('.ubicacionDinamica');
                slcLocalidad.html('');
                slcLocalidad.removeAttr('disabled');
                slcLocalidad.attr('selected', false);
                slcLocalidad.append("<option value='' selected='' disabled=''>Seleccionar</option>\ ");

                jsonResponser.forEach(function (m) {
                    slcLocalidad.append("<option value='"+m.nombre+", "+m.provincia.nombre+"' > " + m.nombre + " </option>\ ");
                    console.log(m.nombre);
                })
                $("#wait").css("display", "none");
            }
        });
    });
}); 

