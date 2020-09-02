function solve(string1, string2 , string3){
    let lengthResult = string1.length + string2.length + string3.length;
    let averageLength = lengthResult / 3;
    console.log(lengthResult);
    console.log(Math.round(averageLength));
}
solve('chocolate', 'ice cream', 'cake');
