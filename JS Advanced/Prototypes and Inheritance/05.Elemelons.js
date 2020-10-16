function solve(){
    class Melon {

        constructor(weight, melonSort) {
            if (new.target === Melon) {
                throw new Error('Abstract class cannot be instantiated directly')
            }
            this.weight = weight;
            this.melonSort = melonSort;
        }
    
        get elementIndex(){
            return (this.weight * this.melonSort.length);
        }
    }
    
    class Watermelon extends Melon {
        constructor(weight, melonSort) {
            super(weight, melonSort);
        }
        toString(){
            let element = 'Water'
            return `Element: ${element}\nSort: ${this.melonSort}\nElement Index: ${this.elementIndex}`
        }
    }
    
    class Firemelon extends Melon{
        constructor(weight,melonSort){
            super(weight,melonSort);
        }
        toString(){
            let element = 'Fire'
            return `Element: ${element}\nSort: ${this.melonSort}\nElement Index: ${this.elementIndex}`
        }
    }
    
    class Earthmelon extends Melon{
        constructor(weight,melonSort){
            super(weight,melonSort);
        }
        toString(){
            let element = 'Earth'
            return `Element: ${element}\nSort: ${this.melonSort}\nElement Index: ${this.elementIndex}`
        }
    }
    
    class Airmelon extends Melon{
        constructor(weight,melonSort){
            super(weight,melonSort);
        }
        toString(){
            let element = 'Air'
            return `Element: ${element}\nSort: ${this.melonSort}\nElement Index: ${this.elementIndex}`
        }
    }
    
return {Melon,Watermelon,Firemelon,Airmelon,Earthmelon}    
}