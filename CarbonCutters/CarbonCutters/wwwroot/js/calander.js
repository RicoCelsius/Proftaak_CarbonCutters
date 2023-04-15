var weekoffset = 0;

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

function loadTrip(dateString, distance, starttime, endtime) {
    try {
        var day = document.getElementById(dateString);

        var dis = document.createElement('div');
        dis.innerHTML = distance + " km";

        var tim = document.createElement('div');
        tim.innerHTML = starttime + " - " + endtime;

        var trip = document.createElement('div');
        trip.setAttribute('class', 'tripDone');
        trip.appendChild(tim);
        trip.appendChild(dis);

        day.appendChild(trip);
    } catch {

    }
}