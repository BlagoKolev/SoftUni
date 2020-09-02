function CheckRadar([speed, location]){

    let speedLimit=0;

    switch (location) {
        case 'motorway': speedLimit = 130;break;
        case 'interstate':speedLimit = 90;break;
        case 'city':speedLimit = 50;break;
        case 'residential':speedLimit = 20;break;        
        }

        let speedDiff = speed- speedLimit;
        
        if (speedDiff<=0) {
            
        }else if (speedDiff>0 && speedDiff<=20) {
            console.log('speeding');
        }else if (speedDiff > 20 && speedDiff <=40) {
            console.log('excessive speeding');
        }else if (speedDiff>40) {
            console.log('reckless driving');
        }
        
}
CheckRadar([21, 'residential'])