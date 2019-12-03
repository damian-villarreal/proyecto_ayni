$(document).ready(function () {
    $("form").submit(function () {
        $(".modal").modal("hide")
        $("#myModal").modal();
    });
    $(".btnTransaccion").click(function () {
        $(".modal").modal("hide")
        $("#myModal").modal();
    });
});