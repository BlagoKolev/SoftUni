function SortArray(array) {

    const resultArray = [];
    for (let i = 0; i < array.length; i++) {
        const element = array[i];

        if (element < 0) {
            resultArray.unshift(element);
        } else {
            resultArray.push(element);
        }
    }
    return resultArray.join('\n');
}

console.log(SortArray([7, -2, 8, 9]));