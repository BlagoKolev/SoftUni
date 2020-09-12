class List {
    constructor() {
        this._list = [];
    }
    add(element) {
        this._list.push(element);
        this._list.sort((a, b) => a - b);
    }
    remove(index) {
        if (index>=0 && index< this.size) {
          this._list.splice(index,1);
        }
       
    }

    get(index){
        if (index>=0 && index< this.size) {
            return this._list[index];
        }
        
    }
   size = this._list.length;

}

let list = new List();
list.add(5);
list.add(6);
list.add(1);
console.log(list.get(1)); 
list.remove(1);
console.log(list.get(1));
console.log(list.size)