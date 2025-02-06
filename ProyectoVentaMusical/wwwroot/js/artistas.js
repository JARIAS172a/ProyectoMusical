var dataTable;
$(document).ready(function () {
    cargarDatatable();
});


function cargarDatatable() {
    dataTable = $("#tblArtistas").DataTable({
        "ajax": {
            "url": "/Admin/artistas/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "codigoArtista", "width": "5%" },
            { "data": "nombreArtistico", "width": "15%" },
            { "data": "fechaNacimiento", "width": "15%" },
            { "data": "nombreReal", "width": "15%" },
            { "data": "nacionalidad", "width": "15%" },
            {
                "data": "fotoArtista",
                "render": function (imagen) {
                    if (imagen) {
                        // Reemplaza las barras invertidas por normales y quita el ../
                        const rutaImagen = imagen.replace(/\\/g, "/");
                        return `<img src="${rutaImagen}" width="120px">`;
                    }
                    return "Sin imagen";
                }
            },
            {
                "data": "codigoArtista",
                "render": function (data) {
                    return `<div class="text-center">
                                <a href="/Admin/Artistas/Edit/${data}" class="btn btn-success text-white" style="cursor:pointer; width:140px;">
                                    <i class="far fa-edit"></i> Editar
                                </a>
                                &nbsp;
                                <a onclick=Delete("/Admin/Artistas/Delete/${data}") class="btn btn-danger text-white" style="cursor:pointer; width:140px;">
                                    <i class="far fa-trash-alt"></i> Borrar
                                </a>
                          </div>
                         `;
                }, "width": "25%"
            }
        ],
        "language": {
            "decimal": "",
            "emptyTable": "No hay registros",
            "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
            "infoEmpty": "Mostrando 0 to 0 of 0 Entradas",
            "infoFiltered": "(Filtrado de _MAX_ total entradas)",
            "infoPostFix": "",
            "thousands": ",",
            "lengthMenu": "Mostrar _MENU_ Entradas",
            "loadingRecords": "Cargando...",
            "processing": "Procesando...",
            "search": "Buscar:",
            "zeroRecords": "Sin resultados encontrados",
            "paginate": {
                "first": "Primero",
                "last": "Ultimo",
                "next": "Siguiente",
                "previous": "Anterior"
            }
        },
        "width": "100%"
    });
}



function Delete(url) {
    swal({
        title: "Esta seguro de borrar?",
        text: "Este contenido no se puede recuperar!",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Si, borrar!",
        closeOnconfirm: true
    }, function () {
        $.ajax({
            type: 'DELETE',
            url: url,
            success: function (data) {
                if (data.success) {
                    toastr.success(data.message);
                    dataTable.ajax.reload();
                }
                else {
                    toastr.error(data.message);
                }
            }
        });
    });
}

