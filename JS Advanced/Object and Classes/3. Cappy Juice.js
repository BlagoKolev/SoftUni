function solve(input) {
    const juices = [];
    const output =[];
    for (const element of input) {
        let args = element.split(' => ');
        let name = args[0];
        let quantity = Number(args[1]);
        let juice = { name: name, quantity:0,bottles:0 };

        if (!juices.some(x=>x.name === name)) {
            juices.push(juice);
            
        } 
        juice = juices.find(x=>x.name === name);
             juice.quantity += quantity;
            if (juice.quantity/1000 >=1) {
                juice.bottles += Math.floor(juice.quantity/1000);
                juice.quantity -=  Math.floor(juice.quantity/1000) * 1000;
                
                if (!output.some(x=>x.name === juice.name)) {
                    output.push(juice);
                }    
            }
    }
    for (const juice of output) {
        console.log(`${juice.name} => ${juice.bottles}`)
    }

   
}

solve(['Kiwi => 234',
'Pear => 2345',
'Watermelon => 3456',
'Kiwi => 4567',
'Pear => 5678',
'Watermelon => 6789'])