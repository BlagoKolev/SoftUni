function solve(a) {

   function add(b) {
         a += b;
        return add;
    }
     add.toString = () =>a;
     
     return add;
}

console.log(solve(1)(6)(-3).toString())
