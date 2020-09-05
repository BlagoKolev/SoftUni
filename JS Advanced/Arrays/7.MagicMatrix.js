function solve(matrix) {

    let rowSum = 0;
    let etalon;
    let isMagic = true;

    for (let row = 0; row < matrix.length; row++) {

        const element = matrix[row];
        let reducer = (accumulator, currenValue) => accumulator + currenValue;
        rowSum = element.reduce(reducer);
        if (row === 0) {
            etalon = rowSum;
        }
        let colSum = 0;

        for (let col = 0; col < matrix.length; col++) {
            const elementCol = matrix[col][row];
            colSum += elementCol;
        }

        if (rowSum !== etalon || colSum !== etalon) {
            isMagic = false;
            break;
        }
    }
    console.log(isMagic)
}

solve([[1, 0, 0],
    [0, 0, 1],
    [0, 1, 0]])