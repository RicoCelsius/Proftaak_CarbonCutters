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
    console.log('making trip');
    var day = document.getElementById(dateString);

    var trip = document.createElement('div');

    console.log(isDone);
    if (isDone == "True") {
        trip.setAttribute('class', 'tripDone');
    } else {
        trip.setAttribute('class', 'tripNotDone');
    }

    trip.setAttribute('id', 'trip-' + id);

    day.appendChild(trip);
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

function MakeNewForm(i) {
    var form = document.getElementById('Original');
    var newform = form.cloneNode(true);
    var selecttype = newform.getElementBy('input');

    formAmount += i;
    console.log(formAmount);
    newform.setAttribute('id', 'clone' + formAmount)
    newform.setAttribute('style', 'display: flex')
    selecttype.setAttribute('onchange', 'ChangeInput(this.value, clone' + formAmount + ')')
    var dump = document.getElementById('dumpContainer');

    if (i == 1) {
        dump.appendChild(newform);
    }
    else {
        dump.removeChild(dump.lastChild)
    }
}