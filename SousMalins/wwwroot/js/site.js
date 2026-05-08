// Table datatable
$(document).ready(function () {

    $('.datatable').each(function () {

        // évite double init
        if (!$.fn.DataTable.isDataTable(this)) {

            $(this).DataTable({
                language: {
                    search: "Rechercher :",
                    lengthMenu: "Afficher _MENU_ lignes",
                    info: "Page _PAGE_ sur _PAGES_",
                    paginate: {
                        previous: "Précédent",
                        next: "Suivant"
                    },
                    zeroRecords: "Aucun résultat trouvé"
                },
                pageLength: 10,
                responsive: true
            });

        }

    });

});