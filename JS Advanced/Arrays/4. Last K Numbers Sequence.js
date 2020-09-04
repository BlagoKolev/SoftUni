function solve(n,k){   
    const result = [1];
   
    let currentElement =0;
 
    for (let i = 1; i < n; i++) {
        
        if (i<k) {
           const tempArray= result.slice(0,i);
            currentElement = calculateCurrent(tempArray);
             result.push(currentElement);
        }else{
            tempArray = result.slice(i-k,i);
            currentElement = calculateCurrent(tempArray);
            result.push(currentElement);
        }
       
    }
    console.log(result.join(' '));
    function calculateCurrent(array){
        let sum = 0;
        for (let i = 0; i < array.length; i++) {
            const element = array[i];
            sum += element;
        }
        return sum;
    }
}
solve(1,5)