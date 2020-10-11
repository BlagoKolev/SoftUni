function solve(name,age,weight,height) {
       let person = {
        name: name,
        personalInfo: {
            age: age,
            weight: weight,
            height: height
        }
    }
    
    
    let calculateBMI = Math.round(weight / Math.pow((height / 100), 2));
    person.BMI = calculateBMI;

    let pStatus = '';

   if (calculateBMI <18.5) {
       pStatus = 'underweight'
   }else if (calculateBMI>=18.5 && calculateBMI< 25 ) {
       pStatus = 'normal';
   }else if (calculateBMI>=25 && calculateBMI <30) {
       pStatus = 'overweight';
   }else{
       pStatus = 'obese'
       person.recommendation = 'admission required';
   }
 person.status = pStatus;
  return person;
}
console.log(solve('Honey Boo Boo', 9, 57, 137));