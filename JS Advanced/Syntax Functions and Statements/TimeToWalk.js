function CalculateTime(steps,stepLengthMeters,speedKmPerHour){
    let stepsInMeters = steps*stepLengthMeters;
    let minutesForBrakes = Math.floor(stepsInMeters/500);
    let speedMetersPerSecond = (speedKmPerHour*1000)/3600;
    let timeInSeconds = stepsInMeters/speedMetersPerSecond + minutesForBrakes*60;
    let hours =0;
    let minutes=0;
    let seconds = timeInSeconds;

    if (seconds>=60) {
    minutes = Math.floor(timeInSeconds/60);
    seconds = Math.round(seconds-(60*minutes));  
    }

    if (minutes >= 60) {
        hours = Math.floor(minutes/60);
        minutes = minutes-(60*hours); 
    } 

     if (seconds < 10) {
        seconds = '0' + seconds;
    }
    if (minutes < 10) {
        minutes = '0' + minutes;
    }  
    if (hours < 10) {
        hours = '0' + hours;
    }
   console.log(`${hours}:${minutes}:${seconds}`);
}
CalculateTime(2564, 0.70, 5.5)