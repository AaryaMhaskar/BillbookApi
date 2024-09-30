$(document).ready(function () {
    GetParties();
    GetPartiesForBillWisePro();
    GetStatus();
});

function GetParties() {
    $.ajax({
        url: '/SalesSummary/FetchParty', // Call the new action for data
        type: 'GET',
        dataType: 'json',
        success: function (result, status, xhr) {
            var options = '<option value="">Select Party</option>';
            $.each(result, function (index, item) {
                options += "<option value='" + item.id + "'>" + item.partyName + "</option>";
            });
            $("#FetchParty").html(options); // Populate the dropdown
        },
        error: function (xhr, status, error) {
            console.error("Error fetching data: ", error);
            alert("Failed to load subjects: " + xhr.status + " - " + error);
        }
    });
}

$('#FetchParty').change(function () {
    var partyId = $(this).val();
    $.ajax({
        url: '/SalesSummary/SalesSummaryByPartyId/',
        type: 'GET',
        data: { partyId: partyId },
        success: function (data) {
            $('#salesSummaryBody').empty(); // Clear existing data
            if (data.length > 0) {
                $.each(data, function (index, item) {
                    var row = '<tr>' +
                        '<td>' + item.invoiceDate + '</td>' +
                        '<td>' + item.invoiceId + '</td>' +
                        '<td>' + item.partyName + '</td>' +
                        '<td>' + item.dueDate + '</td>' +
                        '<td>' + item.amount + '</td>' +
                        '<td>' + item.invoiceStatus + '</td>' +
                        '</tr>';
                    $('#salesSummaryBody').append(row);
                });
            } else {
                $('#salesSummaryBody').append('<tr><td colspan="6">No records found.</td></tr>');
            }
        },
        error: function () {
            alert('Error fetching data.');
        }
    });
});


function GetPartiesForBillWisePro() {
    $.ajax({
        url: '/BillWiseProfit/FetchParty', // Call the new action for data
        type: 'GET',
        dataType: 'json',
        success: function (result) {
            var options = '<option value="">Select Party</option>';
            $.each(result, function (index, item) {
                options += "<option value='" + item.id + "'>" + item.partyName + "</option>";
            });
            $("#FetchBill").html(options); // Populate the dropdown
        },
        error: function (xhr, status, error) {
            console.error("Error fetching data: ", error);
            alert("Failed to load parties: " + xhr.status + " - " + error);
        }
    });
}

$('#FetchBill').change(function () {
    var partyId = $(this).val();
    $.ajax({
        url: '/BillWiseProfit/BillWiseByPartyId/',
        type: 'GET',
        data: { partyId: partyId },
        success: function (data) {
            console.log(data);
            $('#salesSummaryBody').empty(); // Clear existing data
            if (data.length > 0) {
                $.each(data, function (index, item) {
                    var row = '<tr>' +
                        '<td>' + item.billTo + '</td>' +
                        '<td>' + item.inventoryItemid + '</td>' +
                        '<td>' + item.partyName + '</td>' +
                        '<td>' + item.invoicedate + '</td>' +
                        '<td>' + item.amount + '</td>' +
                        '<td>' + item.salesprice.toFixed(2) + '</td>' + 
                        '<td>' + item.purchaseprice.toFixed(2) + '</td>' + 
                        '<td>' + item.profit.toFixed(2) + '</td>' + 
                        '</tr>';
                    $('#salesSummaryBody').append(row);
                });
            } else {
                $('#salesSummaryBody').append('<tr><td colspan="6">No records found.</td></tr>');
            }
        },
        error: function () {
            alert('Error fetching data.');
        }
    });
});

function GetStatus() {
    $.ajax({
        url: '/SalesSummary/FetchStatus', // Call the new action for data
        type: 'GET',
        dataType: 'json',
        success: function (result, status, xhr) {
            var options = '<option value="">Select Status</option>';
            $.each(result, function (index, item) {
                options += "<option value='" + item.invoiceStatus + "'>" + item.invoiceStatus + "</option>";
            });
            $("#FetchStatus").html(options); // Populate the dropdown
        },
        error: function (xhr, status, error) {
            console.error("Error fetching data: ", error);
            alert("Failed to load subjects: " + xhr.status + " - " + error);
        }
    });
}

$('#FetchStatus').change(function () {
    var Status = $('#FetchStatus').val();
    console.log(Status);
    $.ajax({
        url: '/SalesSummary/SalesSummaryByStatus/',
        type: 'GET',
        data: { Status: Status },
        success: function (data) {
            $('#salesSummaryBody').empty(); // Clear existing data
            if (data.length > 0) {
                $.each(data, function (index, item) {
                    var row = '<tr>' +
                        '<td>' + item.invoiceDate + '</td>' +
                        '<td>' + item.invoiceId + '</td>' +
                        '<td>' + item.partyName + '</td>' +
                        '<td>' + item.dueDate + '</td>' +
                        '<td>' + item.amount + '</td>' +
                        '<td>' + item.invoiceStatus + '</td>' +
                        '</tr>';
                    $('#salesSummaryBody').append(row);
                });
            } else {
                $('#salesSummaryBody').append('<tr><td colspan="6">No records found.</td></tr>');
            }
        },
        error: function () {
            alert('Error fetching data.');
        }
    });
});
