function calculatePrice(fruit,grams,pricePerKilo){
    let kilograms = grams/1000;
    let price = kilograms*pricePerKilo;
    console.log(`I need $${price.toFixed(2)} to buy ${kilograms.toFixed(2)} kilograms ${fruit}.`)
}

calculatePrice('bananas', 1000,15)