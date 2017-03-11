$(document).ready(function() {

    var customerId = 0;
    var formMode = "";
    var selectedRow;

    var table = $("#customers").DataTable({
        ajax: {
            url: "/api/customers",
            dataSrc: ""
        },
        columns: [
            { data: "firstName" },
            { data: "lastName" },
            { data: "email" },
            { data: "phoneNumber" },
            {
                data: "id",
                "orderable": false,
                render: function(data) {
                    return "<button class='btn btn-link'" +
                        " data-toggle='modal' data-target='#customerFormModalDiv'" +
                        " data-form-mode='Edit' data-customer-id=" +
                        data +
                        "><i class='fa fa-lg fa-pencil-square-o' aria-hidden='true'></i>" +
                        "</button>" +
                        "<button class='btn btn-link'" +
                        "  data-toggle='modal' data-target='#dialogModalDiv'" +
                        " data-form-mode='Delete' data-customer-id=" +
                        data +
                        "><i class='fa fa-lg fa-trash-o' aria-hidden='true'></i>" +
                        "</button>";
                }
            },
            { data: "id" }
        ]
    });

    function clearForm() {
        $("#id").val("");
        $("#firstNameText").val("");
        $("#lastNameText").val("");
        $("#phoneNumbeText").val("");
        $("#emailText").val("");
        customerId = 0;
    }

    function fillFormWithCustomerData(id) {
        $.ajax({
            dataSrc: "",
            url: "/api/customers/" + id,
            method: "GET"

        }).done(function(json) {
            $("#idText").val(json.id);
            $("#firstNameText").val(json.firstName);
            $("#lastNameText").val(json.lastName);
            $("#phoneNumbeText").val(json.phoneNumber);
            $("#emailText").val(json.email);

        }).fail(function() {
            alert("Error trying to load data for customer!");
            console.log("Error: " + errorThrown);
            console.log("Status: " + status);
            console.dir(xhr);
        });
    };

    $("#customerFormModalDiv").on("show.bs.modal",
        function(event) {
            // Read data from related button (Create/Edit mode Customer Id)
            var button = $(event.relatedTarget);
            customerId = button.data("customer-id");
            formMode = button.data("form-mode");

            if (formMode === "Create") {
                // Set form for Create state (for creating new Customer)
                $("#custotomerFormTitleLabel").text("New Customer");
                clearForm();

            } else if (formMode === "Edit") {
                // Set form for Edit state (for editing existing Customer)
                $("#custotomerFormTitleLabel").text("Edit Customer");
                fillFormWithCustomerData(customerId);

            } else {
                console.error("=== Error: invalid data-form-mode");
            };
        });
    $("#customerFormModalDiv").on("hide.bs.modal",
        function() {
            validator.resetForm();
        });

    function createCutomerObject() {
        var customer = {
            firstName: $("#firstNameText").val(),
            lastName: $("#lastNameText").val(),
            phoneNumber: $("#phoneNumbeText").val(),
            email: $("#emailText").val()
        };
        if (formMode === "Edit") {
            customer.id = $("#idText").val();
        }
        return customer;
    };

    var validator = $("#customerForm").validate({
        submitHandler: function() {

            createCutomerObject();

            if (formMode === "Create") {
                createCustomer();
            } else if (formMode === "Edit") {
                updateCustomer();
            } else {
                console.log("Invalid formMode");
            }
            return false;
        }
    });

    function finalizeSuccessfulUpdate(message) {
        $("#customerFormModalDiv").modal("hide");
        table.ajax.reload(function() {
            toastr.success(message);
        });

    };

    function createCustomer() {
        $.ajax({
                url: "/api/customers",
                method: "post",
                data: createCutomerObject()
            })
            .done(function() {
                finalizeSuccessfulUpdate("New Customer Created");
            })
            .fail(function() {
                toastr.error("=== Error creating customer");
                console.log("Error: " + errorThrown);
                console.log("Status: " + status);
                console.dir(xhr);
            });
    };

    function updateCustomer() {
        $.ajax({
                url: "/api/customers/" + customerId,
                method: "put",
                data: createCutomerObject()
            })
            .done(function() {
                finalizeSuccessfulUpdate("New Customer Updated");
            })
            .fail(function() {
                toastr.error("=== Error updating customer");
                console.log("Error: " + errorThrown);
                console.log("Status: " + status);
                console.dir(xhr);
            });
    };

    function deleteCustomer() {
        if (customerId > 0 && formMode === "Delete") {
            $.ajax({
                    url: "/api/customers/" + customerId,
                    method: "delete"
                })
                .done(function() {
                    finalizeSuccessfulDelete("Customer Deleted");
                })
                .fail(function() {
                    toastr.error("=== Error deleting customer");
                    console.log("Error: " + errorThrown);
                    console.log("Status: " + status);
                    console.dir(xhr);
                });
        }
    };

    function finalizeSuccessfulDelete(message) {
        $("#dialogModalDiv").modal("hide");
        console.log(message);
        selectedRow.remove().draw();
        table.ajax.reload(function () {
                toastr.success(message);
            });

    };

    $("#dialogModalDiv").on("show.bs.modal",
        function(event) {
            // Read data from related button (Create/Edit/Delete mode Customer Id
            var button = $(event.relatedTarget);
            customerId = button.data("customer-id");
            formMode = button.data("form-mode");
            selectedRow = table.row(button.parents("tr"));


            if (formMode === "Delete" && customerId > 0) {
                // Set dialog for Delete state
                $("#dialogMessage").text("Are you shure you want to delete the customer with Id=" + customerId + "?");
                $("#dialogOkButtonCaption").text("Delete");
                $("#dialogOkButton").off("click");
                $("#dialogOkButton").click(deleteCustomer);
                //fillFormWithCustomerData(customerName);

            } else {
                console.error("=== Error: invalid data-form-mode");
            };
        });

});