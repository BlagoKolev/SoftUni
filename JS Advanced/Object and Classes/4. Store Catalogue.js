function orderAlpha(input) {

    const catalogue = {};
    let args = '';
    for (const string of input) {
        const [product, price] = string.split(' : ').filter(x=>x.length !== 0) ;
        let mark = product[0];
        if (!catalogue.hasOwnProperty(mark)) {
            catalogue[mark] = [];
        }
        catalogue[mark].push(`${product}: ${price}`);

    }

    let keys = Object.keys(catalogue);
    for (const property of keys.sort()) {
        console.log(property)

        for (const product of catalogue[property].sort()) {
            console.log(`  ${product}`);
        }
    }
}
orderAlpha(['Appricot : 20.4',
    'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'Apple : 1.25',
    'Anti-Bug Spray : 15',
    'T-Shirt : 10']
)