function PrintNth(array){
    let step = Number(array[array.length-1]);
    array = array.slice(0,array.length-1);
   
    for (let index = 0; index < array.length; index+=step) {
        const element = array[index];
        console.log(element);
    }
}

