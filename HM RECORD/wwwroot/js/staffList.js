var dataTable;

$(document).ready(function () {
    loadDataTable();
}); 

function loadDataTable() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/staff",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "surname", "width": "20%" },
            { "data": "name", "width": "20%" },
            { "data": "gender", "width": "20%" },
            { "data": "phoneNo", "width": "20%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                        <a href="/StaffList/Upsert?id=${data}" class='btn btn-success text-white' style='cursor:pointer; width:70px;'>
                              Edit
                        </a>
                        &nbsp;
                        <a class='btn btn-danger text-white' style='cursor:pointer; width:70px;'
                              onClick=Delete('/api/staff?id='+${data})>
                              Delete
                        </a>
                        </div>`;
                }, "width": "40%"
            }
        ],
        "language": {
            "emptyTable": "no data found"
        },
        "width": "70%"
    });
}

function Delete(url) {
    swal({
        title: "Are you sure",
        text: "Once deleted, you will not be able to recover",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
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
        }
    });
}