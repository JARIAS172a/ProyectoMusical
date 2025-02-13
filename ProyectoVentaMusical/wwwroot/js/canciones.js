var dataTable;
$(document).ready(function () {
    cargarDatatable();
});


function cargarDatatable() {
    dataTable = $("#tblSongs").DataTable({
        "ajax": {
            "url": "/Admin/canciones/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "codigoCancion", "width": "10%" },
            { "data": "codigoGenero", "width": "10%" },
            { "data": "codigoAlbum", "width": "10%" },
            { "data": "nombreCancion", "width": "15%" },
            {
                "data": "linkVideo",
                "render": function (data) {
                    if (!data) return "Sin enlace";

                    // Añade protocolo HTTPS si no está presente
                    const url = data.startsWith("http") ? data : `https://${data}`;

                    // Opcional: Acortar visualización del enlace
                    const displayText = data.replace("https://", "").replace("www.", "");

                    return `<a href="${url}" target="_blank" class="text-primary">${displayText}</a>`;
                },
                "width": "10%"
            },
            { "data": "precio", "width": "10%" },
            { "data": "cantidadDisponible", "width": "10%" },
            {
                "data": "fotoCancion",
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
                "data": "codigoCancion",
                "render": function (data) {
                    return `<div class="text-center">
                                <a href="/Admin/Canciones/Edit/${data}" class="btn btn-success text-white" style="cursor:pointer; width:140px;">
                                    <i class="far fa-edit"></i> Editar
                                </a>
                                &nbsp;
                                <a onclick=Delete("/Admin/Canciones/Delete/${data}") class="btn btn-danger text-white" style="cursor:pointer; width:140px;">
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

