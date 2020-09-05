function extract(array){
    const result = [];
    let currentNum = Number.MIN_SAFE_INTEGER ;

    array.forEach(element => {
        if (element >= currentNum ) {
            result.push(element);
            currentNum = element;
        }
        
    });
console.log(result.join('\n'));
}

extract(
    [1, 
        3, 
        8, 
        4, 
        10, 
        12, 
        3, 
        2, 
        24]
    )