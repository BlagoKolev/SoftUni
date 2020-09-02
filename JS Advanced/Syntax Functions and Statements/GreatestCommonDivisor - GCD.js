function calculateGCD(num1, num2){
      let divisible = num1;
      let divider = num2;
    let residue =0;

     if (num1<num2) {
      divisible = num2;
      divider= num1;
     }
    while (true) {
         residue = divisible % divider;
        if (residue==0) {
            break;
        }
        divisible = divider;
        divider = residue;             
    }

    console.log(divider);
}
calculateGCD(18,84);