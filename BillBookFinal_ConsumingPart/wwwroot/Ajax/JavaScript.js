$(document).ready(function () {
    GetParties();
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