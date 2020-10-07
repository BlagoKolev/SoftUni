function stopwatch() {
    let start = document.getElementById('startBtn');
    let stop = document.getElementById('stopBtn');
    let display = document.getElementById('time');
    let seconds = 0;
    let minutes = 0;
    let t = null;

    start.addEventListener('click', function () {
        seconds = '00';
        let minutes = '00';
        display.textContent = `${minutes}:${seconds}`;
        start.disabled = true;
        stop.disabled = false;
        t = setInterval(TicTac, 1000);
    });

    stop.addEventListener('click', function () {
        clearInterval(t);
        start.disabled = false;
        stop.disabled = true;
    });

    function TicTac() {
        seconds++;

        if (seconds < 10) {
            seconds = '0' + seconds;
        }
        if (seconds >= 60) {
            minutes++;
            seconds = '00';
            if (minutes < 10) {
                minutes = '0' + minutes
            }
        }
        if (minutes === 0) {
            minutes = '0' + minutes;
        }
        display.textContent = `${minutes}:${seconds}`;
    }
}