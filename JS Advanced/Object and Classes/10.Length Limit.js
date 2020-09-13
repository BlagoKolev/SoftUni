class Stringer{

    constructor(text,length){
        this.innerString = text;
        this.innerLength=length;
    }
    decrease(value){

         this.innerLength -value <0 ? this.innerLength = 0 : this.innerLength-=value;
         return this.innerLength;
    }

    increase(value){
        return this.innerLength += value;
    }

    toString(){
        if (this.innerString.length <= this.innerLength) {
            return this.innerString;
        }else if (this.innerString.length > this.innerLength) {
            //let diff = this.innerString.length - this.innerLength
           let newString = this.innerString.substring(0, this.innerLength)
           return newString + '...'
        }
    }
}

let test = new Stringer("Test", 5);
console.log(test.toString()); // Test

test.decrease(3);
console.log(test.toString()); // Te...

test.decrease(5);
console.log(test.toString()); // ...

test.increase(4); 
console.log(test.toString()); // Test