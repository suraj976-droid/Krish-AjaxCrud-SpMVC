$(document).ready(function () {
    fetchProducts();
});

$("#btnmodal").click(function () {
    $("#submitbtn").show();
    $("#updbtn").hide();
    $("#exampleModalLabel").text("Add Product");
    $("#exampleModal").modal('show');
});

$("#submitbtn").click(function () {
    //var obj = {
    //    pname: $("#Pname").val(),
    //    pcat: $("#Pcat").val(),
    //    price:$("#Price").val()
    //}

    var obj = $("#myform").serialize();

    $.ajax({
        url: '/Ajax/AddProduct',
        type: 'Post',
        dataType: 'json',
        data: obj,
        contentType: 'Application/x-www-form-urlencoded;charset=utf-8',
        success: function () {
            alert("Product Added Successfully");
            fetchProducts();
            $("#exampleModal").modal('hide');
        },
        error: function () {
            alert("Something went wrong");
        }
    });
});

function fetchProducts()
{
    $.ajax({
        url: '/Ajax/FetchProducts',
        type: 'Get',
        dataType: 'json',
        contentType: 'Application/json;charset=utf-8',
        success: function (result,sta,xhr) {
            var obj = '';
            $.each(result, function (index, item) {
                obj += '<tr>';
                obj += '<td>' + item.pid + '</td>';
                obj += '<td>' + item.pname + '</td>';
                obj += '<td>' + item.pcat + '</td>';
                obj += '<td>' + item.price + '</td>';
                obj += '<td><a class="btn btn-sm btn-danger" onclick="DeleteProduct(' + item.pid + ')">Delete</a><a class="btn btn-sm btn-success" onclick="EditProduct(' + item.pid +')">Edit</a></td>';
                obj += '</tr>';
            });
            $("#mydata").html(obj);
        },

        error: function () {
            alert("Something wrong")
        }
    });
}

function EditProduct(id)
{
    $.ajax({
        url: '/Ajax/EditProduct?pid=' + id,
        type: 'Get',
        dataType: 'json',
        contentType: 'Application/json;charset=utf-8',
        success: function (res) {
            $("#exampleModal").modal('show');
            $("#submitbtn").hide();
            $("#updbtn").show();
            $("#exampleModalLabel").text("Update Product");
            $("#Pid").val(res.pid),
            $("#Pname").val(res.pname),
            $("#Pcat").val(res.pcat),
            $("#Price").val(res.price)
        },

        error: function () {

        }
    });
}

$("#updbtn").click(function () {
    var obj = $("#myform").serialize();

    $.ajax({
        url: '/Ajax/UpdateProduct',
        type: 'Post',
        dataType: 'json',
        data: obj,
        contentType: 'Application/x-www-form-urlencoded;charset=utf-8',
        success: function () {
            alert("Product Updated Successfully");
            fetchProducts();
            $("#exampleModal").modal('hide');

        },
        error: function () {
            alert("Something went wrong");
        }
    });
});

function DeleteProduct(id)
{
    if (confirm("Are you Sure?")) {
        $.ajax({
            url: '/Ajax/DelProd?pid=' + id,
            success: function () {
                alert("Deleted Successfully");
                fetchProducts();
            },
            error: function () {
                alert("Wrong");
            }
        });
    }
    else {
        alert("Thanks");
    }

    
}


$("#noentry").on('input', function () {
    var data = $("#noentry").val();
    $.ajax({
        url: '/Ajax/TakeProducts?mydata=' + data,
        type: 'Get',
        dataType: 'json',
        contentType: 'Application/json;charset=utf-8',
        success: function (result, sta, xhr) {
            var obj = '';
            $.each(result, function (index, item) {
                obj += '<tr>';
                obj += '<td>' + item.pid + '</td>';
                obj += '<td>' + item.pname + '</td>';
                obj += '<td>' + item.pcat + '</td>';
                obj += '<td>' + item.price + '</td>';
                obj += '<td><a class="btn btn-sm btn-danger" onclick="DeleteProduct(' + item.pid + ')">Delete</a></td>';
                obj += '</tr>';
            });
            $("#mydata").html(obj);
        },

        error: function () {
            alert("Something wrong")
        }
    });

});


    $("#txt").on('input', function () {

        var data = $("#txt").val();
        $.ajax({
            url: '/Ajax/SearchProducts?mydata=' + data,
            type: 'Get',
            dataType: 'json',
            contentType: 'Application/json;charset=utf-8',
            success: function (result, sta, xhr) {
                var obj = '';
                $.each(result, function (index, item) {
                    obj += '<tr>';
                    obj += '<td>' + item.pid + '</td>';
                    obj += '<td>' + item.pname + '</td>';
                    obj += '<td>' + item.pcat + '</td>';
                    obj += '<td>' + item.price + '</td>';
                    obj += '<td><a class="btn btn-sm btn-danger" onclick="DeleteProduct(' + item.pid + ')">Delete</a></td>';
                    obj += '</tr>';
                });
                $("#mydata").html(obj);
            },

            error: function () {
                alert("Something wrong")
            }
        });

    });