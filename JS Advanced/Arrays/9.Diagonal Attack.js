function solve(input) {

    let mainDiagonal = 0;
    let secondDiagonal = 0;
    let matrix = [];
    input.forEach((element, i) => {
        element = element.split(' ');
        matrix.push(element);
        mainDiagonal += Number(element[i]);
        secondDiagonal += Number(element[element.length - 1 - i]);
    });

    if (mainDiagonal === secondDiagonal) {

        for (let i = 0; i < matrix.length; i++) {
            const line = matrix[i];

            for (let j = 0; j < matrix.length; j++) {
                const element = Number(matrix[i][j]);

                if ((i === i && j===i) ||( i===i && j === matrix.length - 1 - i)) {
                    continue;
                }else{
                    matrix[i][j] = mainDiagonal;
                }
                
            }
            
        }
    }
    matrix.forEach(element => console.log(element.join(' ')))


}

solve(['5 3 12 3 1',
'11 4 23 2 5',
'101 12 3 21 10',
'1 4 5 2 2',
'5 22 33 11 1']

)