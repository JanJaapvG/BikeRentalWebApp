var reservationsElement = document.getElementById("reservationsData");

function getCustomerReservations(id) {
    var xhttp = new XMLHttpRequest();

    xhttp.open("GET", "https://localhost:44380/api/Reservations/" + id, true);
    xhttp.responseType = "json";
    xhttp.send();

    xhttp.onload = function () {

        console.log(this.response);
        const customerReservations = xhttp.response;
        console.log(customerReservations);
        for (let i = 0; i < customerReservations.length; i++) {
            const obj = customerReservations[i];
            reservationsElement.innerHTML +=
                `<tr><td>${obj.Bike.Name}</td>
                    <td>${obj.PickupStore.Name}</td>
                    <td>${obj.DropoffStore.Name}</td>
                    <td>${obj.Start}</td>
                    <td>${obj.End}</td>
                    <td>${obj.Bike.DailyRate}</td>
                    <td>${obj.Bike.HourRate}</td></tr>`
        }
    }
}