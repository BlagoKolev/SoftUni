function solve(number){
    let sum =0;
    let areAllSame =true;
    let lastElement = 0;
    let numberAsString = String(number);
    let length = number.length;
    for (let i = 0; i < numberAsString.length-1; i++) {

        let element = numberAsString[i];
        let nextElement = numberAsString[i+1];

        if (element !== nextElement) {
            areAllSame = false;
        }
        sum+= Number(element);
        lastElement = numberAsString[numberAsString.length-1];
    }
    sum+=Number(lastElement);
    console.log(areAllSame);
    console.log(sum);
   
}
solve(2222222);