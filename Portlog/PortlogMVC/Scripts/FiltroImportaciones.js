console.log("ASFSAFASD");



$("#selectFiltro").change(function () {
    $(".f").val("");//vaciamos todos los input

    $(".filtros").hide(); //escondemos todas las de clase filtros


    if ($("#div" + $("#selectFiltro").val() != "Todas")){

        $("#div" + $("#selectFiltro").val()).show(); //mostramos el div con el filtro que queremos usar
    }


    if ($("#selectFiltro").val() == "fechaMenor") {

        $("#txtFechaMenor").val("true");
        $(".linkDepo").show();
    }
    else {
        $(".linkDepo").hide();
    }
   
});

$(".linkDepo").hide();






