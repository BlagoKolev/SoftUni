function GetEvenElements(array){
    let resultArray = [];

    for (let i = 0; i < array.length; i++) {
        const element = array[i];
        if (i%2 == 0) {
            resultArray.push(element);
        }    
    }
     return resultArray.join(' ');
}
 
console.log(GetEvenElements(['20', '30', '40']))