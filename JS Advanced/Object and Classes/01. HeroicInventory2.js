function makeHeroes(input){

  let output = input.reduce((acc,element,i,array) => {

        let [heroName,heroLevel,heroItems] = element.split(' / ');
        let hero = {name:heroName,
            level:Number(heroLevel),
            items:heroItems ? heroItems.split(', ') :[]};
        acc.push(hero)
        return acc; 
    },[])

    console.log(JSON.stringify(output));
}

makeHeroes(['Isacc / 25 / Apple, GravityGun',
'Derek / 12 / BarrelVest, DestructionSword',
'Hes / 1 / ']
);