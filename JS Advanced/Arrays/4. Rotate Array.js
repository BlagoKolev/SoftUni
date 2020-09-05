function solve(array) {

    let turns = array[array.length - 1];
    array = array.slice(0, array.length - 1);
    let realTurns = turns % array.length;

    for (let i = 0; i < realTurns; i++) {
        const element = array.pop();
        array.unshift(element);
    }
    console.log(array.join(' '))
}

solve(['Banana',
    'Orange',
    'Coconut',
    'Apple',
    '15'])

