console.log("ASFSAFASD");
$(".linkDepo").hide();


$("#selectFiltro").change(function () {
    $(".f").val("");//vaciamos todos los input

    $(".filtros").hide(); //escondemos todas las de clase filtros


    if ($("#div" + $("#selectFiltro").val() != "Todas")){

        $("#div" + $("#selectFiltro").val()).show(); //mostramos el div con el filtro que queremos usar
    }


    
    
   
});


if ($("#depoLink").val() == "si") {
    $(".linkDepo").show();
}
else {
    $(".linkDepo").hide();
}


$("#btnSelect").click(function () {

    if ($("#selectFiltro").val() == "fechaMenor") {

        $("#txtFechaMenor").val("true");
        $(".linkDepo").show();
    }
})

