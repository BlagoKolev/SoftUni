class Stringer {
    constructor(text, length) {
        this.innerString = text;
        this.innerLength = length;
    }

    increase(length) {
        this.innerLength += length
    }

    decrease(length) {
        this.innerLength - length < 0 ? this.innerLength = 0 : this.innerLength -= length;



    }

    toString() {
        let textToShow = '';

        if (this.innerString.length > this.innerLength) {
            textToShow = this.innerString.substring(0, this.innerLength).concat('...');
        }
        else if (this.innerLength === 0) {
            textToShow = '...'
        }
        else {
            textToShow = this.innerString;
        }
        return textToShow;
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
