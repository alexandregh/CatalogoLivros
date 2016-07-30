$(document).ready(function ()
{
    $("#txtISBN").keypress(verificaNumero);
    $('#txtISBN').mask('999-9-99999-999-9');
});


function verificaNumero(e)
{
    if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57))
    {
        return false;
    }
}