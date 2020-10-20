class ChristmasDinner {
    constructor(budget) {
        this.budget = budget;
        this.dishes = [];
        this.products = [];
        this.guests = {};
    }

    set budget(value) {
        if (value < 0) {
            throw new Error("The budget cannot be a negative number");
        }
        this._budget = value;
    }

    get budget(){
        return this._budget;
    }
    shopping(product) {
        let currProduct = product[0];
        let price = Number(product[1]);
        if (price > this.budget) {
            throw new Error("Not enough money to buy this product");
        }
        this.budget -= price;
        this.products.push(currProduct);
        return `You have successfully bought ${currProduct}!`
    }

    recipes(recipe) {
        let name = recipe.recipeName;
        let neededProducts = recipe.productsList;
        for (const product of neededProducts) {
            if (!this.products.includes(product)) {
                throw new Error("We do not have this product");
            }
        }
        this.dishes.push({ recipeName: name, productsList: neededProducts })

        return `${name} has been successfully cooked!`;
    }

    inviteGuests(name, dish) {
        
        if (!this.dishes.find(x => x.recipeName === dish)) {
            throw new Error("We do not have this dish");
        }
        if (this.guests.hasOwnProperty(name)) {
            throw new Error('This guest has already been invited');
        }

        this.guests[name] = dish;

        return `You have successfully invited ${name}!`
    }

    showAttendance() {
        let output = '';
        for (const guest in this.guests) {
            output += `${guest} will eat ${this.guests[guest]}, which consists of `;
            for (const dish of this.dishes) {
                if (dish.recipeName === this.guests[guest] ) {
                    output += `${dish.productsList.join(', ')}\n`
                }
               
            }
        }
        return output.trim();
    }
}
let dinner = new ChristmasDinner(300);

dinner.shopping(['Salt', 1]);
dinner.shopping(['Beans', 3]);
dinner.shopping(['Cabbage', 4]);
dinner.shopping(['Rice', 2]);
dinner.shopping(['Savory', 1]);
dinner.shopping(['Peppers', 1]);
dinner.shopping(['Fruits', 40]);
dinner.shopping(['Honey', 10]);

dinner.recipes({
    recipeName: 'Oshav',
    productsList: ['Fruits', 'Honey']
});
dinner.recipes({
    recipeName: 'Folded cabbage leaves filled with rice',
    productsList: ['Cabbage', 'Rice', 'Salt', 'Savory']
});
dinner.recipes({
    recipeName: 'Peppers filled with beans',
    productsList: ['Beans', 'Peppers', 'Salt']
});

dinner.inviteGuests('Ivan', 'Oshav');
dinner.inviteGuests('Petar', 'Folded cabbage leaves filled with rice');
dinner.inviteGuests('Georgi', 'Peppers filled with beans');

console.log(dinner.showAttendance());

