(function solve() {
    Array.prototype.last = function () {
        if (this.length > 0) {
            return this[this.length - 1];
        }
        throw new Error("Array is empty");

    }

    Array.prototype.skip = function (n) {
        if (this.length > n && n > 0) {
            let result = [];
            for (let i = n; i < this.length; i++) {
                result.push(this[i]);
            }
            return result;
        }
        throw new Error("Array is too short")
    }

    Array.prototype.take = function(n) {
        if (this.length > n && n > 0) {
            let result = [];
            for (let i = 0; i < n; i++) {
                result.push(this[i]);
            }
            return result;
        }
    }

    Array.prototype.sum = function () {
        return this.reduce((a, b) => a+b);
      };

      Array.prototype.average = function () {
        return this.sum()/this.length;
      }
}());с