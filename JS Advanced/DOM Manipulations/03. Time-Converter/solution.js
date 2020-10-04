function attachEventsListeners() {
    let daysInputField = document.getElementById('days');
    let daysButton = document.getElementById('daysBtn');
    let hoursInputField = document.getElementById('hours');
    let hoursButton = document.getElementById('hoursBtn');
    let minutesInputField = document.getElementById('minutes');
    let minutesButton = document.getElementById('minutesBtn');
    let secondsInputField = document.getElementById('seconds');
    let secondsButton = document.getElementById('secondsBtn');

    daysButton.addEventListener('click', convert);
    hoursButton.addEventListener('click', convert);
    minutesButton.addEventListener('click', convert);
    secondsButton.addEventListener('click', convert);
    
    function convert(e) {
        let clickedButton = e.target.id;
        if (clickedButton === 'daysBtn') {
            let days = Number(daysInputField.value);
            let hours = days * 24;
            let minutes = days * 1440;
            let seconds = days * 86400;
            hoursInputField.value = hours;
            minutesInputField.value = minutes;
            secondsInputField.value = seconds;
        } else if (clickedButton === 'hoursBtn') {
            let hours = Number(hoursInputField.value);
            let days = hours / 24;
            let minutes = hours * 60;
            let seconds = minutes * 60;
            daysInputField.value = days;
            minutesInputField.value = minutes;
            secondsInputField.value = seconds;
        }else if (clickedButton === 'minutesBtn') {
            let minutes = Number(minutesInputField.value);
            let hours = minutes /60;
            let seconds = minutes * 60;
            let days = hours / 24;
            hoursInputField.value = hours;
            secondsInputField.value = seconds;
            daysInputField.value = days;
        }else if (clickedButton === 'secondsBtn') {
            let seconds = Number(secondsInputField.value);
            let minutes = seconds/60;
            let hours = minutes/60;
            let days =  hours / 24;;
            daysInputField.value = days;
            minutesInputField.value = minutes;
            hoursInputField.value = hours;
        }

    }
}