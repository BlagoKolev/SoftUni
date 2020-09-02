function solve(arr)
{
    let sum = 0 ;
    let inversedSum =0;
    let numberAsString = '';
    arr.forEach(element => {
        sum+=element;
        inversedSum+= 1/element;
        numberAsString += element +'';
    });
        console.log(sum);
        console.log(inversedSum);
        console.log(numberAsString);
}
solve([1,2,3])