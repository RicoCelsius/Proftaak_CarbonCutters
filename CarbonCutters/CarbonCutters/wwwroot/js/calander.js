var weekoffset = 0;
var formAmount = 0;

function loaddays() {
    const months = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
    var i = 0;
    var calander = document.getElementById("calander");
    while (calander.firstChild) {
        calander.removeChild(calander.lastChild);
    }
    var monthname = document.getElementById("month");
    var c = "";
    var name = "";
    Date.prototype.addDays = function (days) {
        var date = new Date(this.valueOf());
        date.setDate(date.getDate() + days);
        return date;
    }

    var date = new Date();
    var daynumber = date.getDay() - 1;
    date = date.addDays(weekoffset);
    monthname.innerHTML = months[date.getMonth()];

    while (i < 7) {
        date = new Date();
        daynumber = date.getDay() - 1 ;
        date = date.addDays(i + weekoffset - daynumber);
        daynumber = date.getDay() - 1;

        if (i % 2 == 0) {
            c = "dayEven"
        } else {
            c = "dayUneven"
        }

        switch (daynumber) {
            case 0:
                name = "Mo"
                break;
            case 1:
                name = "Tu"
                break;
            case 2:
                name = "We"
                break;
            case 3:
                name = "Th"
                break;
            case 4:
                name = "Fr"
                break;
            case 5:
                name = "Sa"
                break;
            case 6:
                name = "Su"
                break;
        }

        var day = document.createElement('div');
        day.innerHTML = date.getDate();

        var dayname = document.createElement('div');
        dayname.innerHTML = name;

        var text = document.createElement('div');
        text.setAttribute('class', 'dateText');

        text.appendChild(dayname);
        text.appendChild(day);

        var line = document.createElement('div');
        line.setAttribute('class', 'line');

        var div = document.createElement('div');
        div.setAttribute('class', c);
        var datestring = date.getFullYear() + '-' + (date.getMonth()+1) + '-' + date.getDate()
        div.setAttribute('id', datestring);

        div.appendChild(text);
        div.appendChild(line);

        calander.appendChild(div);
        i++;
    }
}

function updateWeek(i) {
    weekoffset += (i * 7);

    loaddays();
}

function MakeTrip(dateString, id, isDone) {
    console.log(dateString);
    var day = document.getElementById(dateString);
    console.log(day);
    var trip = document.createElement('div');

    if (isDone == "True") {
        trip.setAttribute('class', 'tripDone');
    } else {
        trip.setAttribute('class', 'tripNotDone');
    }

    trip.setAttribute('id', 'trip-' + id);
    console.log(trip);

    try {
        day.appendChild(trip);
    }
    catch {

    }
}

var tripSegmentCount = 0;

function MakeNewForm(value) {
    const originalTripSegmentContainer = document.getElementById('Original');
    tripSegmentCount += value;
    if (tripSegmentCount <= 1) {
        document.getElementById('removeForm').style.display = 'none';
    } else {
        document.getElementById('removeForm').style.display = 'block';
    }

    if (value === 1) {
        // Clone the original TripSegmentContainer and set its display to block
        const newTripSegmentContainer = originalTripSegmentContainer.cloneNode(true);
        newTripSegmentContainer.style.display = 'block';

        // Set the IDs for the new trip segment elements to make them unique
        newTripSegmentContainer.id = 'TripSegmentContainer' + tripSegmentCount;

        // Append the new trip segment container to the dumpContainer
        document.getElementById('dumpContainer').appendChild(newTripSegmentContainer);
    } else if (tripSegmentCount >= 1) {
        // Remove the last trip segment container from the dumpContainer
        document.getElementById('dumpContainer').lastElementChild.remove();
    }
}






function MakeTripSections(id, distance, starttime, endtime) {
    var trip = document.getElementById('trip-' + id);

    var tripSegment = document.createElement('div');
    tripSegment.setAttribute('class', 'tripSegment');

    var dis = document.createElement('div');
    dis.innerHTML = distance + " km";

    var tim = document.createElement('div');
    tim.innerHTML = starttime + ' - ' + endtime;

    tripSegment.appendChild(tim);
    tripSegment.appendChild(dis);

    trip.appendChild(tripSegment);
}

function ChangeInput(transportType, id) {
    console.log(transportType);

    var parent = document.getElementById(id);

    var car = parent.getElementById('CarOptions');
    var noEmission = parent.getElementById('NoEmissionOptions');
    var PublicTransport = parent.getElementById('PublicTransportOptions');

    car.setAttribute('class', 'optionHidden');
    noEmission.setAttribute('class', 'optionHidden');
    PublicTransport.setAttribute('class', 'optionHidden');

    switch (transportType) {
        case 'Car':
            car.setAttribute('class', 'optionShow');
            break;
        case 'NoEmission':
            noEmission.setAttribute('class', 'optionShow');
            break;
        case 'PublicTransport':
            PublicTransport.setAttribute('class', 'optionShow');
            break;
        default:
            break;
    }
}
