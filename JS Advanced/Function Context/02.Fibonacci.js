function getFibonator(){
    let previous = 0;
    let current =1;

    function fibonacci(){
        let newElement = previous + current;
        previous = current; 
        current = newElement;
        return previous;
    }
    return fibonacci;
}
let fib = getFibonator();
console.log(fib()); // 1
console.log(fib()); // 1
console.log(fib()); // 2
console.log(fib()); // 3
