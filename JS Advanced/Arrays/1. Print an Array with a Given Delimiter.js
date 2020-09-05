function PrintArray(array){
    
    let separator = array[array.length -1];
    let resultArray = array.slice(0,array.length-1);
    console.log(resultArray.join(separator))
}



