function sortArray(array, criteria){

    if (criteria === 'asc') {
        array = array.sort((a,b) => a-b);
    }else{
        array = array.sort((a,b) => b-a);
    }
    return array;
}

console.log(sortArray([14, 7, 17, 6, 8], 'desc'))