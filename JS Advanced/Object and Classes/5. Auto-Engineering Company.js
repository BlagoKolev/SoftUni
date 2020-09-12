function solve(input) {

    const register = {};

    for (const line of input) {
        const [brand, model, count] = line.split(' | ');
        if (!register.hasOwnProperty(brand)) {
            register[brand] = {};
        }
        if (!register[brand].hasOwnProperty(model)) {
            register[brand][model] = Number(count);
        } else {
            register[brand][model] += Number(count);
        }

    }
    const brands = Object.keys(register);
    for (const brand of brands) {
        console.log(brand)
        for (const key in register[brand]) {
            console.log(`###${key} -> ${register[brand][key]}`)
        }
    }


}

solve(['Audi | Q7 | 1000',
    'Audi | Q6 | 100',
    'BMW | X5 | 1000',
    'BMW | X6 | 100',
    'Citroen | C4 | 123',
    'Volga | GAZ-24 | 1000000',
    'Lada | Niva | 1000000',
    'Lada | Jigula | 1000000',
    'Citroen | C4 | 22',
    'Citroen | C5 | 10'])