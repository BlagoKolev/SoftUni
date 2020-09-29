function solve(input){

    const catalogue = {};
 
    input.forEach(element => {
        let [town, product, productInfo] = element.split(' -> ');
        let [sales,price] =productInfo.split(' : ');
       let income = Number(sales) * Number(price);
        if (!catalogue.hasOwnProperty(town)) {
            catalogue[town] = {};
        }
        catalogue[town][product] = income;
    });

    for (const town in catalogue) {
       console.log(`Town - ${town}`)
      for (const product in catalogue[town]) {
         console.log(`${product} : ${catalogue[town][product]}`)
      }
        
      
    }
}

solve(['Sofia -> Laptops HP -> 200 : 2000',
'Sofia -> Raspberry -> 200000 : 1500',
'Sofia -> Audi Q7 -> 200 : 100000',
'Montana -> Portokals -> 200000 : 1',
'Montana -> Qgodas -> 20000 : 0.2',
'Montana -> Chereshas -> 1000 : 0.3']
)