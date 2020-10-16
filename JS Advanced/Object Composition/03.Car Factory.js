function solve(clientModel) {
    const engines = {
        smallEngine: { power: 90, volume: 1800 },
        normalEngine: { power: 120, volume: 2400 },
        monsterEngine: { power: 200, volume: 3500 },
    }
    const carriages = {
        Hatchback: { type: 'hatchback' },
        Coupe: { type: 'coupe' }
    }
    let {model,power,color,carriage,wheelsize }= clientModel ;
   let engine;

  for (const key in engines) {
      currentEngine = engines[key]['power'];
      if (power <= currentEngine) {
          engine = engines[key];
          break;
      }
  }
  for (const key in carriages) {
      let currentCarriage = carriages[key];
if (carriage === key.toLocaleLowerCase()) {
    carriage = currentCarriage;
    carriage.color = color;
    break;
}
  }

  if (wheelsize %2 === 0) {
      wheelsize -=1;
  }
  wheels = [wheelsize,wheelsize,wheelsize,wheelsize]
  const offertModel = {model,engine,carriage,wheels};
return offertModel;

}

console.log(solve({ model: 'Opel Vectra',
power: 110,
color: 'grey',
carriage: 'coupe',
wheelsize: 17 }

))