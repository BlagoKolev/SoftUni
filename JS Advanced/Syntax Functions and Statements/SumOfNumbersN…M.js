function calculate(arg1, arg2){
    let num1 = Number(arg1);
    let num2 = Number(arg2);
    let result=0;
    for (let index = num1; index <= num2; index++) {
        
        result += index;
    }
  return result;
}
console.log(calculate('1', '5'));